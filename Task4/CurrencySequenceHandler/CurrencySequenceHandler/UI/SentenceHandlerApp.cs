using CurrencySequenceHandler.Services;
using System;

namespace CurrencySequenceHandler.UI
{
    public class SentenceHandlerApp
    {
        private readonly SentenceHandler _handler;

        public SentenceHandlerApp()
        {
            _handler = SetupHandler();
        }

        private SentenceHandler SetupHandler()
        {
            var handler = new SentenceHandler(
                new SentenceExtractor(),
                new SentenceFilter(),
                new ReversedSentence()
            );

            handler.Subscribe(PrintToConsole);

            return handler;
        }

        private void RunInteractionLoop()
        {
            var initialText = "Here's $100. I have 200 руб. лрм ь kjh.";
            _handler.ProcessSentences(initialText);

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

                _handler.ProcessSentences(input);
            }
        }

        private void PrintToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void Run()
        {
            RunInteractionLoop();
        }
    }
}
