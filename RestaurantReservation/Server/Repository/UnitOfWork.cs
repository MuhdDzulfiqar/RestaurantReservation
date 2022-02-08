using RestaurantReservation.Server.Data;
using RestaurantReservation.Server.IRepository;
using RestaurantReservation.Server.Models;
using RestaurantReservation.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantReservation.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Category> _categories;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Promotion> _promotions;
        private IGenericRepository<Reservation> _reservations;
        private IGenericRepository<Restaurant> _restaurants;
        private IGenericRepository<Review> _reviews;
        private IGenericRepository<Staff> _staffs;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Category> Categories
            => _categories ??= new GenericRepository<Category>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<Promotion> Promotions
            => _promotions ??= new GenericRepository<Promotion>(_context);
        public IGenericRepository<Reservation> Reservations
            => _reservations ??= new GenericRepository<Reservation>(_context);
        public IGenericRepository<Restaurant> Restaurants
            => _restaurants ??= new GenericRepository<Restaurant>(_context);
        public IGenericRepository<Review> Reviews
            => _reviews ??= new GenericRepository<Review>(_context);
        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}