using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Config_Mover
{
	public class AppList
	{
		public Applist applist { get; set; } = null;
	}

	public class Applist
	{
		public List<App> apps { get; set; } = null;
	}

	public class App
	{
		public int? appid { get; set; } = null;
		public string name { get; set; } = null;
	}
}
