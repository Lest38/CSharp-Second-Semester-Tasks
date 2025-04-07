using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainHandler
{
    class TrainManager
    {
        private List<Train> trains = [];

        public void AddTrain(Train train)
        {
            trains.Add(train);
        }

        public void DisplayTrainsDescending()
        {
            foreach (var train in trains.OrderByDescending(t => t.TrainNumber))
            {
                Console.WriteLine(train);
            }
        }

        public void DisplayTotalFreeSeatsByDestination()
        {
            var grouped = trains.GroupBy(t => t.Destination)
                                .Select(g => new { Destination = g.Key, TotalSeats = g.Sum(t => t.TotalFreeSeats) });

            foreach (var group in grouped)
            {
                Console.WriteLine($"Destination: {group.Destination}, Total free seats: {group.TotalSeats}");
            }
        }

        public void DisplayTrainsWithoutSeats(string city)
        {
            var noSeatsTrains = trains.Where(t => t.Destination == city && !t.HasFreeSeats()).ToList();

            if (noSeatsTrains.Count > 0)
            {
                Console.WriteLine($"Trains to {city} without free seats:");
                foreach (var train in noSeatsTrains)
                {
                    Console.WriteLine(train);
                }
            }
            else
            {
                Console.WriteLine($"No trains to {city} without free seats.");
            }
        }
    }
}
