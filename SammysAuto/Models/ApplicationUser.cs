using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SammysAuto.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Nome")]
        public string FirstName { get; set; }
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }
        [Display(Name = "Endereço")]
        public string Address { get; set; }
        [Display(Name = "Cidade")]
        public string City { get; set; }
        [Display(Name = "Código Postal")]
        public string PostalCode { get; set; }
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

    }
}
