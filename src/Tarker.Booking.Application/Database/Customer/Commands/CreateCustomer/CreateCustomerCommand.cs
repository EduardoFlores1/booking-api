using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand: ICreateCustomerCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<CreateCustomerModel> Execute(CreateCustomerModel model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);
            await _databaseService.Customer.AddAsync(entity);
            await _databaseService.SaveAsync();
            return model;
        }
    }
}
