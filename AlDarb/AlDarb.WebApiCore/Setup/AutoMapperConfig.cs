﻿/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using AutoMapper.Configuration;
using AlDarb.Services.Infrastructure.MappingProfiles;

namespace AlDarb.WebApiCore.Setup
{
    public static class AutoMapperConfig
    {
        public static void Configure(MapperConfigurationExpression config)
        {
            config.AllowNullCollections = false;

            config.AddProfile<UserProfile>();
            config.AddProfile<SettingsProfile>();

            config.AddProfile<FieldProfile>();
            config.AddProfile<CourseProfile>();
            config.AddProfile<CourseFieldProfile>();
            config.AddProfile<CourseRatingProfile>();
            config.AddProfile<CourseSessionProfile>();
            config.AddProfile<CourseTaskProfile>();
            config.AddProfile<NotificationProfile>();
            config.AddProfile<ProgressTaskProfile>();
            config.AddProfile<ApplicationForSessionProfile>();
            config.AddProfile<SessionTaskDateProfile>();
            config.AddProfile<DonationProfile>();
            config.AddProfile<DonationPostProfile>();
            config.AddProfile<DonationPostFieldProfile>();
        }
    }
}
