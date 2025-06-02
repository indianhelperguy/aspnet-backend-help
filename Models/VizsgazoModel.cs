using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace aspnet_backend_help.Models
{
    public class VizsgazoModel
    {
        [Table("vizsgazok")]
        public class Vizsgazo
        {
            [Key]
            [Column("id")]
            public int Id { get; set; }

            [Column("nev")]
            [Required]
            [MaxLength(255)]
            public string Nev { get; set; }

            [Column("vizsgatipusId")]
            [ForeignKey("Vizsgatipus")]
            public int VizsgatipusId { get; set; }

            [Column("eredmeny")]
            public int Eredmeny { get; set; }

            public VizsgatipusModel Vizsgatipus { get; set; }
        }
    }
}
