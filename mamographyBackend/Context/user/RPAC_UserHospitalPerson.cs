using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace mamographyBackend.Context.user
{
    [Table("RPAC_UserHospitalPerson")]
    public partial class RPAC_UserHospitalPerson
    {
        [Key]
        public long UserLoginId { get; set; }
        public long HospitalId { get; set; }
        public int? RecordState { get; set; }
    }
}
