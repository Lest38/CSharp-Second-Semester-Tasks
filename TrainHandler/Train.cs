using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainHandler
{
    class Train(int number, string departure, string destination, int[] seats)
    {
        private readonly int trainNumber = number;
        private string departure = departure;
        private string destination = destination;
        private int[] freeSeats = seats;

        public int TrainNumber => trainNumber;
        public string Destination => destination;
        public int TotalFreeSeats => freeSeats.Sum();

        public int this[int index] => freeSeats[index];

        public bool HasFreeSeats() => freeSeats.Any(seats => seats > 0);

        public override string ToString()
        {
            return $"Train №{trainNumber}, {departure} -> {destination}, Free seats: [{string.Join(", ", freeSeats)}]";
        }
    }
}