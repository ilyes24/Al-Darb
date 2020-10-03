/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using AlDarb.Services;
using AlDarb.Services.Infrastructure;
using AlDarb.DataAccess.EFCore;
using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.Services.Infrastructure.Repositories;
using AlDarb.DataAccess.EFCore.Repositories;

namespace AlDarb.DIContainerCore
{
    public static class ContainerExtension
    {
        public static void Initialize(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IDataBaseInitializer, DataBaseInitializer>();

            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<ISettingsRepository, SettingsRepository>();

            services.AddTransient<IUserService, UserService<User>>();
            services.AddTransient<IUserRepository<User>, UserRepository>();

            services.AddTransient<IIdentityUserRepository<User>, IdentityUserRepository>();

            services.AddTransient<IRoleRepository<Role>, RoleRepository>();

            services.AddTransient<IUserRoleRepository<UserRole>, UserRoleRepository>();

            services.AddTransient<IUserClaimRepository<UserClaim>, UserClaimRepository>();

            
            
            services.AddTransient<ICourseService, CourseService<Course>>();
            services.AddTransient<ICourseRepository<Course>, CourseRepository>();

            services.AddTransient<IFieldService, FieldService<Field>>();
            services.AddTransient<IFieldRepository<Field>, FieldRepository>();

            services.AddTransient<ICourseRatingService, CourseRatingService<CourseRating>>();
            services.AddTransient<ICourseRatingRepository<CourseRating>, CourseRatingRepository>();

            services.AddTransient<ICourseSessionService, CourseSessionService<CourseSession>>();
            services.AddTransient<ICourseSessionRepository<CourseSession>, CourseSessionRepository>();

            services.AddTransient<ICourseTaskService, CourseTaskService<CourseTask>>();
            services.AddTransient<ICourseTaskRepository<CourseTask>, CourseTaskRepository>();

            services.AddTransient<ISessionTaskDateService, SessionTaskDateService<SessionTaskDate>>();
            services.AddTransient<ISessionTaskDateRepository<SessionTaskDate>, SessionTaskDateRepository>();

            services.AddTransient<IProgressTaskService, ProgressTaskService<ProgressTask>>();
            services.AddTransient<IProgressTaskRepository<ProgressTask>, ProgressTaskRepository>();

            services.AddTransient<IApplicationForSessionService, ApplicationForSessionService<ApplicationForSession>>();
            services.AddTransient<IApplicationForSessionRepository<ApplicationForSession>, ApplicationForSessionRepository>();

            services.AddTransient<INotificationService, NotificationService<Notification>>();
            services.AddTransient<INotificationRepository<Notification>, NotificationRepository>();

            services.AddTransient<IDonationService, DonationService<Donation>>();
            services.AddTransient<IDonationRepository<Donation>, DonationRepository>();

            services.AddTransient<IDonationPostService, DonationPostService<DonationPost>>();
            services.AddTransient<IDonationPostRepository<DonationPost>, DonationPostRepository>();

            services.AddTransient<IDonationPostFieldService, DonationPostFieldService<DonationPostField>>();
            services.AddTransient<IDonationPostFieldRepository<DonationPostField>, DonationPostFieldRepository>();

            services.AddTransient<ICourseFieldService, CourseFieldService<CourseField>>();
            services.AddTransient<ICourseFieldRepository<CourseField>, CourseFieldRepository>();
        }
    }
}
