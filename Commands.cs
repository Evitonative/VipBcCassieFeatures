using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;

namespace VipBcCassieFeatures
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class BC : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender senderPlayer)
            {
                var player = Player.Get(senderPlayer.PlayerId);
                if ((Plugin.Instance.Config.AllowedRoles.Contains(player.RankName) || Plugin.Instance.Config.RaRoleBypass) && player.RemoteAdminAccess)
                {
                    if (!arguments.IsEmpty())
                    {
                        string prefix;
                        if (Plugin.Instance.Config.BcEnablePrefix)
                        {
                            prefix = Plugin.Instance.Config.UseRoleColorForPrefixColor ?
                                $"<color={player.RankColor}>[{player.RankName}]</color> " : 
                                $"<color={Plugin.Instance.Config.BcPrefixColor}>[{player.RankName}]</color> ";
                        }
                        else
                        {
                            prefix = "";
                        }

                        var args= "";
                        for (var i = 0; i < arguments.Count; i++)
                        {
                            args = $"{args} {arguments.At(i)}";
                        }
                        
                        Map.Broadcast(Plugin.Instance.Config.BcTime, prefix + args);

                        response = prefix + args;
                        return true;
                    }
                    else
                    {
                        response = Plugin.Instance.Config.NoArgs;
                        return false;
                    }
                }
                else
                {
                    response = "Not permitted";
                    return false;
                }
            }
            else
            {
                response = "Only for players";
                return false;
            }
        }

        public string Command { get; } = Plugin.Instance.Config.BcCommand;
        public string[] Aliases { get; } = Plugin.Instance.Config.BcAlias;
        public string Description { get; } = Plugin.Instance.Config.BcDescription;
    }

    [CommandHandler(typeof(ClientCommandHandler))]
    public class cassie : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender senderPlayer)
            {
                var player = Player.Get(senderPlayer.PlayerId);
                if ((Plugin.Instance.Config.AllowedRoles.Contains(player.RankName) ||
                     Plugin.Instance.Config.RaRoleBypass) && player.RemoteAdminAccess)
                {
                    if (!arguments.IsEmpty())
                    {
                        if(Plugin.Instance.Config.CassieBroadcast != "")
                            Map.Broadcast(Plugin.Instance.Config.BcTime, Plugin.Instance.Config.UseRoleColorForPrefixColor ?
                                $"<color={player.RankColor}>{Plugin.Instance.Config.CassieBroadcast.Replace("%rank%", $"{player.RankName}")}</color>" :
                                $"<color={Plugin.Instance.Config.BcPrefixColor}>{Plugin.Instance.Config.CassieBroadcast.Replace("%rank%", $"{player.RankName}")}</color>");
                        var args= "";
                        for (var i = 0; i < arguments.Count; i++)
                        {
                            args = $"{args} {arguments.At(i)}";
                        }
                        Cassie.Message(args);

                        response = args;
                        return true;
                    }
                    else
                    {
                        response = Plugin.Instance.Config.NoArgs;
                        return false;
                    }
                }
                else
                {
                    response = "Not permitted";
                    return false;
                }
            }
            else
            {
                response = "Only for players";
                return false;
            }
        }

        public string Command { get; } = Plugin.Instance.Config.CassieCommand;
        public string[] Aliases { get; } = Plugin.Instance.Config.CassieAlias;
        public string Description { get; } = Plugin.Instance.Config.CassieDescription;
    }
}