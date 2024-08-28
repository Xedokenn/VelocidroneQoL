using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using MelonLoader;
using HarmonyLib;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using VelocidroneQoL;
using RLD;
using MelonLoader;
using DiscordRPC;
using DiscordRPC.Logging;

namespace VelocidroneQoL
{
    public class VelocidroneQoLClass : MelonMod
    {
        private DiscordRpcClient client;

        public override void OnApplicationStart()
        {
            client = new DiscordRpcClient("1113807408750415872");

            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            client.Initialize();

            client.SetPresence(new RichPresence()
            {
                Details = "Playing My Game",
                State = "In the main menu",
                Assets = new Assets()
                {
                    LargeImageKey = "cat",
                    LargeImageText = "Large Image",
                    SmallImageKey = "clown",
                    SmallImageText = "Small Image"
                }
            });
        }

        public override void OnUpdate()
        {
            client.Invoke();
        }

        public override void OnApplicationQuit()
        {
            client.Dispose();
        }
    }
}