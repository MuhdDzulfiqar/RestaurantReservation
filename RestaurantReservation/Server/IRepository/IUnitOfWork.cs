using RestaurantReservation.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Promotion> Promotions { get; }
        IGenericRepository<Reservation> Reservations { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Review> Reviews { get; }
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Restaurant> Restaurants { get; }
    }
}