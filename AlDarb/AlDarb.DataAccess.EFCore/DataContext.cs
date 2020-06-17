/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using AlDarb.DataAccess.EFCore.Configuration;
using AlDarb.DataAccess.EFCore.Configuration.System;
using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlDarb.DataAccess.EFCore
{
    public class DataContext : DbContext
    {
        public ContextSession Session { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<Settings> Settings { get; set; }

        public DbSet<Course> Course { get; set; }
        public DbSet<CourseSession> CourseSession { get; set; }
        public DbSet<CourseTask> CourseTask { get; set; }
        public DbSet<ProgressTask> ProgressTask { get; set; }
        public DbSet<ApplicationForSession> ApplicationForSession { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new UserClaimConfig());
            modelBuilder.ApplyConfiguration(new UserPhotoConfig());
            modelBuilder.ApplyConfiguration(new SettingsConfig());

            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new CourseSessionConfig());
            modelBuilder.ApplyConfiguration(new CourseTaskConfig());
            modelBuilder.ApplyConfiguration(new ProgressTaskConfig());
            modelBuilder.ApplyConfiguration(new ApplicationForSessionConfig());
            modelBuilder.ApplyConfiguration(new NotificationConfig());

            modelBuilder.HasDefaultSchema("starter_core");
        }
    }
}
