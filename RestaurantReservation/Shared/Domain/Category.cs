using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Shared.Domain
{
    public class Category : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
