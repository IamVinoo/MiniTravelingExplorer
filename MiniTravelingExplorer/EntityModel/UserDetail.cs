namespace MiniTravelingExplorer.EntityModel
{
    public class UserDetail : SecurityQuestions
    {
        public int UserDetailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public string SecurityAnswer { get; set; }
        public string Gender { get; set; }
        public byte[] UserPhoto { get; set; }
        public string UserPhotoName { get; set; }
        public string UserPhotoType { get; set; }

    }
}