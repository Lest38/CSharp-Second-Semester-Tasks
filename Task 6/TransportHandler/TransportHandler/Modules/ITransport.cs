namespace TransportHandler.Modules
{
    /// <summary>
    /// Interface representing a transport entity.
    /// </summary>
    public interface ITransport
    {
        int RouteNumber { get; }
        int AvailableSeats { get; }
        string Departure { get; set; }
        string Destination { get; set; }
        string TransportType { get; }

        /// <summary>
        /// Displays information about the transport entity.
        /// </summary>
        void DisplayInfo();
        int this[string seatType] { get; }
    }
}