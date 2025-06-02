using static aspnet_backend_help.Models.VizsgazoModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace aspnet_backend_help.Models
{
    public class VizsgatipusModel
    {
        [Table("vizsgatipus")]
        public class Vizsgatipus
        {
            [Key]
            [Column("id")]
            public int Id { get; set; }

            [Column("modul")]
            [Required]
            [MaxLength(255)]
            public string Modul { get; set; }

            public List<Vizsgazo> Vizsgazok { get; set; } = new();
        }
    }
}
