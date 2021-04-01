using Exiled.API.Interfaces;

namespace VipBcCassieFeatures
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public string[] AllowedRoles { get; set; } = new[] {"VIP", "SERVER OWNER"};
        public string NoArgs { get; set; } = "You have not specified any arguments.";
        public bool RaRoleBypass { get; set; } = true;
        public string BcCommand { get; set; } = "bc";
        public string BcDescription { get; set; } = "Broadcast a message to all players.";
        public string[] BcAlias { get; set; }
        public ushort BcTime { get; set; } = 5;
        public bool BcEnablePrefix { get; set; } = true;
        public bool UseRoleColorForPrefixColor { get; set; }= true;
        public string BcPrefixColor { get; set; } = "#ffff00";
        
        public string CassieCommand { get; set; } = "cassie";
        public string CassieDescription { get; set; } = "Play a cassie announcements.";
        public string[] CassieAlias { get; set; } = new[] {"announcer"};
        public string CassieBroadcast { get; set; } = "%rank% cassie";

    }
}