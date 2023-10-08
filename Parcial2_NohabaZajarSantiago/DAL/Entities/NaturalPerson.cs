using System.ComponentModel.DataAnnotations;

namespace Parcial2_NohabaZajarSantiago.DAL.Entities
{
    public class NaturalPerson : Entity
    {
        #region Properties
        [Display(Name = "Identificacion")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe de tener maximo {1} caracteres ")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public String Identification { get; set; }
        
        [Display(Name = "Nombre Completo")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe de tener maximo {1} caracteres ")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string FullName { get; set; }

        [Display(Name = "Correo Electronico")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe de tener maximo {1} caracteres ")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Año De Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public int BirthYear { get; set; }

        [Display(Name = "Edad")]
        public int Age { get; set; }

        #endregion

    }
}
