using System;

namespace MiniTravelingExplorer.Models
{
    public class User : UserDetail
    {
        public int UserId { get; set; }
        public bool IsActivated { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ActivationKey { get; set; }
        public string PasswordResetKey { get; set; }
        public bool IsLockedOut { get; set; }
        public int NoOfAttempt { get; set; }
        public DateTime LockedOutDateTime { get; set; }
        public int ChangeEmailCode { get; set; }
        public string ChangeEmailRequested { get; set; }
        public string SaltKey { get; set; }
    }
}