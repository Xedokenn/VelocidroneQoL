using MelonLoader;
using System;
using Discord;
using System.Threading;

[assembly: MelonInfo(typeof(DiscordStatus.DiscordStatusPlugin), "Velocidrone Discord Status", "1.0.0", "Xedoken")]
[assembly: MelonColor(ConsoleColor.DarkCyan)]


namespace DiscordStatus
{
    public class DiscordStatusPlugin : MelonPlugin
    {
        public const long AppId = 977473789854089226;
        public Discord.Discord discordClient;
        public ActivityManager activityManager;

        private bool gameClosing;
        public bool GameStarted { get; private set; }
        public long gameStartedTime;

        public override void OnPreInitialization()
        {
            DiscordLibraryLoader.LoadLibrary();
            InitializeDiscord();
            UpdateActivity();
            new Thread(DiscordLoopThread).Start();
        }

        public override void OnApplicationLateStart()
        {
            GameStarted = true;
            gameStartedTime = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

            UpdateActivity();
        }

        public override void OnApplicationQuit()
        {
            gameClosing = true;
        }

        public void DiscordLoopThread()
        {
            for (; ; )
            {
                if (gameClosing)
                    break;

                discordClient.RunCallbacks();
                Thread.Sleep(200);
            }
        }

        public void InitializeDiscord()
        {
            discordClient = new Discord.Discord(AppId, (ulong)CreateFlags.NoRequireDiscord);
            discordClient.SetLogHook(LogLevel.Debug, DiscordLogHandler);

            activityManager = discordClient.GetActivityManager();
        }

        private void DiscordLogHandler(LogLevel level, string message)
        {
            switch (level)
            {
                case LogLevel.Info:
                case LogLevel.Debug:
                    LoggerInstance.Msg(message);
                    break;

                case LogLevel.Warn:
                    LoggerInstance.Warning(message);
                    break;

                case LogLevel.Error:
                    LoggerInstance.Error(message);
                    break;
            }
        }

        public void UpdateActivity()
        {
            var activity = new Activity
            {
                Details = $"Playing 098098098 {MelonUtils.CurrentGameAttribute.Name}" //2nd line (fist without bold)
            };

            activity.Assets.LargeImage = $"{ImageType.User}"; // big picture
            activity.Assets.SmallImage = $"{ImageType.User}"; // small picture

            activity.Assets.LargeText = $"Big picture text"; //big picture text
            activity.Assets.SmallText = $"small picture text"; // small picture text

            
            activity.Name = $"{MelonUtils.CurrentGameAttribute.Name} 123123123 {BuildInfo.Version}";
            activity.Instance = true;
            

            var modsCount = MelonHandler.Mods.Count;
            activity.State = GameStarted ? $"{modsCount} {(modsCount == 1 ? "Mod" : "Mods")} Loaded" : "Loading MelonLoader"; //3rd line

            activity.Assets.LargeText = $"{ActivityType.Playing}";







            if (GameStarted)
                activity.Timestamps.Start = gameStartedTime; //4th line

            activityManager.UpdateActivity(activity, ResultHandler);
        }

        public void ResultHandler(Result result)
        {

        }
    }
}
