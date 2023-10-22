using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UzdevumsBackend.Models
{
    public class Dats
    {
        [Key]
        public int Id { get; set; }

        [Column("Project")]
        public string Project { get; set; } = null!;

        [Column("Trip")]
        public string Trip { get; set; } = null!;

        [Column("Longitude")]
        public double Longitude { get; set; }

        [Column("Latitude")]
        public double Latitude { get; set; }

        [Column("DateTime")]
        public DateTime DateTime { get; set; }

        [Column("Station")]
        public string Station { get; set; } = null!;

        [Column("Bott Depth M")]
        public double BottDepthM { get; set; }

        [Column("Sample ID")]
        public int SampleId { get; set; }

        [Column("Parameter")]
        public string Parameter { get; set; } = null!;

        [Column("Tissue")]
        public string Tissue { get; set; } = null!;

        [Column("Species")]
        public string Species { get; set; } = null!;

        [Column("Individuals")]
        public int Individuals { get; set; }

        [Column("Value")]
        public string Value { get; set; } = null!;

        [Column("Units")]
        public string Units { get; set; } = null!;

        [Column("Quality")]
        public string? Quality { get; set; }
    }
}
