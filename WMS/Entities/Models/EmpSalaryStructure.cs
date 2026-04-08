#nullable disable
using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class EmpSalaryStructure
{
    public long TabId { get; set; }

    public string Ecode { get; set; }

    public decimal? SpecialPay { get; set; }

    public decimal? RateDa { get; set; }

    public decimal? Da { get; set; }

    public decimal? Basic { get; set; }

    public decimal? PersonalPay { get; set; }

    public string PayBand { get; set; }

    public string CurPayGrade { get; set; }

    public decimal? MediAllow { get; set; }

    public decimal? EmpContribution { get; set; }

    public decimal? CityAllow { get; set; }

    public decimal? WashingAllow { get; set; }

    public decimal? EmergencyAllow { get; set; }

    public decimal? NonPracAllow { get; set; }

    public decimal? UniformAllow { get; set; }

    public decimal? SpecialAllow { get; set; }

    public DateTime? PrevIncreDate { get; set; }

    public DateTime? NextIncreDate { get; set; }

    public string PayMode { get; set; }

    public string BankName { get; set; }

    public string Branch { get; set; }

    public string Ifsc { get; set; }

    public string AccountNo { get; set; }

    public string GpfType { get; set; }

    public string GpfAcctNo { get; set; }

    public decimal? GpsAmt { get; set; }

    public decimal? GssAmt { get; set; }

    public decimal? EarnLeave { get; set; }

    public string Createdby { get; set; }

    public DateTime? CreateDate { get; set; }

    public string Updatedby { get; set; }

    public DateTime? UpdateDate { get; set; }

    public decimal? CccRate { get; set; }

    public decimal? Hra { get; set; }

    public decimal? VechileAllowance { get; set; }

    public decimal? Dp { get; set; }

    public decimal? Mpay { get; set; }

    public decimal? Mded { get; set; }

    public decimal? Gpfda { get; set; }

    public decimal? GrossPay { get; set; }

    public string EnLic { get; set; }

    public string EnPli { get; set; }

    public string EmpCodeOld { get; set; }

    public decimal? Cta { get; set; }

    public DateTime? CccDate { get; set; }

    public string HraType { get; set; }

    public decimal? BalGpf { get; set; }

    public decimal? BalGss { get; set; }

    public decimal? BalEarn { get; set; }

    public string OwfAcctNo { get; set; }

    public bool? IsResidingCq { get; set; }

    public decimal? Basic7payJan16 { get; set; }

    public decimal? Basic7pay { get; set; }

    public string LevelCode { get; set; }

    public decimal? GradePayJan { get; set; }

    public decimal? PayInPaybandJan { get; set; }

    public decimal? BasicOld { get; set; }

    public decimal? GradePayOld { get; set; }

    public decimal? PayInPaybandOld { get; set; }

    public string ImpDate7pay { get; set; }

    public string EffDate7pay { get; set; }

    public string Flag7pay { get; set; }

    public decimal? CccRate7pay { get; set; }

    public decimal? Hra6payLast { get; set; }

    public string Ctaapplicable { get; set; }

    public decimal? Ctarate7pay { get; set; }

    public string PhysicalHandicap { get; set; }

    public string IsManualContribution { get; set; }

    public decimal? EmployeerContribution { get; set; }
}