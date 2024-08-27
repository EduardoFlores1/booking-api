namespace Tarker.Booking.Application.Database.Bookings.Queries.GetAllBooking
{
    public interface IGetAllBookingQuery
    {
        Task<List<GetAllBookingModel>> Execute();
    }
}
