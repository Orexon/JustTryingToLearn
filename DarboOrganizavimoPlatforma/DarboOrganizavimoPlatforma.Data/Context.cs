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
        public DbSet<ATask> ATasks { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<ProjectTeam> ProjectTeams { get; set; }
        public DbSet<UserAssignment> UserAssignments { get; set; }

        //Connection requires empty construction, on startup configures connection.
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        //Configured in starup.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-L95N66N;Database=DOP;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //TeamUser ManyToMany Connecting table.
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
            builder.Entity<UserAssignment>()
                .HasKey(ua => new { ua.AppUserId, ua.AssignmentId });
            builder.Entity<UserAssignment>()
                .HasOne(ua => ua.AppUser)
                .WithMany(au => au.UserAssignments)
                .HasForeignKey(ua => ua.AppUserId);
            builder.Entity<UserAssignment>()
                .HasOne(ua => ua.Assignment)
                .WithMany(a => a.UsersAssigned)
                .HasForeignKey(ua => ua.AssignmentId);

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

            //Company To ATask/ATask To Company Relationship
            builder.Entity<Company>()
                .HasMany(e => e.Tasks)
                .WithOne(e => e.Company);
            builder.Entity<ATask>()
                .HasOne(e => e.Company)
                .WithMany(e => e.Tasks);

            //Assignment To ATask/ATask To Assignment Relationship
            builder.Entity<Assignment>()
                .HasMany(e => e.AssignmentTasks)
                .WithOne(e => e.Assignment);
            builder.Entity<ATask>()
                .HasOne(e => e.Assignment)
                .WithMany(e => e.AssignmentTasks);

            //Database default table name change
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


            //Admin Seed 
            Guid ADMIN_ID = Guid.NewGuid();
            Guid ADMIN_ROLE = Guid.NewGuid();
            Guid COMPANY_ID = Guid.NewGuid();

            //seed admin role

            builder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE,
                ConcurrencyStamp = "27747190-7b7d-453d-ba7b-5bfa31119160"
            });

            //Create admin company
            var company = new Company
            {
                CompanyId = COMPANY_ID,
                CompanyName = "Admin Company",
                CompanyDescription = "Admin Company",
                CreateTime = DateTime.Now
            };

            //seed user
            builder.Entity<Company>().HasData(company);

            //create user
            var appUser = new AppUser
            {
                Id = ADMIN_ID,
                CompanyId = COMPANY_ID,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEOpvPVTNsK5osJyR0T+4qh/+6m4CKrv7u+KH+rrB+ptHxAyVknaIysUmJm/UTPOhkw==",
                ConcurrencyStamp = "27747190-7b7d-453d-ba7b-5bfa31119160",
                MemberName = "Mindaugas",
                SecurityStamp = "IHDXOW62GL33UAOIJKMU6JBSKSBC63JJ",
                JoinDateTime = DateTime.Now
            };

            //seed user
            builder.Entity<AppUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = ADMIN_ROLE,
                UserId = ADMIN_ID
            });
        }
    }
}