namespace MiniTravelingExplorer.Models
{
    public class AddChecklistItem
    {
        public int ChecklistId { get; set; }
        public int ChecklistItemId { get; set; }
        public string ChecklistItemName { get; set; }
        public int BookingId { get; set; }
        public bool IsChecked { get; set; }
    }
}