using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Shared.Domain
{
    public class Reservation : BaseDomainModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [Required]
        [DataType(DataType.Time)]

        public DateTime TimeStart { get; set; }


        [Required]
        public int RestaurantID { get; set; }
        public virtual Restaurant Restaurants { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        public int StaffID { get; set; }
        public virtual Staff Staff{ get; set; }
    }
}
