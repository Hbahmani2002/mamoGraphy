using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace mamographyBackend.Context.user
{
    [Table("RPAC_HospitalStudy")]
    [Index(nameof(CreatedTime), Name = "CreatedTime")]
    [Index(nameof(HospitalId), Name = "HospitalId")]
    [Index(nameof(HospitalId), nameof(ModalityId), Name = "HospitalIdModalityId")]
    [Index(nameof(HospitalStudyInstanceUid), Name = "HospitalStudyInstanceUid")]
    [Index(nameof(EmergencyDate), nameof(HospitalId), nameof(ModalityId), Name = "IX_RPAC_HospitalStudy_EmergencyDate_HospitalId_ModalityId")]
    [Index(nameof(HospitalData_CreatedTime), nameof(EmergencyDate), nameof(RecordState), nameof(HospitalId), nameof(ModalityId), Name = "IX_RPAC_HospitalStudy_HospitalDataCreatedTime_EmergencyDate_RecordState_HospitalId_ModalityId")]
    [Index(nameof(HospitalData_CreatedTime), nameof(RecordState), nameof(HospitalId), nameof(ModalityId), Name = "IX_RPAC_HospitalStudy_HospitalDataCreatedTime_RecordState_HospitalId_ModalityId")]
    [Index(nameof(HospitalId), nameof(RecordState), nameof(ModalityId), nameof(HospitalData_PatientName), Name = "IX_RPAC_HospitalStudy_HospitalId_RecordState_ModalityId_HospitalData_PatientName")]
    [Index(nameof(CreatedTime), nameof(RecordState), nameof(HospitalId), nameof(ModalityId), Name = "IX_RPAC_HospitalStudy_ProtekCreatedTime_RecordState_HospitalId_ModalityId")]
    [Index(nameof(ModalityId), Name = "ModalityId")]
    [Index(nameof(HospitalId), nameof(HospitalData_PatientId), Name = "RPAC_HospitalStudy_PatientId")]
    [Index(nameof(HospitalStudyInstanceUid), nameof(HospitalId), Name = "RPAC_HospitalStudy_StudyInstanceUid")]
    [Index(nameof(HospitalData_CreatedTime), nameof(EmergencyDate), nameof(ModalityId), nameof(Id), nameof(HospitalId), nameof(StudyProcessId), Name = "_dta_index_RPAC_HospitalStudy_6_533576939__K10_K16_K4_K1_K3_K28_2_5_6_7_8_9_11_13_14_15_18_19_20_21_22_23_24_27_29_30_31_32_34_")]
    [Index(nameof(Id), Name = "_dta_index_RPAC_HospitalStudy_6_533576939__K1_11_23")]
    [Index(nameof(Id), Name = "_dta_index_RPAC_HospitalStudy_6_533576939__K1_2_3_4_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29_30_")]
    public partial class RPAC_HospitalStudy
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(64)]
        public string HospitalStudyInstanceUid { get; set; }
        public long HospitalId { get; set; }
        public long ModalityId { get; set; }
        [StringLength(256)]
        public string HospitalData_PatientName { get; set; }
        [StringLength(256)]
        public string HospitalData_PatientId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HospitalData_PatientBirthDate { get; set; }
        [StringLength(64)]
        public string HospitalData_PatientSex { get; set; }
        [StringLength(64)]
        public string HospitalData_ReferringPhysicianName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HospitalData_CreatedTime { get; set; }
        [StringLength(16)]
        public string HospitalData_AccessionNumber { get; set; }
        [StringLength(16)]
        public string HospitalData_StudyId { get; set; }
        [StringLength(64)]
        public string HospitalData_Description { get; set; }
        public bool IsEmergency { get; set; }
        public string Anamnez { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EmergencyDate { get; set; }
        public long? Old_Data { get; set; }
        public int? RecordState { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsWritten { get; set; }
        public bool? IsConfirmed { get; set; }
        public int? InstanceCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        public int? EmergencyTimeManual { get; set; }
        public long? PatientId { get; set; }
        public Guid? HospitalData_StudyGUID { get; set; }
        public bool? HasVoicePath { get; set; }
        public long? StudyProcessId { get; set; }
        public int? ReportCount { get; set; }
        public int? RequestCount { get; set; }
        public string Secretaries { get; set; }
        public string DoctorName { get; set; }
        public string DoctorNote { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ProcessCreatedTime { get; set; }
        public int? RemainingRequestCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastAccessedTime { get; set; }
        public int? RemainingEmergencyTime { get; set; }
        public int? ImageStatus { get; set; }
        public bool? IsPriorityRoutine { get; set; }
        public bool? IsDoctorPostToHL7 { get; set; }
        public string OpenDoctorUserName { get; set; }
    }
}
