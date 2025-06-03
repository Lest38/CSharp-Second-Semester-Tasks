using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using TransportHandler.Modules;
using TransportHandler.UI;

namespace TransportHandler.Core
{
    
    /// <summary>
    /// Main application logic.
    /// </summary>
    public class TransportApp
    {
        private const string FilePath = @"D://transport.txt";
        private readonly List<ITransport> transports = new();

        public void Run()
        {
            LoadTransports();
            TransportConsoleUI.DisplayTransportTable(transports);
            TransportConsoleUI.DisplayTicketPrice(transports, "Airplane", "business");
        }

        private void LoadTransports()
        {
            if (!File.Exists(FilePath))
            {
                AnsiConsole.MarkupLine($"[red]File not found: {FilePath}[/]");
                return;
            }

            foreach (var line in File.ReadLines(FilePath))
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 5) continue;

                string type = parts[0];
                int route = int.Parse(parts[1]);
                string from = parts[2];
                string to = parts[3];
                int price = int.Parse(parts[4]);

                ITransport transport = type switch
                {
                    "Autobus" => new Bus(route, from, to, price),
                    "Airplane" => new Airplane(route, from, to, price),
                    "Train" => new Train(route, from, to, price),
                    _ => null
                };

                if (transport != null)
                {
                    transports.Add(transport);
                }
            }

            AnsiConsole.MarkupLine($"[blue]{transports.Count} transport(s) loaded successfully.[/]");
        }
    }
}
