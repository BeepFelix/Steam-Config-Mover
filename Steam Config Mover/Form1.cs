using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace Steam_Config_Mover
{
	public partial class SteamConfigMover : Form
	{
		public SteamConfigMover()
		{
			InitializeComponent();
			
			if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "steamAPIKey.txt"))
			{
				string[] key = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "steamAPIKey.txt");
				if (key[0].Length >= 10)
				{
					inputSteamWebKey.Text = key[0];
				}
			}
		}
		
		static string AccountIDToSteamID64(int accountid)
		{
			return (accountid + 76561197960265728).ToString();
		}
		
		static int SteamID64ToAccountID(string steamID)
		{
			ulong sid = ulong.Parse(steamID);
			return (int)(sid - 76561197960265728);
		}

		private void steamAPILabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			steamAPILabel.LinkVisited = true;
			Process.Start("https://steamcommunity.com/dev/apikey");
		}

		List<Player> steamIDs = new List<Player>();
		HttpClient client = new HttpClient();
		AppList appList = null;
		string steamPath = null;
		JavaScriptSerializer _desializer = new JavaScriptSerializer();

		private async void getUserdataFolders_Click(object sender, EventArgs e)
		{
			progressBar.Style = ProgressBarStyle.Marquee;
			progressBar.MarqueeAnimationSpeed = 50;
			
			steamPath = await Task.Run(() =>
			{
				// Find Steam installation path. First GetValue() is for 64-Bit, second one is for 32-Bit
				object r = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", null);
				if (r == null)
				{
					r = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", null);
					if (r == null)
					{
						// Steam is not installed
						progressBar.Style = ProgressBarStyle.Blocks;
						progressBar.MarqueeAnimationSpeed = 0;
						MessageBox.Show("Could not find Steam installation path");
						return null;
					}
				}

				return r.ToString();
			});
			
			if (steamPath == null)
			{
				return;
			}

			string responseStringApps = await client.GetStringAsync("https://api.steampowered.com/ISteamApps/GetAppList/v2/");
			if (responseStringApps == null)
			{
				progressBar.Style = ProgressBarStyle.Blocks;
				progressBar.MarqueeAnimationSpeed = 0;
				MessageBox.Show("Failed to get AppList from Steam API. Steam could be down.");
				return;
			}

			_desializer.MaxJsonLength = responseStringApps.Length + 10;
			appList = _desializer.Deserialize<AppList>(responseStringApps);

			string[] directories = Directory.GetDirectories(steamPath + "/userdata");
			steamIDs.Clear();
			copyFrom.Items.Clear();
			copyTo.Items.Clear();
			accountListDeleteMenu.Items.Clear();
			accountListProfileList.Items.Clear();

			try
			{
				List<string> steamidList = new List<string>();
				foreach (string directory in directories)
				{
					if (directory.EndsWith("anonymous"))
					{
						continue;
					}

					string sid = AccountIDToSteamID64(int.Parse(directory.Split('\\').Last()));
					steamidList.Add(sid);
				}
				
				// TODO: Support more than 100 accounts
				string responseString = await client.GetStringAsync("https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key=" + inputSteamWebKey.Text.ToString() + "&steamids=" + string.Join(",", steamidList));

				if (responseString == null)
				{
					progressBar.Style = ProgressBarStyle.Blocks;
					progressBar.MarqueeAnimationSpeed = 0;
					MessageBox.Show("Invalid Steam API response - Could not fetch profile information");
					return;
				}

				PlayerSummary response = _desializer.Deserialize<PlayerSummary>(responseString);
				
				if (response.response == null || response.response.players == null || response.response.players[0] == null || response.response.players[0].personaname == null)
				{
					progressBar.Style = ProgressBarStyle.Blocks;
					progressBar.MarqueeAnimationSpeed = 0;
					MessageBox.Show("Invalid Steam API resposne - Could not fetch profile information");
					return;
				}

				foreach (Player res in response.response.players)
				{
					foreach (string id in steamidList)
					{
						if (res.steamid == id)
						{
							steamIDs.Add(res);
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				progressBar.Style = ProgressBarStyle.Blocks;
				progressBar.MarqueeAnimationSpeed = 0;
				MessageBox.Show(ex.Message);
				return;
			}

			foreach (Player steamID in steamIDs)
			{
				copyFrom.Items.Add(steamID.steamid + ": " + steamID.personaname);
				copyTo.Items.Add(steamID.steamid + ": " + steamID.personaname);
				accountListDeleteMenu.Items.Add(steamID.steamid + ": " + steamID.personaname);
				accountListProfileList.Items.Add(steamID.steamid + ": " + steamID.personaname);
			}

			try
			{
				File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "steamAPIKey.txt", this.inputSteamWebKey.Text);
			}
			catch (Exception ex)
			{
				progressBar.Style = ProgressBarStyle.Blocks;
				progressBar.MarqueeAnimationSpeed = 0;
				MessageBox.Show(ex.Message);
				return;
			}

			progressBar.Style = ProgressBarStyle.Blocks;
			progressBar.MarqueeAnimationSpeed = 0;
			MessageBox.Show("You can now select an account from the dropdown boxes");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (this.copyFrom.Items.Count < 2)
			{
				MessageBox.Show("You can only copy when you have 2 or more accounts in the dropdown menu");
				return;
			}

			if (this.copyFrom.SelectedIndex <= -1 || this.copyTo.SelectedIndex <= -1)
			{
				MessageBox.Show("You have to select an account in both dropdown menus");
				return;
			}

			if (this.copyFrom.SelectedIndex == this.copyTo.SelectedIndex)
			{
				MessageBox.Show("You cannot have the same account selected");
				return;
			}

			if (selectAppIDMenu.SelectedIndex <= -1)
			{
				MessageBox.Show("You have to select an App to copy its configuration");
				return;
			}

			int copyFrom = SteamID64ToAccountID(this.copyFrom.Items[this.copyFrom.SelectedIndex].ToString().Split(':').First());
			int copyTo = SteamID64ToAccountID(this.copyTo.Items[this.copyTo.SelectedIndex].ToString().Split(':').First());

			try
			{
				this.CopyAll(new DirectoryInfo(steamPath + "/userdata/" + copyFrom + "/" + selectAppIDMenu.Items[selectAppIDMenu.SelectedIndex].ToString().Split(':').First()), new DirectoryInfo(steamPath + "/userdata/" + copyTo + "/" + selectAppIDMenu.Items[selectAppIDMenu.SelectedIndex].ToString().Split(':').First()));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			MessageBox.Show("Successfully copied from /userdata/" + copyFrom + "/" + selectAppIDMenu.Items[selectAppIDMenu.SelectedIndex].ToString().Split(':').First() + " to /userdata/" + copyTo + "/" + selectAppIDMenu.Items[selectAppIDMenu.SelectedIndex].ToString().Split(':').First());
		}

		private async void copyFrom_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (copyFrom.SelectedIndex <= -1)
			{
				return;
			}

			progressBar.Style = ProgressBarStyle.Marquee;
			progressBar.MarqueeAnimationSpeed = 50;
			await Task.Delay(1000);

			selectAppIDMenu.Items.Clear();
			int sid = SteamID64ToAccountID(copyFrom.Items[copyFrom.SelectedIndex].ToString().Split(':').First());

			string[] directories = Directory.GetDirectories(steamPath + "/userdata/" + sid);
			foreach (string directory in directories)
			{
				string appWeWant = null;
				foreach (App app in appList.applist.apps)
				{
					if (app.appid.ToString() == directory.Split('\\').Last().ToString())
					{
						appWeWant = app.name;
					}
				}
				selectAppIDMenu.Items.Add(directory.Split('\\').Last().ToString() + ": " + (appWeWant == null ? "" : appWeWant));
			}

			progressBar.Style = ProgressBarStyle.Blocks;
			progressBar.MarqueeAnimationSpeed = 0;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (accountListDeleteMenu.SelectedIndex <= -1)
			{
				return;
			}

			int deleteAcc = SteamID64ToAccountID(accountListDeleteMenu.Items[accountListDeleteMenu.SelectedIndex].ToString().Split(':').First());

			if (MessageBox.Show("Are you sure you want to delete the folder for user " + AccountIDToSteamID64(deleteAcc) + " (" + deleteAcc + ")?", "Delete Userdata", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				try
				{
					Directory.Delete(steamPath + "/userdata/" + deleteAcc, true);
					copyFrom.Items.RemoveAt(accountListDeleteMenu.SelectedIndex);
					copyTo.Items.RemoveAt(accountListDeleteMenu.SelectedIndex);
					accountListDeleteMenu.Items.RemoveAt(accountListDeleteMenu.SelectedIndex);
					accountListProfileList.Items.RemoveAt(accountListDeleteMenu.SelectedIndex);

					copyFrom.SelectedIndex = -1;
					copyTo.SelectedIndex = -1;
					accountListDeleteMenu.SelectedIndex = -1;
					accountListProfileList.SelectedIndex = -1;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}
				MessageBox.Show("Successfully deleted userdata for /userdata/" + deleteAcc);
			}
		}

		private void CopyAll(DirectoryInfo oOriginal, DirectoryInfo oFinal)
		{
			foreach (DirectoryInfo oFolder in oOriginal.GetDirectories())
			{
				CopyAll(oFolder, oFinal.CreateSubdirectory(oFolder.Name));
			}

			foreach (FileInfo oFile in oOriginal.GetFiles())
			{
				oFile.CopyTo(oFinal.FullName + @"\" + oFile.Name, true);
			}
		}

		private void openProfile_Click(object sender, EventArgs e)
		{
			if (accountListProfileList.SelectedIndex <= -1)
			{
				return;
			}
			
			Process.Start("https://steamcommunity.com/profiles/" + accountListProfileList.Items[accountListProfileList.SelectedIndex].ToString().Split(':').First());
		}
	}
}
