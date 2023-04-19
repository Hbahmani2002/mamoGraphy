using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace mamographyBackend.Context.user
{
    [Table("RPAC_Modality")]
    [Index(nameof(Code), Name = "IX_RPAC_Modality", IsUnique = true)]
    public partial class RPAC_Modality
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        public int? RecordState { get; set; }
    }
}
