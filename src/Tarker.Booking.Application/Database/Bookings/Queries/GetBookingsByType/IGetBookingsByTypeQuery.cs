namespace Tarker.Booking.Application.Database.Bookings.Queries.GetBookingsByType
{
    public interface IGetBookingsByTypeQuery
    {
        Task<List<GetBookingsByTypeModel>> Execute(string type);
    }
}
