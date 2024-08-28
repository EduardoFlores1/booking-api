using Tarker.Booking.Api;
using Tarker.Booking.Application;
using Tarker.Booking.Application.Database.Bookings.Commands.CreateBooking;
using Tarker.Booking.Application.Database.Bookings.Queries.GetAllBooking;
using Tarker.Booking.Application.Database.Bookings.Queries.GetBookingByDocumentNumber;
using Tarker.Booking.Application.Database.Bookings.Queries.GetBookingsByType;
using Tarker.Booking.Common;
using Tarker.Booking.Domain.Enums;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
