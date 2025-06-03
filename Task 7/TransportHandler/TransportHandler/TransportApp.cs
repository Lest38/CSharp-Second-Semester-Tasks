using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportHandler.Modules;

namespace TransportHandler
{
    /// <summary>
    /// Main application class for managing transport entities.
    /// </summary>
    public class TransportApp
    {
        private const string FilePath = @"D://transport.txt";
        private List<ITransport> transports = [];

        /// <summary>
        /// Initializes a new instance of the TransportApp class.
        /// </summary>
        public void Run()
        {
            LoadTransports();
            DisplayAllTransportInfo();
            DisplaySampleTicketPrice("Airplane", "business");
        }

        /// <summary>
        /// Loads transport entities from a file.
        /// </summary>
        private void LoadTransports()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine($"File not found: {FilePath}");
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
            if (transports.Count == 0)
            {
                Console.WriteLine("No transports found in the file.");
            }
            else
            {
                Console.WriteLine($"{transports.Count} transport(s) loaded successfully.");
            }
        }

        /// <summary>
        /// Displays information about all transport entities.
        /// </summary>
        private void DisplayAllTransportInfo()
        {
            Console.WriteLine("Transport Information:\n");

            foreach (var transport in transports)
            {
                if (transport.AvailableSeats == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                transport.DisplayInfo();
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Displays a sample ticket price for a specific transport type and seat type.
        /// </summary>
        /// <param name="transportType"></param>
        /// <param name="seatType"></param>
        private void DisplaySampleTicketPrice(string transportType, string seatType)
        {
            Console.WriteLine($"\nTicket price for {transportType} class:");

            foreach (var transport in transports)
            {
                if (transport.TransportType.Equals(transportType, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine(transport[seatType]);
                }
            }
        }
    }
}
