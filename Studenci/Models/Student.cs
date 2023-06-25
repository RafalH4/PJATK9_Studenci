using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Studenci.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Numer indeksu")]
        public string IndexNumber { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
    }
}
