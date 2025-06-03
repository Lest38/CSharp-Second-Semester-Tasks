using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportHandler.Modules
{
    /// <summary>
    /// Abstract base class for ground transport entities.
    /// </summary>
    public abstract class GroundTransport : ITransport
    {
        public int RouteNumber { get; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string TransportType => GetType().Name;
        public virtual int AvailableSeats { get; protected set; }
        protected int[] TicketPrices = new int[4];

        /// <summary>
        /// Initializes a new instance of the GroundTransport class with specified route number, departure, destination, and seat price.
        /// </summary>
        /// <param name="routeNumber"></param>
        /// <param name="departure"></param>
        /// <param name="destination"></param>
        /// <param name="seatPrice"></param>
        protected GroundTransport(int routeNumber, string departure, string destination, int seatPrice)
        {
            RouteNumber = routeNumber;
            Departure = departure;
            Destination = destination;
            TicketPrices[0] = seatPrice;
        }

        /// <summary>
        /// Displays information about the transport entity.
        /// </summary>
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{TransportType} | Route: {RouteNumber} | From: {Departure} | To: {Destination} | Seats: {AvailableSeats}");
        }

        public abstract int this[string seatType] { get; }
    }

}
