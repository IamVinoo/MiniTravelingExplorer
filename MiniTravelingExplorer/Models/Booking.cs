using System;
using MiniTravelingExplorer.Utils;

namespace MiniTravelingExplorer.Models
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
        public string NumberOfTicketLabel
        {
            get => (NumberOfTicket.ToString().Length == 1) ? Constant.NUMBER_OF_TICKET_LABEL : string.Concat(Constant.NUMBER_OF_TICKET_LABEL, Constant.S_CHARACTER.ToLower());
            set
            {
                NumberOfTicketLabel = value;
            }
        }
        public string NumberOfTicketDisplay
        {
            get => (NumberOfTicket.ToString().Length == 1) ? string.Concat("0", NumberOfTicket.ToString()) : NumberOfTicket.ToString();
            set
            {
                NumberOfTicketDisplay = value;
            }
        }
        public string CardNumber { get; set; }
        public bool TripStatus { get; set; }
    }
}