using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace mamographyBackend.Context.user
{
    [Table("RPAC_Hospital")]
    [Index(nameof(ServerPartitionGUID), Name = "IX_RPAC_Hospital", IsUnique = true)]
    [Index(nameof(Id), Name = "_dta_index_RPAC_Hospital_6_501576825__K1_3_12_14")]
    public partial class RPAC_Hospital
    {
        [Key]
        public long Id { get; set; }
        public Guid ServerPartitionGUID { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        [Required]
        [StringLength(256)]
        public string CompanyName { get; set; }
        public bool IsAnamnezRequired { get; set; }
        public bool IsEmergentHospital { get; set; }
        [StringLength(20)]
        public string ServerIp { get; set; }
        [StringLength(50)]
        public string ServerAETitle { get; set; }
        public int? ServerSCPPort { get; set; }
        public int? ServerWADOPort { get; set; }
        public int? ImageServicePort { get; set; }
        public int? EmergencyTime { get; set; }
        public int RecordState { get; set; }
        public bool? IsRequestRequired { get; set; }
        public long? PDFTemplateContentDataId { get; set; }
        public long? PDFTemplateWithAnamnesisContentDataId { get; set; }
        public long? WORDTemplateContentDataId { get; set; }
        public long? WORDTemplatewithAnamnesisContentDataId { get; set; }
        public long? PNOMOTemplateContentDataId { get; set; }
        public long? DynamicTemplateId { get; set; }
        public bool? IsPublicContract { get; set; }
        public int? PacsEnumTypeId { get; set; }
        [StringLength(255)]
        public string WadoUrl { get; set; }
        [StringLength(50)]
        public string NAPPacsAETitle { get; set; }
        public long? ReportTemplateGroupId { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastImageIncomingTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        public long? CreatedUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedTime { get; set; }
        public long? ModifiedUserId { get; set; }
        [StringLength(50)]
        public string LocalAETitle { get; set; }
    }
}
