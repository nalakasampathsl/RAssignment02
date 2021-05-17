using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Entity
{
    [Table("AircraftSighting")]
    public class AircraftSighting
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(128)]
        public string Make { get; set; }

        [StringLength(128)]
        public string Model { get; set; }

        [StringLength(8)]
        public string Registration { get; set; }

        [StringLength(255)]
        public string Location { get; set; }
        public DateTime? DateAndTime { get; set; }
    }
}
