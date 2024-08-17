using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;

namespace TelegramChatBot
{
    class Program
    {
        private static string BotToken = "7544879053:AAHolEOTS7k4FUgeJstpdlNHEeJB_997rYE";
        private static TelegramBotClient botClient;

        static async Task Main(string[] args)
        {
            botClient = new TelegramBotClient(BotToken);
            botClient.StartReceiving(
                async (botClient, update, cancellationToken) =>
                {
                    if (update.Message?.Text == "/start")
                    {
                        await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Hello");
                    }
                },
                async (botClient, exception, cancellationToken) =>
                {
                    Console.WriteLine(exception.Message);
                }
                
                );
            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Bot is running.");
            Console.ReadKey();
        }
    }
}
