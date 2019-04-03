using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBasketApp.Models
{
    [MetadataType(typeof(CustomerMeta))]
    public partial class Customer
    {
        // you may add new properties and methods here
    }

    public class CustomerMeta
    {
        [Required(ErrorMessage ="Name is a mandatory field")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Name must be 3 to 50 letters")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}