using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace mamographyBackend.Context.user
{
    [Table("RPAC_UserLogin")]
    [Index(nameof(RecordState), Name = "IX_RPAC_UserLogin_RecordState")]
    [Index(nameof(UserRoleId), Name = "IX_RPAC_UserLogin_UserRoleId")]
    [Index(nameof(Id), Name = "_dta_index_RPAC_UserLogin_6_327672215__K1_4")]
    public partial class RPAC_UserLogin
    {
        [Key]
        public long Id { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(256)]
        public string Surname { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }
        [Required]
        [StringLength(512)]
        public string Password { get; set; }
        public long UserRoleId { get; set; }
        public int RecordState { get; set; }
        public bool? IsIncludedToKosgeb { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        public long? Old_Data { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string EMail { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(150)]
        public string AccountNo { get; set; }
        [StringLength(150)]
        public string Corporation { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        public long? UserIdModified { get; set; }
        public long? UserIdCreated { get; set; }
        [StringLength(11)]
        public string TCNO { get; set; }
        public int? OnlineStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastOnlineDate { get; set; }
    }
}
