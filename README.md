Very rough readme, but basically:

1. Clone the repo.
2. Follow this guide to create a Discord bot and get your API credentials: [DSharpPlus - Creating a Bot Account](https://dsharpplus.github.io/DSharpPlus/articles/basics/bot_account.html#create-an-application)
3. Open the project in VSCode. Install .Net framework and all the NuGet packages it tells you to. If you're having trouble, just start a new C# project, then manually import this project's key resources (all `.cs` files in the root)
4. In `NGram Test > bin > Debug > net8.0`, create a config file called `config.json`. The Discord client will pull details from this config when instantiating the bot in `DiscordBot.cs`. The config must contain:
``` 
{
    "discordBotToken": "{your-token-here}",
    "discordBotUserId": {your-discord-bot-user-id},
    "adminUserId": {your-personal-discord-account-id},
    "trainingChannelId": {id-of-text-channel-used-for-training},
    "generalChannelId": {id-of-general-channel-where-bot-will-speak},
    "logFileName": "myDiscordLog.txt"
  }
```
5. In `NGram Test > bin > Debug > net8.0`, create a text file called `myDiscordLog.txt`. Fill it with a few starting sentences for training.
6. Run `Program.cs`.
7. Good luck.
