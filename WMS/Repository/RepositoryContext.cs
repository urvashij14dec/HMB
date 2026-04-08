using Entities.Identity;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Configuration;
using Repository.Models;
using System.Text;

namespace Repository
{
    public partial class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            modelBuilder.Entity<MEmpMast>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("M_EMP_MAST", tb => tb.HasTrigger("M_EMP_MAST_UPDATED"));

                entity.HasIndex(e => e.Ecode, "ClusteredIndex-20150211-221235").IsClustered();

                entity.HasIndex(e => e.DesigCode, "NCI_M_EMP_MAST_EmplyeeList");

                entity.HasIndex(e => e.CentreCode, "NOC_INX_M_EMP_MAST_CentreCode");

                entity.HasIndex(e => e.CentreCode, "NOC_INX_M_EMP_MAST_CentreCode_CompanyName_E_STATION");

                entity.HasIndex(e => new { e.InoutdeputationType, e.CentreCode, e.InoutdeputationLocName }, "NOC_INX_M_EMP_MAST_InoutdeputationType_CentreCode_InoutdeputationLocName");

                entity.HasIndex(e => e.DepttCode, "NonClusteredIndex-20150211-221300");

                entity.Property(e => e.AadharNumber).HasMaxLength(50);
                entity.Property(e => e.AccoCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACCO_CODE");
                entity.Property(e => e.AcctNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACCT_NO");
                entity.Property(e => e.ActualRetireDate).HasColumnName("ACTUAL_RETIRE_DATE");
                entity.Property(e => e.AppDoptiiNo)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("APP_DOPTII_NO");
                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Appointment_Date");
                entity.Property(e => e.AppointmentOrderNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Appointment_OrderNo");
                entity.Property(e => e.BankCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("BANK_CODE");
                entity.Property(e => e.BankName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("BANK_NAME");
                entity.Property(e => e.Basic)
                    .HasColumnType("numeric(9, 2)")
                    .HasColumnName("BASIC");
                entity.Property(e => e.BgtCatCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("BGT_CAT_CODE");
                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BIRTH_PLACE");
                entity.Property(e => e.BloodGp)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("BLOOD_GP");
                entity.Property(e => e.Busflag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("BUSFLAG");
                entity.Property(e => e.Caste)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.CatCode)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("CAT_CODE");
                entity.Property(e => e.CdtAmt)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("CDT_AMT");
                entity.Property(e => e.CentreCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.ChildAllFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Child_ALL_FLAG");
                entity.Property(e => e.CityAllow)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CITY_ALLOW");
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.ConfDoptiiNo)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("CONF_DOPTII_NO");
                entity.Property(e => e.ConfirmDate).HasColumnName("CONFIRM_DATE");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entity.Property(e => e.CurPayGrade)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CUR_PAY_GRADE");
                entity.Property(e => e.Da)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("DA");
                entity.Property(e => e.DateOfBirth).HasColumnName("DATE_OF_BIRTH");
                entity.Property(e => e.DateOfIncrement).HasColumnName("DATE_OF_INCREMENT");
                entity.Property(e => e.DateOfJoin).HasColumnName("DATE_OF_JOIN");
                entity.Property(e => e.DeathSchFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("DEATH_SCH_FLAG");
                entity.Property(e => e.DepType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DEP_TYPE");
                entity.Property(e => e.DepttCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("DEPTT_CODE");
                entity.Property(e => e.DepuLocation)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Depu_Location");
                entity.Property(e => e.DesigCat)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Desig_Cat");
                entity.Property(e => e.DesigCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DESIG_CODE");
                entity.Property(e => e.Dhraflag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("DHRAFlag");
                entity.Property(e => e.DtGovt).HasColumnName("DT_GOVT");
                entity.Property(e => e.DtNxIncr).HasColumnName("DT_NX_INCR");
                entity.Property(e => e.DtPmt).HasColumnName("DT_PMT");
                entity.Property(e => e.EDesg)
                    .HasMaxLength(3)
                    .HasColumnName("E_DESG");
                entity.Property(e => e.EGrade)
                    .HasMaxLength(3)
                    .HasColumnName("E_GRADE");
                entity.Property(e => e.EScale)
                    .HasMaxLength(3)
                    .HasColumnName("E_SCALE");
                entity.Property(e => e.EStation)
                    .HasMaxLength(3)
                    .HasColumnName("E_STATION");
                entity.Property(e => e.Ecode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ECODE");
                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");
                entity.Property(e => e.EmpClass)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.EmpCodeOld).HasMaxLength(30);
                entity.Property(e => e.EmpContribution)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("EMP_CONTRIBUTION");
                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .HasColumnName("EMP_NAME");
                entity.Property(e => e.EmpStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMP_STATUS");
                entity.Property(e => e.EmpType)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.EmployeeClass).HasMaxLength(50);
                entity.Property(e => e.EstCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("EST_CODE");
                entity.Property(e => e.ExTelNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EX_TEL_NO");
                entity.Property(e => e.FathName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FATH_NAME");
                entity.Property(e => e.GisDed)
                    .HasColumnType("numeric(12, 2)")
                    .HasColumnName("GIS_DED");
                entity.Property(e => e.GovtAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GOVT_ACC_FLAG");
                entity.Property(e => e.GpfCpfNo).HasMaxLength(50);
                entity.Property(e => e.GpfDed)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("GPF_DED");
                entity.Property(e => e.GpfType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GPF_TYPE");
                entity.Property(e => e.GradePay)
                    .HasColumnType("numeric(12, 2)")
                    .HasColumnName("GRADE_PAY");
                entity.Property(e => e.Grp)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("GRP");
                entity.Property(e => e.Gslip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("gslip");
                entity.Property(e => e.HandicaptFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HANDICAPT_FLAG");
                entity.Property(e => e.HomeTown)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("HOME_TOWN");
                entity.Property(e => e.Hraflag)
                    .HasComment("0= Uncheked and 1= cheked")
                    .HasColumnName("HRAFlag");
                entity.Property(e => e.IncomeTax)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("INCOME_TAX");
                entity.Property(e => e.InoutdeputationLocName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.InoutdeputationType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.JoiningLocation)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Joining_Location");
                entity.Property(e => e.LastCentreCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.LevDoptiiNo)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("LEV_DOPTII_NO");
                entity.Property(e => e.LocAdd1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOC_ADD1");
                entity.Property(e => e.LocAdd2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOC_ADD2");
                entity.Property(e => e.LocAdd3)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOC_ADD3");
                entity.Property(e => e.LocDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOC_DISTRICT");
                entity.Property(e => e.LocPin)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("LOC_PIN");
                entity.Property(e => e.LocState)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("LOC_STATE");
                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MARITAL_STATUS");
                entity.Property(e => e.MediAllow)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MEDI_ALLOW");
                entity.Property(e => e.Medico)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("MEDICO");
                entity.Property(e => e.MiscFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("MISC_FLAG");
                entity.Property(e => e.MobileNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);
                entity.Property(e => e.ModeSalPay)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MODE_SAL_PAY");
                entity.Property(e => e.NameHindi)
                    .HasMaxLength(4000)
                    .HasColumnName("NAME_HINDI");
                entity.Property(e => e.NearRailStation)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NEAR_RAIL_STATION");
                entity.Property(e => e.NoOfChild)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("NO_OF_CHILD");
                entity.Property(e => e.OffVechFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OFF_VECH_FLAG");
                entity.Property(e => e.OrderNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_NO");
                entity.Property(e => e.PanNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PAN_NO");
                entity.Property(e => e.ParAdd1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PAR_ADD1");
                entity.Property(e => e.ParAdd2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PAR_ADD2");
                entity.Property(e => e.ParAdd3)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PAR_ADD3");
                entity.Property(e => e.ParDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAR_DISTRICT");
                entity.Property(e => e.ParPin)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("PAR_PIN");
                entity.Property(e => e.ParState)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PAR_STATE");
                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");
                entity.Property(e => e.PayBand)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PAY_BAND");
                entity.Property(e => e.PayGrade)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PAY_GRADE");
                entity.Property(e => e.PayReleaseFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PAY_RELEASE_FLAG");
                entity.Property(e => e.PayRev)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PAY_REV");
                entity.Property(e => e.PersonalPay)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("PERSONAL_PAY");
                entity.Property(e => e.PfNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PF_NO");
                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NO");
                entity.Property(e => e.ProRec)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PRO_REC");
                entity.Property(e => e.ProfessionFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PROFESSION_FLAG");
                entity.Property(e => e.Promotion)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("PROMOTION");
                entity.Property(e => e.QStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Q_STATUS");
                entity.Property(e => e.Qalific1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("QALIFIC1");
                entity.Property(e => e.Qalific2)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("QALIFIC2");
                entity.Property(e => e.Qalific3)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("QALIFIC3");
                entity.Property(e => e.Qalific4)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("QALIFIC4");
                entity.Property(e => e.Qualification)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("QUALIFICATION");
                entity.Property(e => e.RateDa)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("RATE_DA");
                entity.Property(e => e.Recflag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RECFLAG");
                entity.Property(e => e.ReliefFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("RELIEF_FLAG");
                entity.Property(e => e.Remark)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
                entity.Property(e => e.RemarkDeputation).HasMaxLength(200);
                entity.Property(e => e.ResPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("RES_PHONE");
                entity.Property(e => e.RetYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("RET_YEAR");
                entity.Property(e => e.RetireDate).HasColumnName("RETIRE_DATE");
                entity.Property(e => e.SalOldNewFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAL_OLD_NEW_FLAG");
                entity.Property(e => e.ScSt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SC_ST");
                entity.Property(e => e.Section)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("SECTION");
                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SEX");
                entity.Property(e => e.Sflag).HasColumnName("SFlag");
                entity.Property(e => e.SpecialAllowance)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.SpecialPay)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("SPECIAL_PAY");
                entity.Property(e => e.SpouseJobLocation)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Spouse_JobLocation");
                entity.Property(e => e.SubCasteCatg)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subCasteCatg");
                entity.Property(e => e.Subject)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");
                entity.Property(e => e.TNo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("T_NO");
                entity.Property(e => e.Tecode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TECODE");
                entity.Property(e => e.Univ)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("UNIV");
                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedBY");
                entity.Property(e => e.VCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("V_CODE");
                entity.Property(e => e.WashAllFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WASH_ALL_FLAG");
                entity.Property(e => e.WifeEcode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("WIFE_ECODE");
                entity.Property(e => e.WifeGovtSerFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WIFE_GOVT_SER_FLAG");
                entity.Property(e => e.WifeSerFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("WIFE_SER_FLAG");
            });

            modelBuilder.Entity<MEmpMastAddDetail>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("M_EMP_MAST_ADD_DETAIL");

                entity.HasIndex(e => e.Ecode, "ClusteredIndex-20150211-221520").IsClustered();

                entity.HasIndex(e => e.PerPan, "NonClusteredIndex-20150211-221552");

                entity.Property(e => e.AcQual)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Ac_Qual");
                entity.Property(e => e.AcRemark)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Ac_Remark");
                entity.Property(e => e.AcYear)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Ac_Year");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Ecode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ECODE");
                entity.Property(e => e.ExTelNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EX_TEL_NO");
                entity.Property(e => e.HomeTown)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("HOME_TOWN");
                entity.Property(e => e.ImagePath).HasMaxLength(100);
                entity.Property(e => e.LocAdd)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LOC_ADD");
                entity.Property(e => e.LocContact)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("LOC_Contact");
                entity.Property(e => e.LocDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOC_DISTRICT");
                entity.Property(e => e.LocPin)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("LOC_PIN");
                entity.Property(e => e.LocState)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("LOC_STATE");
                entity.Property(e => e.ParAdd)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PAR_ADD");
                entity.Property(e => e.ParDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAR_DISTRICT");
                entity.Property(e => e.ParEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAR_Email");
                entity.Property(e => e.ParMobile)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("PAR_Mobile");
                entity.Property(e => e.ParPhn)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("PAR_Phn");
                entity.Property(e => e.ParPin)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("PAR_PIN");
                entity.Property(e => e.ParState)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PAR_STATE");
                entity.Property(e => e.PerPan)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PER_Pan");
                entity.Property(e => e.PerRailway)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PER_Railway");
                entity.Property(e => e.PersonalIdmark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Personal_Idmark");
                entity.Property(e => e.PfQual)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Pf_Qual");
                entity.Property(e => e.PfRemark)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Pf_Remark");
                entity.Property(e => e.PfYear)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Pf_Year");
                entity.Property(e => e.QualType)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("Qual_Type");
                entity.Property(e => e.SpouseJobLocation)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Spouse_JobLocation");
            });

            modelBuilder.Entity<MFamilyDetail>(entity =>
            {
                entity.HasKey(e => new { e.Ecode, e.PersonName }).HasName("PKPERSON");

                entity.ToTable("M_FAMILY_DETAIL");

                entity.Property(e => e.Ecode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ECODE");
                entity.Property(e => e.PersonName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_NAME");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entity.Property(e => e.Dependent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("DEPENDENT");
                entity.Property(e => e.Dob).HasColumnName("DOB");
                entity.Property(e => e.PersonStatus)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_STATUS");
                entity.Property(e => e.RelationWithEmp).HasColumnName("RELATION_WITH_EMP");
                entity.Property(e => e.RowId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Row_Id");
                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SEX");
                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedBY");
            });

            modelBuilder.Entity<MNominee>(entity =>
            {
                entity
                    .HasKey(e => e.RowId);
                entity.ToTable("M_NOMINEE");

                entity.HasIndex(e => e.Ecode, "IX_M_NOMINEE").IsClustered();

                entity.Property(e => e.Add1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ADD1");
                entity.Property(e => e.Add2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ADD2");
                entity.Property(e => e.Add3)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ADD3");
                entity.Property(e => e.AmtPercent)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("AMT_PERCENT");
                entity.Property(e => e.Contigencies)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CONTIGENCIES");
                entity.Property(e => e.Dob).HasColumnName("DOB");
                entity.Property(e => e.Ecode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ECODE");
                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MARITAL_STATUS");
                entity.Property(e => e.NominationDt).HasColumnName("NOMINATION_DT");
                entity.Property(e => e.NominationFor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMINATION_FOR");
                entity.Property(e => e.NomineeName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOMINEE_NAME");
                entity.Property(e => e.NomineeStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NOMINEE_STATUS");
                entity.Property(e => e.NxAdd1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NX_ADD1");
                entity.Property(e => e.NxAdd2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NX_ADD2");
                entity.Property(e => e.NxAdd3)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NX_ADD3");
                entity.Property(e => e.NxDob).HasColumnName("NX_DOB");
                entity.Property(e => e.NxMaritalStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NX_MARITAL_STATUS");
                entity.Property(e => e.NxNominee)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NX_NOMINEE");
                entity.Property(e => e.NxNomineeStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NX_NOMINEE_STATUS");
                entity.Property(e => e.NxRelationWithEmp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NX_RELATION_WITH_EMP");
                entity.Property(e => e.RelationWithEmp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELATION_WITH_EMP");
                entity.Property(e => e.RowId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Row_Id");
                entity.Property(e => e.UpdatedBy).HasColumnName("UpdatedBY");
            });

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            //  modelBuilder.ApplyConfiguration(new UserConfiguration());


            //OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<MCompany>(entity =>
            {
                entity.HasKey(e => e.CompCode);

                entity.ToTable("M_Company");

                entity.Property(e => e.CompCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Cdate)
                    .HasDefaultValueSql("(getdate())")
                    .HasAnnotation("Relational:DefaultConstraintName", "DF_M_Company_CDate")
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");
                entity.Property(e => e.CompanyAddress).HasMaxLength(200);
                entity.Property(e => e.CompanyDesc)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
                entity.Property(e => e.Panno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PANNO");
                entity.Property(e => e.Pin)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("PIN");
                entity.Property(e => e.TableId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("tableID");
                entity.Property(e => e.Tanno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TANNO");
            });

            modelBuilder.Entity<MDesignationMast>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.TableId);

                // Table  exact name
                entity.ToTable("M_DESIGNATION_MAST");

                // TableID (PK, Identity)
                entity.Property(e => e.TableId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TableID");

                entity.Property(e => e.DepttCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("DEPTT_CODE");

                entity.Property(e => e.DesigCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DESIG_CODE");

                entity.Property(e => e.DesigDesc)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("DESIG_DESC");

                entity.Property(e => e.PayGrade)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PAY_GRADE");

                entity.Property(e => e.CadreCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CADRE_CODE");

                entity.Property(e => e.EstCat)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("EST_CAT");

                entity.Property(e => e.EmpGenDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMP_GEN_DESC");

                entity.Property(e => e.EmpGenCd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMP_GEN_CD");

                entity.Property(e => e.Ccode)
                    .IsFixedLength()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCODE");

                entity.Property(e => e.Payscale)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAYSCALE");

                entity.Property(e => e.OrderNumber)
                    .HasColumnName("OrderNumber");

                //  Null  Colmn handling
                entity.Property(e => e.DesigHindi)
                    .HasColumnName("Desig_Hindi")
                    .IsUnicode(true);
            });

            modelBuilder.Entity<EmpAttendance>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("Emp_Attendance");

                entity.Property(e => e.Company)
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.CreatedBy).HasMaxLength(500);
                entity.Property(e => e.Ecode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.MonthDay).HasColumnName("Month_Day");
                entity.Property(e => e.PresentAbsent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Present_Absent");
                entity.Property(e => e.Station)
                    .HasMaxLength(50)
                    .HasColumnName("STATION");
                entity.Property(e => e.UpdatedBy).HasMaxLength(500);
                entity.Property(e => e.Volume)
                    .HasMaxLength(50)
                    .HasColumnName("VOLUME");
            });

            modelBuilder.Entity<EmpSalaryStructure>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("EMP_SALARY_STRUCTURE", tb => tb.HasTrigger("EMP_SALARY_STRUCTURE_insertupadete"));

                entity.HasIndex(e => e.Ecode, "ClusteredIndex-20150211-220058").IsClustered();

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNT_NO");
                entity.Property(e => e.BalEarn)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("BAL_EARN");
                entity.Property(e => e.BalGpf)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("BAL_GPF");
                entity.Property(e => e.BalGss)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("BAL_GSS");
                entity.Property(e => e.BankName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BANK_NAME");
                entity.Property(e => e.Basic)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("BASIC");
                entity.Property(e => e.Basic7pay)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("basic_7pay");
                entity.Property(e => e.Basic7payJan16)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("basic7pay_jan16");
                entity.Property(e => e.BasicOld)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("basic_old");
                entity.Property(e => e.Branch)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH");
                entity.Property(e => e.CccDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CCC_DATE");
                entity.Property(e => e.CccRate)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CCC_RATE");
                entity.Property(e => e.CccRate7pay)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CCC_Rate_7pay");
                entity.Property(e => e.CityAllow)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CITY_ALLOW");
                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");
                entity.Property(e => e.Createdby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CREATEDBY");
                entity.Property(e => e.Cta)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CTA");
                entity.Property(e => e.Ctaapplicable)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CTAApplicable");
                entity.Property(e => e.Ctarate7pay)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CTARate_7pay");
                entity.Property(e => e.CurPayGrade)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CUR_PAY_GRADE");
                entity.Property(e => e.Da)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("DA");
                entity.Property(e => e.Dp)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("DP");
                entity.Property(e => e.EarnLeave)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("EARN_LEAVE");
                entity.Property(e => e.Ecode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ECODE");
                entity.Property(e => e.EffDate7pay)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Eff_date_7pay");
                entity.Property(e => e.EmergencyAllow)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("EMERGENCY_ALLOW");
                entity.Property(e => e.EmpCodeOld)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entity.Property(e => e.EmpContribution)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("EMP_CONTRIBUTION");
                entity.Property(e => e.EmployeerContribution).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.EnLic)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EN_LIC");
                entity.Property(e => e.EnPli)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EN_PLI");
                entity.Property(e => e.Flag7pay)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Flag_7Pay");
                entity.Property(e => e.GpfAcctNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GPF_ACCT_NO");
                entity.Property(e => e.GpfType)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("GPF_TYPE");
                entity.Property(e => e.Gpfda)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("GPFDA");
                entity.Property(e => e.GpsAmt)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("GPS_AMT");
                entity.Property(e => e.GradePayJan)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("grade_pay_jan");
                entity.Property(e => e.GradePayOld)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("grade_pay_old");
                entity.Property(e => e.GrossPay)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("GROSS_PAY");
                entity.Property(e => e.GssAmt)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("GSS_AMT");
                entity.Property(e => e.Hra)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("HRA");
                entity.Property(e => e.Hra6payLast)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("HRA_6PayLast");
                entity.Property(e => e.HraType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HRA_TYPE");
                entity.Property(e => e.Ifsc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IFSC");
                entity.Property(e => e.ImpDate7pay)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Imp_date_7pay");
                entity.Property(e => e.IsManualContribution)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("isManualContribution");
                entity.Property(e => e.IsResidingCq).HasColumnName("IsResidingCQ");
                entity.Property(e => e.LevelCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("level_code");
                entity.Property(e => e.Mded)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("MDED");
                entity.Property(e => e.MediAllow)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("MEDI_ALLOW");
                entity.Property(e => e.Mpay)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("MPAY");
                entity.Property(e => e.NextIncreDate)
                    .HasColumnType("datetime")
                    .HasColumnName("NEXT_INCRE_DATE");
                entity.Property(e => e.NonPracAllow)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("NON_PRAC_ALLOW");
                entity.Property(e => e.OwfAcctNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Owf_AcctNo");
                entity.Property(e => e.PayBand)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PAY_BAND");
                entity.Property(e => e.PayInPaybandJan)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("Pay_in_payband_jan");
                entity.Property(e => e.PayInPaybandOld)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("Pay_in_payband_old");
                entity.Property(e => e.PayMode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PAY_MODE");
                entity.Property(e => e.PersonalPay)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("PERSONAL_PAY");
                entity.Property(e => e.PhysicalHandicap)
                    .HasMaxLength(5)
                    .IsUnicode(false);
                entity.Property(e => e.PrevIncreDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PREV_INCRE_DATE");
                entity.Property(e => e.RateDa)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("RATE_DA");
                entity.Property(e => e.SpecialAllow)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("SPECIAL_ALLOW");
                entity.Property(e => e.SpecialPay)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("SPECIAL_PAY");
                entity.Property(e => e.TabId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("tabID");
                entity.Property(e => e.UniformAllow)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("UNIFORM_ALLOW");
                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
                entity.Property(e => e.Updatedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEDBY");
                entity.Property(e => e.VechileAllowance).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.WashingAllow)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("WASHING_ALLOW");
            });

            modelBuilder.Entity<EmployeeHindi>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("EmployeeHINDI");

                entity.Property(e => e.Ecode)
                    .HasMaxLength(255)
                    .HasColumnName("ECODE");
                entity.Property(e => e.EmpName)
                    .HasMaxLength(255)
                    .HasColumnName("EMP_NAME");
                entity.Property(e => e.Hindi)
                    .HasMaxLength(255)
                    .HasColumnName("HINDi");
            });

            modelBuilder.Entity<EmpStopSalaryDetail>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("Emp_StopSalary_Detail");

                entity.HasIndex(e => e.Id, "ClusteredIndex-20150211-220550").IsClustered();

                entity.HasIndex(e => e.Ecode, "NonClusteredIndex-20150211-220621");

                entity.Property(e => e.Designation)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Ecode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ECODE");
                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.RowId).ValueGeneratedOnAdd();
            });





        }
        public DbSet<AuditLog> AuditLogs { get; set; } = default!;
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Account>? Accounts { get; set; }
        public virtual DbSet<MCompany> MCompanys { get; set; }
        public DbSet<MDesignationMast> MDesignationMasts { get; set; }
        public virtual DbSet<EmpAttendance> EmpAttendances { get; set; }
        public virtual DbSet<EmpSalaryStructure> EmpSalaryStructures { get; set; }
        public virtual DbSet<EmployeeHindi> EmployeeHindis { get; set; }
        public virtual DbSet<EmpStopSalaryDetail> EmpStopSalaryDetails { get; set; }
        public virtual DbSet<MEmpMast> MEmpMasts { get; set; }
        public virtual DbSet<MEmpMastAddDetail> MEmpMastAddDetails { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added
                || e.State == EntityState.Modified
                || e.State == EntityState.Deleted)
                .ToList();

            foreach (var modifiedEntity in modifiedEntities)
            {
                var auditLog = new AuditLog
                {
                    EntityName = modifiedEntity.Entity.GetType().Name,
                    Action = modifiedEntity.State.ToString(),
                    Timestamp = DateTime.UtcNow,
                    Changes = GetChanges(modifiedEntity)
                };

                AuditLogs.Add(auditLog);
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        private static string GetChanges(EntityEntry entity)
        {
            var changes = new StringBuilder();

            foreach (var property in entity.OriginalValues.Properties)
            {
                var originalValue = entity.OriginalValues[property];
                var currentValue = entity.CurrentValues[property];

                if (!Equals(originalValue, currentValue))
                {
                    changes.AppendLine($"{property.Name}: From '{originalValue}' to '{currentValue}'");
                }
            }

            return changes.ToString();
        }

        //public void OnModelCreatingPartial(ModelBuilder modelBuilder) { };

    }
}
