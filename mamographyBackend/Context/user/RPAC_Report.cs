using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace mamographyBackend.Context.user
{
    [Table("RPAC_Report")]
    [Index(nameof(ConfirmationTime), Name = "ConfirmationTime")]
    [Index(nameof(IsPostedToHBYS), nameof(CreatedTime), nameof(RecordState), Name = "IX_RPAC_Report_CreatedTime_RecordState_IsPostedToHBYS")]
    [Index(nameof(ConfirmationTime), nameof(CMPT_HospitalId), Name = "IX_RPAC_Report_HospitalId_Confirmationtime")]
    [Index(nameof(IsConfirmed), nameof(DoctorReportDraftId), nameof(RecordState), nameof(CreatedTime), Name = "IX_RPAC_Report_IsConfirmed_DoctorDraftId_RecordState_CreatedTime")]
    [Index(nameof(IsConfirmed), nameof(RecordState), nameof(CreatedTime), Name = "IX_RPAC_Report_IsConfirmed_RecordState_CreatedTime")]
    [Index(nameof(CreatedTime), nameof(RecordState), Name = "IX_RPAC_Report_RecordState_CreatedTime")]
    [Index(nameof(ReportRequestId), Name = "IX_RPAC_Report_ReportRequestId")]
    [Index(nameof(StudyId), Name = "IX_RPAC_Report_StudyId")]
    [Index(nameof(ReportRequestId), Name = "ReportRequestId")]
    [Index(nameof(StudyId), Name = "StudyId")]
    [Index(nameof(ReportRequestId), nameof(UserIdDoctor), nameof(UserIdSecretary), nameof(UserIdPostedToHBYS), Name = "_dta_index_RPAC_Report_6_645577338__K25_K20_K4_K13_1_9_11_12_15_17")]
    public partial class RPAC_Report
    {
        [Key]
        public long Id { get; set; }
        public long StudyId { get; set; }
        public long StudyProcessId { get; set; }
        public long UserIdSecretary { get; set; }
        public long? UserIdConfirmed { get; set; }
        public long? UserIdModified { get; set; }
        [Required]
        [StringLength(4000)]
        public string ReportWordDocPath { get; set; }
        public string ContentJSON { get; set; }
        public bool IsConfirmed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ConfirmationTime { get; set; }
        public bool? IsPostedToHBYS { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PostedToHBYSTime { get; set; }
        public long? UserIdPostedToHBYS { get; set; }
        public long DoctorReportDraftId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedTime { get; set; }
        [StringLength(1024)]
        public string ReportTitle { get; set; }
        public int RecordState { get; set; }
        public long? Old_Data { get; set; }
        public long? UserIdDoctor { get; set; }
        public bool? IsBilled { get; set; }
        public bool? IsSigned { get; set; }
        public int? Type { get; set; }
        public long? ReportRequestId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SignedTime { get; set; }
        public long? ReportContentProcessId { get; set; }
        public bool? IsDoctorAllowance { get; set; }
        public long? DoctorIdSignOwner { get; set; }
        public bool? IsHtml { get; set; }
        public bool? IsViewed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ViewedDate { get; set; }
        public long? UserIdViewed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StudyProcessCreatedTime { get; set; }
        public long? ReportContentId { get; set; }
        public bool? IsXSig { get; set; }
        [StringLength(1000)]
        public string ESignFileName { get; set; }
        [StringLength(1000)]
        public string XSigFileName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? XSigTime { get; set; }
        [StringLength(1000)]
        public string FolderDirectoryPath { get; set; }
        public bool? IsReevaluation { get; set; }
        public long? CMPT_HospitalId { get; set; }
        public bool? IsACK { get; set; }
        public bool? IsEdited { get; set; }
    }
}
