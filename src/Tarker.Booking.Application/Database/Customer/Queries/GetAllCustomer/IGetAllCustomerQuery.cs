using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomer
{
    public interface IGetAllCustomerQuery
    {
        Task<List<GetAllCustomerModel>> Execute();
    }
}
