using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string CategoriesEndpoint = $"{Prefix}/categories";
        public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        public static readonly string PromotionsEndpoint = $"{Prefix}/promotions";
        public static readonly string ReservationsEndpoint = $"{Prefix}/reservations";
        public static readonly string RestaurantsEndpoint = $"{Prefix}/restaurants";
        public static readonly string ReviewsEndpoint = $"{Prefix}/reviews";
        public static readonly string StaffsEndpoint = $"{Prefix}/staffs";
    }
}
