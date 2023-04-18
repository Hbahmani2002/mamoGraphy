using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace mamographyBackend.Context.user
{
    [Table("USR_UserHospitalPermission")]
    [Index(nameof(HospitalId), nameof(UserId), Name = "IX_AUTH_UserHospitalPermission", IsUnique = true)]
    public partial class USR_UserHospitalPermission
    {
        [Key]
        public long Id { get; set; }
        public long HospitalId { get; set; }
        public long UserId { get; set; }
        public bool ReadReport { get; set; }
        public bool WriteReport { get; set; }
        public bool ListPatient { get; set; }
        public int? RecordState { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        public long? CreatedUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedTime { get; set; }
        public long? ModifiedUserId { get; set; }
    }
}
