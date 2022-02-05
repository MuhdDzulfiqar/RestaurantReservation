using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public String Gender { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
