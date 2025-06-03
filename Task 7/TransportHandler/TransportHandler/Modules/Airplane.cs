using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportHandler.Modules
{
    /// <summary>
    /// Represents an airplane transport entity.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the Airplane class with specified route number, departure, destination, and available seats.
    /// </remarks>
    /// <param name="routeNumber"></param>
    /// <param name="departure"></param>
    /// <param name="destination"></param>
    /// <param name="seatsAvailable"></param>
    public class Airplane : ITransport
    {
        public int RouteNumber { get; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string TransportType => "Airplane";
        public int AvailableSeats { get; set; }

        private readonly int[] TicketPrices = { 200, 400, 800 };

        /// <summary>
        /// Creates a new instance of the Airplane class with specified route number, departure, destination, and available seats.
        /// </summary>
        /// <param name="routeNumber"></param>
        /// <param name="departure"></param>
        /// <param name="destination"></param>
        /// <param name="seatsAvailable"></param>
        public Airplane(int routeNumber, string departure, string destination, int seatsAvailable)
        {
            RouteNumber = routeNumber;
            Departure = departure;
            Destination = destination;
            AvailableSeats = seatsAvailable;
        }

        /// <summary>
        /// Displays information about the airplane transport entity.
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"{TransportType} | Route: {RouteNumber} | From: {Departure} | To: {Destination} | Seats: {AvailableSeats}");
        }

        /// <summary>
        /// Gets the ticket price based on the seat type.
        /// </summary>
        /// <param name="seatType"></param>
        /// <returns></returns>
        public int this[string seatType] => seatType.ToLower() switch
        {
            "economy" => TicketPrices[0],
            "business" => TicketPrices[1],
            "first" => TicketPrices[2],
            _ => -1
        };
    }

}
