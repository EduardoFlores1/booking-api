using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Bookings.Queries.GetAllBooking
{
    public class GetAllBookingQuery: IGetAllBookingQuery
    {
        private readonly IDatabaseService _databaseService;
        public GetAllBookingQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<GetAllBookingModel>> Execute()
        {
            var result = await (from booking in _databaseService.Booking
                                join customer in _databaseService.Customer
                                on booking.CustomerId equals customer.CustomerId
                                select new GetAllBookingModel { 
                                    BookingId = booking.BookingId,
                                    RegisterDate = booking.RegisterDate,
                                    Code = booking.Code,
                                    Type = booking.Type,
                                    CustomerFullName = customer.FullName,
                                    CustomerDocumentNumber = customer.DocumentNumber,
                                }).ToListAsync();
            return result;
        }
    }
}
