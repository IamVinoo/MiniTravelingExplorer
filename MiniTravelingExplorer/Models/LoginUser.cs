namespace MiniTravelingExplorer.Models
{
    public class LoginUser: BaseModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ActivationKey { get; set; }
        public string PasswordResetKey { get; set; }
    }
}