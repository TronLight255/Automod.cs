using System;
using MCGalaxy;

namespace Core {
    public class Latam : Plugin {
        public override string creator { get { return "Orange_scp"; } }
        public override string MCGalaxy_Version { get { return "1.9.2.8"; } }
        public override string name { get { return "Latam"; } }

        public override void Load(bool startup) {
            Command.Register(new CmdPeru());
            Command.Register(new CmdVenez());
            Command.Register(new CmdArg());
            Command.Register(new CmdGuat());
        }

        public override void Unload(bool shutdown) {
            Command.Unregister(Command.Find("Peru"));
            Command.Unregister(Command.Find("Venezuela"));
            Command.Unregister(Command.Find("Argentina"));
            Command.Unregister(Command.Find("Guatemala"));
        }
    }

    public class CmdPeru : Command {
        public override string name { get { return "Peru"; } }
        public override string type { get { return "other"; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }

        public override void Use(Player p, string message) {
            Chat.MessageAll("&4VIVA PE&fRUUUUUU&4UUUU.");
        }

        public override void Help(Player p) {
            p.Message("&T/Peru");
            p.Message("&SViva Perú!");
        }
    }

    public class CmdVenez : Command {
        public override string name { get { return "Venezuela"; } }
        public override string type { get { return "other"; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }

        public override void Use(Player p, string message) {
            Chat.MessageAll("&eVIVA VEN&1EZUELA&4AAAA.");
        }

        public override void Help(Player p) {
            p.Message("&T/Venezuela");
            p.Message("&SViva Venezuela!");
        }
    }

    public class CmdArg : Command {
        public override string name { get { return "Argentina"; } }
        public override string type { get { return "other"; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }

        public override void Use(Player p, string message) {
            Chat.MessageAll("&bVIVA AR&fGEN&eT&fINA&bAAAAA.");
        }

        public override void Help(Player p) {
            p.Message("&T/Argentina");
            p.Message("&SViva Argentina!");
        }
    }

    public class CmdGuat : Command {
        public override string name { get { return "Guatemala"; } }
        public override string type { get { return "other"; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }

        public override void Use(Player p, string message) {
            Chat.MessageAll("&3VIVA GUA&fTE&8M&fALA&3AAAA.");
        }

        public override void Help(Player p) {
            p.Message("&T/Guatemala");
            p.Message("&SViva Guatemala!");
        }
    }
}
