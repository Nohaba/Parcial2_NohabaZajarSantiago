using System.ComponentModel.DataAnnotations;

namespace Parcial2_NohabaZajarSantiago.DAL.Entities
{
    public class Entity
    {
        [Key]
        public virtual Guid Id { get; set; }

        [Display(Name = "Fecha de creacion")]
        public virtual DateTime? CreatedDate { get; set; }

        [Display(Name = "Fecha de modificacion")]
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
