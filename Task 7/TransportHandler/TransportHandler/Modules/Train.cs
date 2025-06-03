using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportHandler.Modules
{
    /// <summary>
    /// Represents a train transport entity.
    /// </summary>
    public class Train : GroundTransport
    {
        private readonly int[] seatsPerCar = [10, 20, 30, 40];

        /// <summary>
        /// Creates a new instance of the Train class.
        /// </summary>
        /// <param name="routeNumber"></param>
        /// <param name="departure"></param>
        /// <param name="destination"></param>
        /// <param name="basePrice"></param>
        public Train(int routeNumber, string departure, string destination, int basePrice)
            : base(routeNumber, departure, destination, basePrice)
        {
            TicketPrices = [700, 500, 300, 100];
            AvailableSeats = seatsPerCar.Sum();
        }

        /// <summary>
        /// Gets the ticket price based on the seat type.
        /// </summary>
        /// <param name="seatType"></param>
        /// <returns></returns>
        public override int this[string seatType] => seatType.ToLower() switch
        {
            "luxury" => TicketPrices[0],
            "coupe" => TicketPrices[1],
            "reserved" => TicketPrices[2],
            "common" => TicketPrices[3],
            _ => -1
        };
    }

}
