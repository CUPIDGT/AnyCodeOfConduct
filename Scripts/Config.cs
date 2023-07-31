using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using BepInEx.Configuration;
using System.IO;
using AnyCodeOfConduct;

namespace AnyCodeOfConduct.Scripts
{
    public static class Config
    {
        public static ConfigFile ConfigFile { get; private set; }

        public static ConfigEntry<string> HeaderText;
        public static ConfigEntry<string> BodyText;

        public static void Initalize()
        {
            ConfigFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "AnyCodeOfConduct.cfg"), true);

            HeaderText = ConfigFile.Bind("Configuration", "Header Text", "GORILLA CODE OF CONDUCT", "This will change the main header text of the Code of Conduct");
            BodyText = ConfigFile.Bind("Configuration", "Body Text", "-NO RACISM, SEXISM, HOMOPHOBIA, TRANSPHOBIA, OR OTHER BIGOTRY\r\n-NO CHEATS OR MODS\r\n-DO NOT HARASS OTHER PLAYERS OR INTENTIONALLY MAKE THEM UNCOMFORTABLE\r\n-DO NOT TROLL OR GRIEF LOBBIES BY BEING UNCATCHABLE OR BY ESCAPING THE MAP. TRY TO MAKE SURE EVERYONE IS HAVING FUN\r\n-IF SOMEONE IS BREAKING THIS CODE, PLEASE REPORT THEM\r\n-PLEASE BE NICE GORILLAS AND HAVE A GOOD TIME", "This will change the body text of the Code of Conduct");

        }
    }
}
