using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace mamographyBackend.Context.user
{
    [Table("RPAC_UserRole")]
    [Index(nameof(Name), Name = "IX_RPAC_UserRole", IsUnique = true)]
    public partial class RPAC_UserRole
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public int? RecordState { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        public long? CreatedUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedTime { get; set; }
        public long? ModifiedUserId { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
    }
}
