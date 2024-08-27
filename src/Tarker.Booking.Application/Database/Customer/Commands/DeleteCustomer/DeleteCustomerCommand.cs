using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand: IDeleteCustomerCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        public DeleteCustomerCommand(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<bool> Execute(int customerId)
        {
            var entity = await _databaseService.Customer
                .FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (entity == null) return false;

            _databaseService.Customer.Remove(entity);
            return await _databaseService.SaveAsync();
        }
    }
}
