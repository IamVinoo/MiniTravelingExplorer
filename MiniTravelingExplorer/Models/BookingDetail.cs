using System;

namespace MiniTravelingExplorer.Models
{
    public class BookingDetail
    {
        public int LocationId { get; set; }
        public string Email { get; set; }
        public bool IsUserLoginEmail { get; set; }
        public string TicketNumber { get; set; }
        public int NumberOfTicket { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public DateTime TripDate { get; set; }
        public string PromoCode { get; set; }
        public int Rate { get; set; }
        public string Username { get; set; }
    }
}