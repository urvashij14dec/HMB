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
