using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Config_Mover
{
	public class PlayerSummary
	{
		public Response response { get; set; } = null;
	}

	public class Response
	{
		public List<Player> players { get; set; } = null;
	}
	
	public class Player
	{
		public string steamid { get; set; } = null;
		public string personaname { get; set; } = null;
	}
}
