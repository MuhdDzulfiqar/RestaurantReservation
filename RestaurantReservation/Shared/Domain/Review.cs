using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Shared.Domain
{
    public class Review : BaseDomainModel
    {
        [Required]
        public int Rating { get; set; }

        [Required]
        public String Comments { get; set; }

        [Required]
        public int ReservationID { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
