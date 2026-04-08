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


        }
        public DbSet<AuditLog> AuditLogs { get; set; } = default!;
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Account>? Accounts { get; set; }
        public virtual DbSet<MCompany> MCompanys { get; set; }
        public DbSet<MDesignationMast> MDesignationMasts { get; set; }


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
