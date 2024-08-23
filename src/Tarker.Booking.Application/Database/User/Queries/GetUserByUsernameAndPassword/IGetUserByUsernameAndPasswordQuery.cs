namespace Tarker.Booking.Application.Database.User.Queries.GetUserByUsernameAndPassword
{
    public interface IGetUserByUsernameAndPasswordQuery
    {
        Task<GetUserByUsernameAndPasswordModel> Execute(string username, string password);
    }
}
