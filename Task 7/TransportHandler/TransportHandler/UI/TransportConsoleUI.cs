using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportHandler.Modules;

namespace TransportHandler.UI
{
    /// <summary>
    /// Console UI renderer using Spectre.Console.
    /// </summary>
    public static class TransportConsoleUI
    {
        /// <summary>
        /// Displays transport data using a styled Spectre.Console table.
        /// </summary>
        public static void DisplayTransportTable(List<ITransport> transports)
        {
            var table = new Table();

            table.Border(TableBorder.Rounded);
            table.AddColumn("Transport Type");
            table.AddColumn("Route");
            table.AddColumn("From");
            table.AddColumn("To");
            table.AddColumn("Available Seats");

            foreach (var t in transports)
            {
                var color = t.AvailableSeats == 0 ? "red" : "green";

                table.AddRow(
                    new Markup(t.TransportType),
                    new Markup(t.RouteNumber.ToString()),
                    new Markup(t.Departure),
                    new Markup(t.Destination),
                    new Markup($"[{color}]{t.AvailableSeats}[/]")
                );
            }

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Displays sample ticket prices for the given transport type and seat type.
        /// </summary>
        public static void DisplayTicketPrice(List<ITransport> transports, string transportType, string seatType)
        {
            AnsiConsole.MarkupLine($"\n[bold]Ticket price for [yellow]{transportType}[/] class '{seatType}':[/]");

            bool found = false;
            foreach (var t in transports)
            {
                if (t.TransportType.Equals(transportType, StringComparison.OrdinalIgnoreCase))
                {
                    AnsiConsole.MarkupLine($"{t.RouteNumber}: [green]{t[seatType]}[/] $");
                    found = true;
                }
            }

            if (!found)
            {
                AnsiConsole.MarkupLine($"[red]No {transportType} found.[/]");
            }
        }
    }

}
