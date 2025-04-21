using CurrencySequenceHandler;
using CurrencySequenceHandler.Services;
using CurrencySequenceHandler.UI;

class Program
{
    static void Main()
    {
        SentenceHandlerApp handlerApp = new SentenceHandlerApp();
        handlerApp.Run();
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
