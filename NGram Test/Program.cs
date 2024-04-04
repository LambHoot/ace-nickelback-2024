using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using DSharpPlus;

// following https://github.com/NaamloosDT/DSharpPlus/wiki/Making-your-first-bot-in-C%23
// https://github.com/DSharpPlus/DSharpPlus
// new token: discord token MzAzNzQ5MjI4NTgzMzIxNjAy.GE_86x.MgDthR7xIaNY66FNaRUiUwbLeUSujstevNJZgM

namespace lambhootDiscordBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("_LambHoot Twitter Bot v1.4 Full nGram_");

            // follow this guide:
            // https://dsharpplus.github.io/DSharpPlus/articles/basics/bot_account.html

            //Console.WriteLine("_Discord Bot_");
            //MyBot lambhootBot = new MyBot();

            ////PartialBiGram bot = new PartialBiGram("C:\\Users\\Denis\\Documents\\Visual Studio 2015\\Projects\\lambhootDiscordBot\\twitter\\shakespeare.txt");
            ////PartialBiGram bot = new PartialBiGram("C:\\Users\\Denis\\Documents\\Visual Studio 2015\\Projects\\lambhootDiscordBot\\twitter\\LH_Scripts.txt");
            //PartialBiGram bot = new PartialBiGram("myLog.txt");
            //Console.WriteLine(bot.generateNewBiGramSentence());

            DiscordBot discordBot = new DiscordBot();
            await discordBot.Main();

            //string sentence, biggramsentence;
            //var vocab = bot.vocabulary;

            /*
            String sentence = bot.generateNewSentence();
            Console.WriteLine(sentence);
            Console.WriteLine(bot.generateNewSentence());
            Console.WriteLine(bot.generateNewBiGramSentence());
            */
        
            

            //var x = 3;



            //Console.WriteLine("_Partial BiGram_");
            //PartialBiGram myPartialBiGram = new PartialBiGram();
            //Console.WriteLine("_vocab done_");

            //Word the = myPartialBiGram.vocabulary["the"];
            //Word letter = myPartialBiGram.vocabulary["letter"];
            //Word seven = myPartialBiGram.vocabulary["7/10."];
            //Word game = myPartialBiGram.vocabulary["game"];
            //Word same = myPartialBiGram.vocabulary["same"];

            //List<Word> sentence = new List<Word>();
            //sentence.Add(the);
            //var low = letter.probabilityGivenSentence(sentence);
            //var high = game.probabilityGivenSentence(sentence);
            //var high2 = same.probabilityGivenSentence(sentence);
            //var idk = the.probabilityGivenSentence(sentence);

            //sentence.Add(letter);
            //var low2 = seven.probabilityGivenSentence(sentence);

            //var a = letter.ProbabilityOfWordgivenB(the, 0);
            //var b = seven.ProbabilityOfWordgivenB(the, 1);
            //var c = game.ProbabilityOfWordgivenB(the, 0);
            //var d = same.ProbabilityOfWordgivenB(the, 0);
            //var e = the.ProbabilityOfWordgivenB(the, 0);

            //string s0 = myPartialBiGram.generateNewSentence("the");
            //Console.WriteLine("_____");
            //string s00 = myPartialBiGram.generateNewSentence("the");
            //Console.WriteLine("_____");
            //string s1 = myPartialBiGram.generateNewSentence("holy");
            //Console.WriteLine("_____");
            //string s2 = myPartialBiGram.generateNewSentence("astrology is");
            //Console.WriteLine("_____");
            //string s3 = myPartialBiGram.generateNewSentence("Denis is");
            //Console.WriteLine("_____");
            //string s4 = myPartialBiGram.generateNewSentence("applesauce");
            //Console.WriteLine("_____");
            //string s5 = myPartialBiGram.generateNewSentence();
            //Console.WriteLine("_____");
            //string s6 = myPartialBiGram.generateNewSentence();
            //Console.WriteLine("_____");
            //string s7 = myPartialBiGram.generateNewSentence();

            //var x = 0;

        }

    }
}