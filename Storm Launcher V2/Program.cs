using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading;
using StormLauncher.DiscordRpcDemo;

namespace Storm
{
    public class Program
    {

        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;

        static void Main() => new Program().Run().GetAwaiter().GetResult();



        public async Task Run()
        {

            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("854773015254794250", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("854773015254794250", ref this.handlers, true, null);
            this.presence.details = "Using Storm";
            this.presence.state = "discord.gg/stormfn";
            this.presence.largeImageKey = "logo";
            this.presence.smallImageKey = "";
            this.presence.largeImageText = "StormFN Hybrid Server";
            DiscordRpc.UpdatePresence(ref this.presence);


            Console.Title = "StormFN Launcher | (discord.gg/stormfn)";


            string[] FNStuff = { "FortniteClient-Win64-Shipping_EAC.exe", "FortniteClient-Win64-Shipping_BE.exe", "FortniteLauncher.exe" };

            foreach (string procname in FNStuff)
            {
                var process = Process.GetProcessesByName(procname);
                foreach (var proc in process)
                {
                    proc.Kill();
                }
            }



           


            Storm.Write("Welcome to storm");
           


            string TempPath = Path.GetTempPath();
            var Path1 = "";
            var version = "1";

            var path1 = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat"));
            dynamic Json = JsonConvert.DeserializeObject(path1);

            foreach (var installion in Json.InstallationList)
            {
                if (installion.AppName == "Fortnite")
                {
                    Path1 = installion.InstallLocation.ToString() + "\\FortniteGame\\Binaries\\Win64";
                    version = installion.AppVersion.ToString().Split('-')[1];
                }
            }

          


          





            if (!File.Exists(Path1 + "\\FortniteClient-Win64-Shipping_EAC.old")) { }
            else
            {
                File.Move(Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe", Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe.old");
            }

            if (!File.Exists(Path1 + "\\FortniteClient-Win64-Shipping_BE.old")) { }
            else
            {
                File.Move(Path1 + "\\FortniteClient-Win64-Shipping_BE.exe", Path1 + "\\FortniteClient-Win64-Shipping_BE.exe.old");
            }

            WebClient webClient = new WebClient();

            await webClient.DownloadFileTaskAsync("eac link", TempPath + "\\FortniteClient-Win64-Shipping_EAC.exe");
            await webClient.DownloadFileTaskAsync("be link", TempPath + "\\FortniteClient-Win64-Shipping_BE.exe");
            if (!File.Exists(TempPath + "\\Storm.dll"))
            {
                await webClient.DownloadFileTaskAsync("dll link", TempPath + "\\Storm.dll");
            }

            if (!File.Exists(Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe"))
            {
                File.Move(TempPath + "\\FortniteClient-Win64-Shipping_EAC.exe", Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe");
            }
            else
            {
                File.Delete(Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe");
                File.Move(TempPath + "\\FortniteClient-Win64-Shipping_EAC.exe", Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe");
            }

            if (!File.Exists(Path1 + "\\FortniteClient-Win64-Shipping_BE.exe"))
            {
                File.Move(TempPath + "\\FortniteClient-Win64-Shipping_BE.exe", Path1 + "\\FortniteClient-Win64-Shipping_BE.exe");
            }
            else
            {
                File.Delete(Path1 + "\\FortniteClient-Win64-Shipping_BE.exe");
                File.Move(TempPath + "\\FortniteClient-Win64-Shipping_BE.exe", Path1 + "\\FortniteClient-Win64-Shipping_BE.exe");
            }

            if (!File.Exists(Path1 + "\\Storm.dll"))
            {
                File.Move(TempPath + "\\Storm.dll", Path1 + "\\Storm.dll");
            }
            else
            {
                File.Delete(Path1 + "\\Storm.dll");
                File.Move(TempPath + "\\Storm.dll", Path1 + "\\Storm.dll");
            }




            var Proc = new ProcessStartInfo();
            Proc.CreateNoWindow = true;
            Proc.FileName = "cmd.exe";
            Proc.Arguments = "/C start com.epicgames.launcher://apps/Fortnite?action=launch";
            Process.Start(Proc);


            Storm.Log("Started game");
            

            Storm.Log("Would you like to join our Discord Server? Y/N >");
            var read = Console.ReadLine().ToLower();
            if (read == "y")
            {
                Process.Start("https://discord.gg/stormfn");
            }
            else
            {
                Console.Write("\n");
                Console.ReadLine();
            }
        }
    }
}