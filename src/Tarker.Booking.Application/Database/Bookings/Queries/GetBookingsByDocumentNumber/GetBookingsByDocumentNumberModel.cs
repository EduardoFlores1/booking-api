namespace Tarker.Booking.Application.Database.Bookings.Queries.GetBookingByDocumentNumber
{
    public class GetBookingsByDocumentNumberModel
    {
        public int BookingId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
    }
}
