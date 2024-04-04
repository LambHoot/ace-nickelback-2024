using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using DSharpPlus;
using DSharpPlus.Entities;
using Newtonsoft.Json;

namespace lambhootDiscordBot
{
    class DiscordBot
    {
        private string discordBotToken;
        private ulong discordBotUserId;
        private ulong adminUserId;
        private ulong trainingChannelId;
        private ulong generalChannelId;
        private string logFileName;

        private DiscordUser discordBotUser;
        private DiscordUser adminUser;
        private DiscordChannel trainingChannel;
        private DiscordChannel generalChannel;
        
        private DiscordClient discord;
        private PartialBiGram biGram;
        private System.Timers.Timer hourlyTimer;

        public DiscordBot()
        {
            loadConfiguration();
            this.biGram = new PartialBiGram(this.logFileName);
            this.hourlyTimer = new System.Timers.Timer(3600000 + 1800000);// 1.5 hour in milliseconds
            // this.hourlyTimer = new System.Timers.Timer(1800000);// 0.5 hour in milliseconds
            this.hourlyTimer.Elapsed += HourlyTask;
        }

        private void loadConfiguration()
        {
            using (StreamReader r = new StreamReader("config.json"))
            {
                string json = r.ReadToEnd();
                dynamic config = JsonConvert.DeserializeObject(json);

                discordBotToken = config.discordBotToken;
                discordBotUserId = config.discordBotUserId;
                adminUserId = config.adminUserId;
                trainingChannelId = config.trainingChannelId;
                generalChannelId = config.generalChannelId;
                logFileName = config.logFileName;
            }
        }

        private async void initClient() {
            DiscordClient discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = this.discordBotToken,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            });
            this.discord = discord;

            // find users
            this.adminUser = await discord.GetUserAsync(this.adminUserId);
            this.discordBotUser = await discord.GetUserAsync(this.discordBotUserId);

            // find channels
            this.generalChannel = await this.discord.GetChannelAsync(this.generalChannelId);
            this.trainingChannel = await this.discord.GetChannelAsync(this.trainingChannelId);
        }

        // Post arbitrary message, unprompted, into channel
        public async void postMessage(String message, DiscordChannel channel) {
            var msg = await new DiscordMessageBuilder()
                .WithContent(message)
                .SendAsync(channel);
        }

        // Method to be called on each hourly interval
        private async void HourlyTask(object sender, ElapsedEventArgs e)
        {
            logInfo("Hourly task running...");
            string sentence = biGram.generateNewBiGramSentence();
            this.postMessage(sentence, this.generalChannel);
            logInfo("Hourly task complete.");
        }

        // ------------------ MAIN ------------------
        public async Task Main()
        {
            initClient();
            this.discordBotUser = this.discord.CurrentUser;
            
            // listen and respond to pings
            this.discord.MessageCreated += async (s, e) =>
            {
                // Admin-only commands - skip logging
                if (e.Message.Author == this.adminUser) {
                    logInfo("Admin message detected.");
                    if (e.Message.Content.ToLower().StartsWith("ping")) {
                        await e.Message.RespondAsync("pong!");
                        return;
                    }
                    if (e.Message.Content.ToLower().StartsWith("retrain")) {
                        this.biGram = null; // encourage garbage collector
                        this.biGram = new PartialBiGram(this.logFileName);
                        await e.Message.RespondAsync("retained and ready to rumble 😎");
                        return;
                    }
                    if (e.Message.Content.ToLower().StartsWith("speak")) {
                        string sentence = biGram.generateNewBiGramSentence();
                        this.postMessage(sentence, this.generalChannel);
                        return;
                    }
                } else if (e.Message.Author == this.discordBotUser) {
                    return; // don't reply to own messages
                }

                // Write message contents to log file
                System.IO.File.AppendAllText(this.logFileName, e.Message.Content + Environment.NewLine);
                logInfo("Logged new sentence: " + e.Message.Content);

                // General user commands

                // Respond "lol" to messages containing "lol".
                if (e.Message.Content.ToLower().Contains("lol")) {
                    string lol = (new Random().NextDouble() < 0.75) ? "lol" : "LOL";
                    this.postMessage(lol, e.Message.Channel);
                    return;
                }

                if(e.Message.MentionedUsers.Any(user => user.Id == this.discordBotUserId)) {
                    logInfo("Replying to @...");
                    string sentence = biGram.generateNewBiGramSentence();
                    await e.Message.RespondAsync(sentence);
                }
            };

            // Start the hourly timer
            this.hourlyTimer.Start();

            // connection
            await this.discord.ConnectAsync();
            await Task.Delay(-1); // keep console open
        }

        private static void logInfo(string message) {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | " + message);
        }
    }

}