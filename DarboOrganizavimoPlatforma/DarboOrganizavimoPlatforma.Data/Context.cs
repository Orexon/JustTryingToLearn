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
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<ProjectTeam> ProjectTeams { get; set; }
        public DbSet<UserAssingment> UserAssingments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-L95N66N;Database=DOP;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        // make Delete+- foreach user in List<appuser> remove from list. if list is empty. Delete. 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<TeamUser>()
                .HasKey(tu => new { tu.AppUserId, tu.TeamId });
            builder.Entity<TeamUser>()
                .HasOne(tu => tu.AppUser)
                .WithMany(au => au.TeamUsers)
                .HasForeignKey(tu => tu.AppUserId);
            builder.Entity<TeamUser>()
                .HasOne(tu => tu.Team)
                .WithMany(t => t.TeamUsers)
                .HasForeignKey(tu => tu.TeamId);

            //Project To Team/Team To Project Relationship
            builder.Entity<ProjectTeam>()
                .HasKey(pt => new { pt.ProjectId, pt.TeamId });
            builder.Entity<ProjectTeam>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTeams)
                .HasForeignKey(pt => pt.ProjectId);
            builder.Entity<ProjectTeam>()
                .HasOne(pt => pt.Team)
                .WithMany(t => t.ProjectTeams)
                .HasForeignKey(pt => pt.TeamId);

            //AppUser To Assignment/Assignment To AppUser Relationship
            builder.Entity<UserAssingment>()
                .HasKey(ua => new { ua.AppUserId, ua.AssingmentId });
            builder.Entity<UserAssingment>()
                .HasOne(ua => ua.AppUser)
                .WithMany(au => au.UserAssignments)
                .HasForeignKey(ua => ua.AppUserId);
            builder.Entity<UserAssingment>()
                .HasOne(ua => ua.Assignment)
                .WithMany(a => a.UsersAssigned)
                .HasForeignKey(ua => ua.AssingmentId);

            //AppUser To Company/Company To AppUser Relationship
            builder.Entity<AppUser>()
                .HasOne(e => e.Company)
                .WithMany(c => c.AppUsers);
            builder.Entity<Company>()
                .HasMany(e => e.AppUsers)
                .WithOne(e => e.Company);

            //Company To Team/Team To Company Relationship
            builder.Entity<Company>()
                .HasMany(e => e.Teams)
                .WithOne(e => e.Company);
            builder.Entity<Team>()
                .HasOne(e => e.Company)
                .WithMany(e => e.Teams);

            //Company To Project/Project To Company Relationship
            builder.Entity<Company>()
                .HasMany(e => e.CompanyProjects)
                .WithOne(e => e.Company);
            builder.Entity<Project>()
                .HasOne(e => e.Company)
                .WithMany(e => e.CompanyProjects);


            //builder.Entity<Project>()
            //    .HasMany(e => e.ProjectTeams)
            //    .WithOne(e => e.Project);
            //builder.Entity<Team>()
            //    .HasOne(e => e.Project)
            //    .WithMany(e => e.ProjectTeams);

            //Database table names
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