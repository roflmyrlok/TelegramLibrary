using DictionaryCore;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramDictionary;

static class Program
{
    private static StringsDictionary _dictionary;
    private static Dictionary<long, bool> _activeUsers = new();
    
    static async Task Main(string[] args)
    {
        try
        {
            var datafile = new FileReader().ReadLines();
            _dictionary = new StringsDictionary(10);
            _dictionary.Fill(datafile, _dictionary);
            
            var solutionFolder = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", ".."); //.env in solution folder
            Directory.SetCurrentDirectory(solutionFolder); 
            dotenv.net.DotEnv.Load();
            Console.WriteLine(solutionFolder);
            var token = Environment.GetEnvironmentVariable("ACCESSTOKEN");
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Bot token not found in environment variables!");
            }
            
            var botClient = new TelegramBotClient(token);
            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Bot started: @{me.Username}");

            using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>(), // receive all update types
            };

            botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);

            Console.WriteLine("Press Ctrl+C to exit");
            await Task.Delay(-1, cts.Token); // Keep the bot running until cancelled
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
            Environment.Exit(1);
        }
    }

    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        try
        {
            if (update.Message is not { } message)
                return;
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;
            Console.WriteLine($"Received message from {chatId}: {messageText}");

            switch (messageText.ToLower())
            {
                case "/start":
                    await HandleStartCommand(botClient, chatId, message.From?.FirstName, cancellationToken);
                    break;
                
                case "/end":
                    await HandleEndCommand(botClient, chatId, cancellationToken);
                    break;
                
                case "/help":
                    await HandleHelpCommand(botClient, chatId, cancellationToken);
                    break;
                
                default:
                    if (_activeUsers.TryGetValue(chatId, out bool isActive) && isActive)
                    {
                        await HandleDictionaryRequest(botClient, chatId, messageText, cancellationToken);
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(
                            chatId: chatId,
                            text: "Please use /start to begin using the dictionary bot.",
                            cancellationToken: cancellationToken);
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error handling update: {ex.Message}");
        }
    }

    private static async Task HandleStartCommand(ITelegramBotClient botClient, long chatId, string? userName, CancellationToken cancellationToken)
    {
        _activeUsers[chatId] = true;
        
        var keyboard = new ReplyKeyboardMarkup(new[]
        {
            new[] { new KeyboardButton("/help"), new KeyboardButton("/end") },
        })
        {
            ResizeKeyboard = true
        };

        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"👋 Welcome{(string.IsNullOrEmpty(userName) ? "!" : $", {userName}!")}\n" +
                  "I'm your Dictionary Bot. Send me any word, and I'll look up its definition.\n" +
                  "Use /help to see available commands.",
            replyMarkup: keyboard,
            cancellationToken: cancellationToken);
    }

    private static async Task HandleEndCommand(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
    {
        _activeUsers[chatId] = false;
        
        var removeKeyboard = new ReplyKeyboardRemove();
        
        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Session ended. Use /start to begin a new session.",
            replyMarkup: removeKeyboard,
            cancellationToken: cancellationToken);
    }

    private static async Task HandleHelpCommand(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
    {
        var helpText = "Available commands:\n" +
                      "/start - Start using the dictionary\n" +
                      "/end - End your session\n" +
                      "/help - Show this help message\n\n" +
                      "Simply type any word to get its definition!";

        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: helpText,
            cancellationToken: cancellationToken);
    }

    private static async Task HandleDictionaryRequest(ITelegramBotClient botClient, long chatId, string word, CancellationToken cancellationToken)
    {
        var definition = _dictionary.Get(word.ToUpper());
        var responseText = definition != null 
            ? $"📚 Definition of '{word}':\n\n{definition}"
            : $"❌ Sorry, I couldn't find a definition for '{word}'";

        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: responseText,
            cancellationToken: cancellationToken);
    }

    public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine($"Error: {ErrorMessage}");
        return Task.CompletedTask;
    }
}