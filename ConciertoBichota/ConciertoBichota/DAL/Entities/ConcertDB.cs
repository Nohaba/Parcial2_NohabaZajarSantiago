using System.ComponentModel.DataAnnotations;

namespace ConciertoBichota.DAL.Entities
{
    public class ConcertDB
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? UseDate { get; set; }
        public bool IsUsed { get; set; }
        public string EntranceGate { get; set; }
    }
}
