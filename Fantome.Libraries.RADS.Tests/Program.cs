using Fantome.Libraries.RADS.IO.ReleaseManifest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantome.Libraries.RADS.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            ReleaseManifestTest();
        }

        static void ReleaseManifestTest()
        {
            ReleaseManifestFile relMan = new ReleaseManifestFile(new MemoryStream(new System.Net.WebClient().DownloadData("http://l3cdn.riotgames.com/releases/live/projects/lol_game_client/releases/0.0.0.0/releasemanifest")));
            relMan.Project.Remove();
            relMan.Write("myrealm");
            using (FileStream fs = File.Open("myrealm2", FileMode.Create))
            {
                relMan.Write(fs);
            }
        }
    }
}
