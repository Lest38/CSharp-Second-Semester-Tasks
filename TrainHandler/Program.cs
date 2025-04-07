namespace TrainHandler
{
    class Program
    {
        static void Main()
        {
            TrainManager manager = new();
            int trainCount = GetTrainCount() ?? 0;

            for (int i = 0; i < trainCount; i++)
            {
                Train train = CreateTrain();
                manager.AddTrain(train);
            }

            Console.WriteLine("\nList of trains descending:");
            manager.DisplayTrainsDescending();

            Console.WriteLine("\nNumber of free seats by destination: ");
            manager.DisplayTotalFreeSeatsByDestination();

            Console.Write("\nEnter destination to search for trains without free seats: ");
            string searchCity = Console.ReadLine() ?? string.Empty;
            manager.DisplayTrainsWithoutSeats(searchCity);
        }

        static int? GetTrainCount()
        {
            Console.Write("Enter the number of trains: ");
            return int.TryParse(Console.ReadLine(), out int count) ? (int?)count : null;
        }

        static Train CreateTrain()
        {
            Console.Write("Train number: ");
            int number = int.TryParse(Console.ReadLine(), out int n) ? n : throw new ArgumentException("Wrong train number");
            Console.Write("Departure station: ");
            string departure = Console.ReadLine() ?? throw new ArgumentException("Departure station can't be null");
            Console.Write("Destination station: ");
            string destination = Console.ReadLine() ?? throw new ArgumentException("Destination station can't be null");
            Console.Write("Enter the number of carriages: ");
            int wagonCount = int.TryParse(Console.ReadLine(), out int wc) ? wc : throw new ArgumentException("Wrong number of carriages");
            int[] seats = new int[wagonCount];
            for (int j = 0; j < wagonCount; j++)
            {
                Console.Write($"Free seats in carriage {j + 1}: ");
                seats[j] = int.TryParse(Console.ReadLine(), out int s) ? s : throw new ArgumentException("Wrong number of seats");
            }
            return new Train(number, departure, destination, seats);
        }
    }

}