using DictionaryCore;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramDictionary;

static class Program
{
	private static StringsDictionary _dictionary;
	static async Task Main(string[] args)
	{
		var datafile = new FileReader().ReadLines();
		_dictionary = new StringsDictionary(10);
		_dictionary.Fill(datafile,_dictionary);
		var token = Environment.GetEnvironmentVariable("accessToken");
		Console.WriteLine(token);
		var botClient = new TelegramBotClient(token);
		var me = await botClient.GetMeAsync();
		Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

		using var cts = new CancellationTokenSource();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
		var receiverOptions = new ReceiverOptions
		{
			AllowedUpdates = { } // receive all update types
		};
		botClient.StartReceiving(
			HandleUpdateAsync,
			HandleErrorAsync,
			receiverOptions,
			cancellationToken: cts.Token);

		Console.WriteLine($"Start listening for @{me.Username}");
		Console.ReadLine();

// Send cancellation request to stop bot
		cts.Cancel();
	}
	public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
	{
		// Only process Message updates: https://core.telegram.org/bots/api#message
		if (update.Type != UpdateType.Message)
			return;
		// Only process text messages
		if (update.Message!.Type != MessageType.Text)
			return;
			
		var chatId = update.Message.Chat.Id;
		var request = update.Message.Text;
		var definition = _dictionary.Get(request.ToUpper());
		var answerText = definition ?? "Not found";
			
		Console.WriteLine($"Received a '{answerText}' message in chat {chatId}.");

		// Echo received message text
		Message sentMessage = await botClient.SendTextMessageAsync(
			chatId: chatId,
			text: "def:\n" + answerText,
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

		Console.WriteLine(ErrorMessage);
		return Task.CompletedTask;
	}
}