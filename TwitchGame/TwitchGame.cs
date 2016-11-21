using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchGame.Utility;
using TwitchSharp;
using TwitchSharp.EventArguments;

namespace TwitchGame
{
    class TwitchGame
    {
        private TwitchChatBot Tcb;

        private bool EnableCommands = true;
        private String[] BallMessages = new string[]
        {
            @"It is certain",
            @"It is decidedly so",
            @"Without a doubt",
            @"Yes, definitely",
            @"You may rely on it",
            @"As I see it, yes",
            @"Most likely",
            @"Outlook good",
            @"Yes",
            @"Signs point to yes",

            @"Reply hazy try again",
            @"Ask again later",
            @"Better not tell you now",
            @"Cannot predict now",
            @"Concentrate and ask again",
            
            @"Don't count on it",
            @"My reply is no",
            @"My sources say no",
            @"Outlook not so good",
            @"Very doubtful"
        };


        public TwitchGame()
        {
            Tcb = new TwitchChatBot(@"censored", @"censored");
            // Add Events here!
            Tcb.MessageReceived += Tcb_MessageReceived;
            Tcb.LoginCompleted += (s, e) =>
            {
                Tcb.JoinChannel(@"maoubot");
                Tcb.JoinChannel(@"imthe666st");
                //Tcb.JoinChannel(@"javoxxib");
            };

            Tcb.ChannelJoined += (s, e) =>
            {
                //Tcb.SendChatMessage(e.Channel, @"Hello! I joined at {0} :)", DateTime.Now);
                //Tcb.SendChatMessage(Tcb.Nick, ".w imthe666st [JOIN] {0} :{1}", e.Channel, DateTime.Now);
            };

            Tcb.ChannelPart += (s, e) =>
            {
                //Tcb.SendChatMessage(e.Channel, @"Sorry to leave you! :(");
                //Tcb.SendChatMessage(Tcb.Nick, ".w imthe666st [PART] {0} :{1}", e.Channel, e.Reason);
            };

            // Run TwitchSharp Chatbot
            Tcb.Run();
        }

        private void Tcb_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            if (e.MessageType == MessageType.Server) Console.WriteLine(e.RawMessage);
            else if (e.MessageType == MessageType.Ping) Tcb.SendIrcMessage("PONG {0}", Tcb.HOST);
            else if (e.MessageType == MessageType.Chat)
            {
                Console.WriteLine("[{0}] {1}: {2}", e.Channel, e.Nick, e.Message);
                if (e.Message.StartsWith("!") && EnableCommands)
                {
                    String m = e.Message.Substring(1);
                    m.ToLower();
                    ExecuteCommand(e, m.Split(' '));
                }
            }
        }

        private uint crashes = 0;
        private void ExecuteCommand(MessageReceivedEventArgs e, String[] args)
        {
            Console.WriteLine("Executing Command {0}", args[0]);
            // Generate cString
            if (args[0] == "joinme" && e.Channel == Tcb.Nick)
            {
                Tcb.JoinChannel(e.Nick);
            } else if (args[0] == "leaveme" && (e.Channel == e.Nick || e.Nick == "imthe666st"))
            {
                Tcb.PartChannel("User requested");
            }
            else if (args[0] == "join" && args.Length > 1 && e.Nick == "imthe666st")
            {
                Tcb.JoinChannel(args[1]);
                Tcb.SendChatMessage("Joined {0}! :)", args[1]);
            }
            else if (args[0] == "8ball" && args.Length > 1)
            {
                String d = String.Empty;
                for (int i = 1; i < args.Length; i++)
                {
                    d += args[i];
                    if (i < args.Length - 1) d += " ";
                }

                // Create a hash
                String Msg = BallMessages[new Random().Next(BallMessages.Length)];
                Tcb.SendChatMessage("{0}: {1}", e.Nick, Msg);
                
            } else if (args[0] == "crash")
            {
                if (e.Nick == "imthe666st") crashes++;
                Tcb.SendChatMessage("{0}: We had {1} crashes today..", e.Nick, crashes);

            }
        }
    }
}
