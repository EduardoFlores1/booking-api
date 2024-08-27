using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Bookings.Queries.GetBookingByDocumentNumber
{
    public class GetBookingsByDocumentNumberQuery: IGetBookingsByDocumentNumberQuery
    {
        private readonly IDatabaseService _databaseService;
        public GetBookingsByDocumentNumberQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<GetBookingsByDocumentNumberModel>> Execute(string documentNumber)
        {
            var result = await (from booking in _databaseService.Booking
                          join customer in _databaseService.Customer
                          on booking.CustomerId equals customer.CustomerId
                          where customer.DocumentNumber == documentNumber
                          select new GetBookingsByDocumentNumberModel
                          {
                              BookingId = booking.BookingId,
                              RegisterDate = booking.RegisterDate,
                              Code = booking.Code,
                              Type = booking.Type,

                          }).ToListAsync();
            return result;
        }
    }
}
