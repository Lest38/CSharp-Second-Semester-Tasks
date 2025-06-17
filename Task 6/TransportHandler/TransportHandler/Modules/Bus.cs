using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportHandler.Modules
{
    /// <summary>
    /// Represents a bus transport entity.
    /// </summary>
    public class Bus : GroundTransport
    {
        private readonly int[] seatsPerCar = [10, 20, 30, 40];
        private readonly int[] TicketPrices = [300, 100];
        /// <summary>
        /// Creates a new instance of the Bus class.
        /// </summary>
        /// <param name="routeNumber"></param>
        /// <param name="departure"></param>
        /// <param name="destination"></param>
        /// <param name="seatPrice"></param>
        /// <param name="seatsNum"></param>
        public Bus(int routeNumber, string departure, string destination, int seatPrice, int seatsNum = 50)
            : base(routeNumber, departure, destination, seatPrice)
        {
            AvailableSeats = seatsPerCar.Sum();
        }

        /// <summary>
        /// Gets the ticket price based on the seat type.
        /// </summary>
        /// <param name="seatType"></param>
        /// <returns></returns>
        public override int this[string seatType] => seatType.ToLower() switch
        {
            "soft" => TicketPrices[0],
            "hard" => TicketPrices[1],
            _ => -1
        };
    }

}
