﻿/*
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
        public DbSet<Field> Field { get; set; }
        public DbSet<CourseRating> CourseRating { get; set; }
        public DbSet<CourseSession> CourseSession { get; set; }
        public DbSet<CourseTask> CourseTask { get; set; }
        public DbSet<SessionTaskDate> SessionTaskDate { get; set; }
        public DbSet<ProgressTask> ProgressTask { get; set; }
        public DbSet<ApplicationForSession> ApplicationForSession { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Donation> Donation { get; set; }
        public DbSet<DonationPost> DonationPost { get; set; }
        public DbSet<DonationPostField> DonationPostField { get; set; }
        public DbSet<CourseField> CourseField { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new UserClaimConfig());
            modelBuilder.ApplyConfiguration(new SettingsConfig());

            

            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new FieldConfig());
            modelBuilder.ApplyConfiguration(new CourseRatingConfig());
            modelBuilder.ApplyConfiguration(new CourseSessionConfig());
            modelBuilder.ApplyConfiguration(new CourseTaskConfig());
            modelBuilder.ApplyConfiguration(new SessionTaskDateConfig());
            modelBuilder.ApplyConfiguration(new ProgressTaskConfig());
            modelBuilder.ApplyConfiguration(new ApplicationForSessionConfig());
            modelBuilder.ApplyConfiguration(new NotificationConfig());
            modelBuilder.ApplyConfiguration(new DonationConfig());
            modelBuilder.ApplyConfiguration(new DonationPostConfig());
            modelBuilder.ApplyConfiguration(new DonationPostFieldConfig());
            modelBuilder.ApplyConfiguration(new CourseFieldConfig());

            

            modelBuilder.HasDefaultSchema("starter_core");
        }
    }
}
