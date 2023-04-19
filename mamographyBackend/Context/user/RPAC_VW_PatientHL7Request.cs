using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace mamographyBackend.Context.user
{
    [Keyless]
    public partial class RPAC_VW_PatientHL7Request
    {
        public long HL7RequestId { get; set; }
        public long? StudyId { get; set; }
        [StringLength(50)]
        public string PatientId { get; set; }
        [StringLength(100)]
        public string PatientName { get; set; }
        [Required]
        [StringLength(16)]
        public string AccessionNumber { get; set; }
        [StringLength(50)]
        public string RequestGroupId { get; set; }
        [StringLength(50)]
        public string SutCode { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        [StringLength(500)]
        public string Anamnesis { get; set; }
        public long? HospitalId { get; set; }
        [Required]
        [StringLength(256)]
        public string HospitalName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HL7RequestRequestTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HL7RequestCreatedTime { get; set; }
        public long? ModalityId { get; set; }
        [StringLength(10)]
        public string ModalityCode { get; set; }
        public long? TemplateId { get; set; }
        public long? RequestId { get; set; }
        public long? ReportRequestHL7Id { get; set; }
        [StringLength(256)]
        public string TemplateName { get; set; }
        public long? ReportRequestId { get; set; }
        [StringLength(1024)]
        public string ReportTitle { get; set; }
        public bool? IsConfirmed { get; set; }
        public bool? IsPostedToHBYS { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReportCreatedTime { get; set; }
        public long? UserIdDoctor { get; set; }
        public long? UserIdSecretary { get; set; }
        public long? ReportId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PostedToHBYSTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StudyTime { get; set; }
        [StringLength(16)]
        public string StudyAccessionNumber { get; set; }
        [StringLength(256)]
        public string DoctorUserName { get; set; }
        [StringLength(256)]
        public string SecretaryUserName { get; set; }
        [StringLength(256)]
        public string PostedToHBYSUserName { get; set; }
        public int? RecordState { get; set; }
    }
}
