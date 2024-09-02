using System;

namespace MiniTravelingExplorer.EntityModel
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string TicketNumber { get; set; }
        public string LocationName { get; set; }
        public int NumberOfTicket { get; set; }
        public DateTime TripDate { get; set; }
        public string Amount { get; set; }
        public string BookedBy { get; set; }
        public string BookingEmail { get; set; }
        public string LocationImageUrl { get; set; }
        public int LocationId { get; set; }
        public string CardNumber { get; set; }
        public bool TripStatus { get; set; }
    }
}