using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp;
using TwitchSharp.EventArguments;

namespace KubaBot
{
    class Program
    {
        private static TwitchChatBot Tcb;
        private static Random random;

        private static String[] BallMessages = new string[]
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

        private static String[] SlotMachineMessages = new string[]
        {
            @"Kappa",
            @"PogChamp",
            @"WutFace",
            @"FrankerZ",
            @"OhMyDog",
            @"4Head",
            @"TwitchRPG"
        };

        private static UInt16 Butts = 0x0020;
		private static bool EnableButtsBot = false;
        static void Main(string[] args)
        {
            // init
            random = new Random();


            // stuff
            Tcb = new TwitchChatBot("censored", "censored");
            Tcb.LoginCompleted += (s, e) =>
            {
                Tcb.JoinChannel("powerpeet");
            };
            Tcb.MessageReceived += Tcb_MessageReceived;
            Tcb.CommandExecute += Tcb_ExecuteCommand;
            //Tcb.ChannelJoined += (s, e) =>
            //{
            //    Tcb.SendChatMessage(e.Channel, "Hey #{0} 4Head", e.Channel);
            //};
            //Tcb.ChannelPart += (s, e) =>
            //{
            //    Tcb.SendChatMessage(e.Channel, "Bye #{0} 4Head", e.Channel);
            //};



            Tcb.Run();
        }

        private static void Tcb_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            if (e.MessageType == MessageType.Server) Console.WriteLine(e.RawMessage);
            else if (e.MessageType == MessageType.Ping) Tcb.SendIrcMessage("PONG {0}", Tcb.HOST);
            else if (e.MessageType == MessageType.Chat)
            {
                Console.WriteLine("[{0}] {1}: {2}", e.Channel, e.Nick, e.Message);
                if (e.Message.StartsWith("q!") && e.Nick == "imthe666st")
                {
                    String m = e.Message.Substring(3);
                    Tcb.SendEscapedChatMessage(m);
                } else if (EnableButtsBot && e.Message[0] != Tcb.CommandChar)
                {
                    UInt16 r = 0;
                    List<String> msg = e.Message.Split(' ').ToList();
                    List<String> bMsg = new List<string>();
                    bool butt = false;
                    foreach (String a in msg)
                    { 
                        r = (UInt16) random.Next(0xFFFF);
                        Console.Write("{0:X4}\t", r);
                        if (r <= Butts)
                        {
                            bMsg.Add("butt");
                            butt = true;
                        } else
                        {
                            bMsg.Add(a);
                        }
                    }
                    Console.WriteLine("{0} -> {1}", butt, String.Join(" ", bMsg));
                    if (butt) Tcb.SendChatMessage(String.Join(" ", bMsg));
                }
            }
        }

        private static uint KubaCounter = 1;
        private static void Tcb_ExecuteCommand(object sender, CommandExecuteEventArgs e)
        {
            Console.WriteLine("Executing Command {0}", e.Command);

            if (e.Command == "pls" && e.CommandArgs.Length > 0)
            {
                Tcb.SendChatMessage("{0} pls.. ._.)", e.cArgs);
            } else if (e.Command == "kuba")
            {
                Tcb.SendChatMessage("Kuba pls... ._.) [{0}]", KubaCounter.ToString());
                KubaCounter++;
            } else if (e.Command == "picnic")
            {
                Tcb.SendChatMessage("panicBasket STREAM RIP panicBasket");
            } else if (e.Command == "debug" && e.Nick == "imthe666st")
            {
                Tcb.SendEscapedChatMessage("{0} | {1} | {2} | {3} | {4}", System.DateTime.Now, e.Nick, e.Channel, e.Command, e.cArgs);
            } else if (e.Command == "8ball")
            {
                int r = random.Next(BallMessages.Length);
                Tcb.SendChatMessage("{0}: {1}", e.Nick, BallMessages[r]);
            } else if (e.Command == "lotto")
            {
                List<byte> z = new List<byte>();

                do
                {
                    byte k = (byte)(random.Next(49) + 1);
                    if (!z.Contains(k)) z.Add(k);
                } while (z.Count < 6);

                // Sort z
                z.Sort();

                Tcb.SendChatMessage("{0}: Your lotto numbers: {1} {2} {3} {4} {5} {6} FrankerZ", e.Nick, z[0], z[1], z[2], z[3], z[4], z[5]);
            } else if (e.Command == "slots")
            {
                String[] Slots = new string[] {
                    SlotMachineMessages[random.Next(SlotMachineMessages.Length)],
                    SlotMachineMessages[random.Next(SlotMachineMessages.Length)],
                    SlotMachineMessages[random.Next(SlotMachineMessages.Length)]
                };

                if (Slots[0] == Slots[1] && Slots[1] == Slots[2])
                {
                    Tcb.SendChatMessage("{0}: You rolled {1} {2} {3} You won!", e.Nick, Slots[0], Slots[1], Slots[2]);
                    return;
                }
                else if (Slots[0] == Slots[1] || Slots[1] == Slots[2] || Slots[0] == Slots[2])
                {
                    Tcb.SendChatMessage("{0}: You rolled {1} {2} {3} So close!", e.Nick, Slots[0], Slots[1], Slots[2]);
                    return;
                }
                else
                {
                    Tcb.SendChatMessage("{0}: You rolled {1} {2} {3} Not even close...", e.Nick, Slots[0], Slots[1], Slots[2]);
                    return;

                }
            } else if (e.Command == "flipacoin")
			{
				bool coin = random.Next(1) == 0;
				Tcb.SendChatMessage("{0}: The magic coin says: {1}", e.Nick, coin ? "Heads" : "Tails");
			}
        }
    }
}
