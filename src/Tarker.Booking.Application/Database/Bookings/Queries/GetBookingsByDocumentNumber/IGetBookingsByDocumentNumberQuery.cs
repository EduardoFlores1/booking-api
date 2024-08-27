namespace Tarker.Booking.Application.Database.Bookings.Queries.GetBookingByDocumentNumber
{
    public interface IGetBookingsByDocumentNumberQuery
    {
        Task<List<GetBookingsByDocumentNumberModel>> Execute(string documentNumber);
    }
}
