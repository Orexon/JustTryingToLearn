using DarboOrganizavimoPlatforma.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarboOrganizavimoPlatforma.Data
{
    public class Context : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-L95N66N;Database=DOP;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        // make Delete foreach user in List<appuser> remove from list. if list is empty. Delete. 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TeamUser>()
                .HasKey(tu => new { tu.AppUserId, tu.TeamId });
            builder.Entity<TeamUser>()
                .HasOne(tu => tu.AppUser)
                .WithMany(au => au.TeamUsers)
                .HasForeignKey(tu=> tu.AppUserId);
            builder.Entity<TeamUser>()
                .HasOne(tu => tu.Team)
                .WithMany(t => t.TeamUsers)
                .HasForeignKey(tu => tu.TeamId);

            //AppUser To Company/Company To AppUser Relationshiop
            builder.Entity<AppUser>()
                .HasOne(e => e.Company)
                .WithMany(c => c.AppUsers);
            builder.Entity<Company>()
                .HasMany(e => e.AppUsers)
                .WithOne(e => e.Company);

            //Team To Company/Company To Team Relationshiop
            //builder.Entity<Team>()
            //    .HasOne(e => e.Company)
            //    .WithMany(e => e.Teams);
            //builder.Entity<Company>()
            //    .HasMany(e => e.Teams)
            //    .WithOne(e => e.Company);

            //AppUser to TeamUser to Team Relationship
            //builder.Entity<TeamUser>()
            //.HasOne(tu => tu.Team)
            //.WithMany(tm => tm.TeamUsers)
            //.HasForeignKey(tus => tus.TeamId)
            //.OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<TeamUser>()
            //.HasOne(tu => tu.AppUser)
            //.WithMany(au => au.TeamUsers)
            //.HasForeignKey(tus => tus.AppUserId)
            //.OnDelete(DeleteBehavior.NoAction);


            //Database tables names
            builder.HasDefaultSchema("Identity");
            builder.Entity<AppUser>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
            });
            builder.Entity<IdentityRole<Guid>>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
            });
            builder.Entity<AppUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole<Guid>>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<Guid>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<Guid>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<Guid>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}