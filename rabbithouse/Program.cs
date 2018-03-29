using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace rabbithouse
{
    class Program
    {
        static string token = Environment.GetEnvironmentVariable("TelegramCoffee"); 
        private static readonly TelegramBotClient Bot = new TelegramBotClient(token);

        static void Main(string[] args)
        {
            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var coffee = "現在準備中です。";

            Console.WriteLine(e.Message.Text);

            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
            {
                if (e.Message.Text == "/coffee")
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id,coffee);
                }
                else if (e.Message.Text == "/coffee@rabbit_house_bot")
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, coffee);
                }
            }
            
        }
    }
}
