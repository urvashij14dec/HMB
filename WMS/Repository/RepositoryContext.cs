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
            modelBuilder.Entity<MOrganisation>(entity =>
            {
                entity.HasKey(e => e.TableId);

                entity.ToTable("M_Organisation");

                entity.Property(e => e.TableId).HasColumnName("TableID");
                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Ceoname)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CEOName");
                entity.Property(e => e.Contact)
                    .HasMaxLength(64)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(32);
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasAnnotation("Relational:DefaultConstraintName", "DF_M_Organisation_CreatedDate")
                    .HasColumnType("datetime");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Fax)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fax");
                entity.Property(e => e.Logo)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.LogoName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
                entity.Property(e => e.Pan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PAN");
                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.RegistrationDt).HasColumnType("datetime");
                entity.Property(e => e.RegistrationNum)
                    .HasMaxLength(16)
                    .IsUnicode(false);
                entity.Property(e => e.SelfFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("'1' --> Identifies MAP_IT entry, null or '0' --> Identifies other government departments entries");
                entity.Property(e => e.Shname)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SHName");
                entity.Property(e => e.UpdatedBy).HasMaxLength(32);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.Website)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("website");
            });

            //OnModelCreatingPartial(modelBuilder);

        }
        public DbSet<AuditLog> AuditLogs { get; set; } = default!;
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Account>? Accounts { get; set; }
        public virtual DbSet<MOrganisation> MOrganisations { get; set; }


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
