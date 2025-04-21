using CurrencySequenceHandler;

class Program
{
    static void Main()
    {
        var handler = SetupHandler();
        RunInteractionLoop(handler);
    }

    static SentenceHandler SetupHandler()
    {
        var handler = new SentenceHandler(
            new SentenceExtractor(),
            new SentenceFilter(),
            new ReversedSentence()
        );

        handler.Subscribe(PrintToConsole);

        return handler;
    }

    static void RunInteractionLoop(SentenceHandler handler)
    {
        var initialText = "Here's $100. I have 200 руб. лрм ь kjh.";
        handler.ProcessSentences(initialText);

        while (true)
        {
            Console.WriteLine("Enter text (or 'exit'):");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty.");
                continue;
            }

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            handler.ProcessSentences(input);
        }
    }

    static void PrintToConsole(string message)
    {
        Console.WriteLine(message);
    }
}
