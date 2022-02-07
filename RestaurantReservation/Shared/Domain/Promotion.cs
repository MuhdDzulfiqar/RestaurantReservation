using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Shared.Domain
{
    public class Promotion : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }

        public DateTime DateStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        public DateTime TimeStart { get; set; }

        [Required]
        [DataType(DataType.Time)]

        public DateTime TimeEnd { get; set; }

        [Required]
        public int RestaurantID { get; set; }

        public virtual Restaurant Restaurant { get; set; }

    }
}
