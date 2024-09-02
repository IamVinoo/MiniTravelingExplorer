using System;

namespace MiniTravelingExplorer.EntityModel
{
    public class User : UserDetail
    {
        public int UserId { get; set; }
        public string SaltKey { get; set; }
        public string Password { get; set; }
        public bool IsActivated { get; set; }
        public bool IsLockedOut { get; set; }
        public int NumberOfAttempt { get; set; }
        public DateTime ActivatedDate { get; set; }
        public DateTime LockedOutDateTime { get; set; }
    }
}