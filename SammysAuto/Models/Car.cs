using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SammysAuto.Models
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Chassi")]
        public string VIN { get; set; }
        [Required]
        [Display(Name = "Fabricante")]
        public string Make { get; set; }
        [Required]
        [Display(Name = "Modelo")]
        public string Model { get; set; }
        [Display(Name = "Estilo")]
        public string Style { get; set; }
        [Required]
        [Display(Name = "Ano")]
        public int Year { get; set; }
        [Required]
        [Display(Name = "KM")]
        public double Miles { get; set; }
        [Display(Name = "Cor")]
        public string Color { get; set; }
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
