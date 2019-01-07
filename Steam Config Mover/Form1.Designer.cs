namespace Steam_Config_Mover
{
	partial class SteamConfigMover
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.inputSteamWebKey = new System.Windows.Forms.TextBox();
			this.steamAPILabel = new System.Windows.Forms.LinkLabel();
			this.getUserdataFolders = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.selectAppIDMenu = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.copyTo = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.copyFrom = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.accountListDeleteMenu = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.accountListProfileList = new System.Windows.Forms.ComboBox();
			this.openProfile = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// inputSteamWebKey
			// 
			this.inputSteamWebKey.Location = new System.Drawing.Point(12, 25);
			this.inputSteamWebKey.Name = "inputSteamWebKey";
			this.inputSteamWebKey.Size = new System.Drawing.Size(510, 20);
			this.inputSteamWebKey.TabIndex = 0;
			// 
			// steamAPILabel
			// 
			this.steamAPILabel.AutoSize = true;
			this.steamAPILabel.Location = new System.Drawing.Point(12, 9);
			this.steamAPILabel.Name = "steamAPILabel";
			this.steamAPILabel.Size = new System.Drawing.Size(107, 13);
			this.steamAPILabel.TabIndex = 1;
			this.steamAPILabel.TabStop = true;
			this.steamAPILabel.Text = "Steam Web API Key:";
			this.steamAPILabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.steamAPILabel_LinkClicked);
			// 
			// getUserdataFolders
			// 
			this.getUserdataFolders.Location = new System.Drawing.Point(15, 51);
			this.getUserdataFolders.Name = "getUserdataFolders";
			this.getUserdataFolders.Size = new System.Drawing.Size(153, 33);
			this.getUserdataFolders.TabIndex = 2;
			this.getUserdataFolders.Text = "List Accounts";
			this.getUserdataFolders.UseVisualStyleBackColor = true;
			this.getUserdataFolders.Click += new System.EventHandler(this.getUserdataFolders_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.selectAppIDMenu);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.copyTo);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.copyFrom);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(15, 91);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(507, 121);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Copy Config";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Copy app:";
			// 
			// selectAppIDMenu
			// 
			this.selectAppIDMenu.FormattingEnabled = true;
			this.selectAppIDMenu.Location = new System.Drawing.Point(73, 63);
			this.selectAppIDMenu.Name = "selectAppIDMenu";
			this.selectAppIDMenu.Size = new System.Drawing.Size(428, 21);
			this.selectAppIDMenu.TabIndex = 5;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 90);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Copy";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// copyTo
			// 
			this.copyTo.FormattingEnabled = true;
			this.copyTo.Location = new System.Drawing.Point(73, 41);
			this.copyTo.Name = "copyTo";
			this.copyTo.Size = new System.Drawing.Size(428, 21);
			this.copyTo.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Copy To:";
			// 
			// copyFrom
			// 
			this.copyFrom.FormattingEnabled = true;
			this.copyFrom.Location = new System.Drawing.Point(73, 17);
			this.copyFrom.Name = "copyFrom";
			this.copyFrom.Size = new System.Drawing.Size(428, 21);
			this.copyFrom.TabIndex = 1;
			this.copyFrom.SelectedIndexChanged += new System.EventHandler(this.copyFrom_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Copy From:";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(175, 52);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(341, 32);
			this.progressBar.TabIndex = 4;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.accountListDeleteMenu);
			this.groupBox2.Location = new System.Drawing.Point(15, 219);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(507, 78);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Delete Userdata";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(6, 47);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Delete";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Delete data:";
			// 
			// accountListDeleteMenu
			// 
			this.accountListDeleteMenu.FormattingEnabled = true;
			this.accountListDeleteMenu.Location = new System.Drawing.Point(73, 20);
			this.accountListDeleteMenu.Name = "accountListDeleteMenu";
			this.accountListDeleteMenu.Size = new System.Drawing.Size(428, 21);
			this.accountListDeleteMenu.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.openProfile);
			this.groupBox3.Controls.Add(this.accountListProfileList);
			this.groupBox3.Location = new System.Drawing.Point(15, 304);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(507, 47);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Open Profile";
			// 
			// accountListProfileList
			// 
			this.accountListProfileList.FormattingEnabled = true;
			this.accountListProfileList.Location = new System.Drawing.Point(88, 19);
			this.accountListProfileList.Name = "accountListProfileList";
			this.accountListProfileList.Size = new System.Drawing.Size(413, 21);
			this.accountListProfileList.TabIndex = 0;
			// 
			// openProfile
			// 
			this.openProfile.Location = new System.Drawing.Point(7, 18);
			this.openProfile.Name = "openProfile";
			this.openProfile.Size = new System.Drawing.Size(75, 23);
			this.openProfile.TabIndex = 1;
			this.openProfile.Text = "Open Profile";
			this.openProfile.UseVisualStyleBackColor = true;
			this.openProfile.Click += new System.EventHandler(this.openProfile_Click);
			// 
			// SteamConfigMover
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 363);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.getUserdataFolders);
			this.Controls.Add(this.steamAPILabel);
			this.Controls.Add(this.inputSteamWebKey);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "SteamConfigMover";
			this.Text = "Steam Userdata Mover";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox inputSteamWebKey;
		private System.Windows.Forms.LinkLabel steamAPILabel;
		private System.Windows.Forms.Button getUserdataFolders;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox copyTo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox copyFrom;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox selectAppIDMenu;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox accountListDeleteMenu;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button openProfile;
		private System.Windows.Forms.ComboBox accountListProfileList;
	}
}

