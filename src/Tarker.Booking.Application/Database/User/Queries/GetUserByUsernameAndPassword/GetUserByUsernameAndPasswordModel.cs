namespace Tarker.Booking.Application.Database.User.Queries.GetUserByUsernameAndPassword
{
    public class GetUserByUsernameAndPasswordModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
