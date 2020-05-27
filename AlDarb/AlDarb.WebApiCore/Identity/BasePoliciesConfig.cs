/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Microsoft.AspNetCore.Authorization;

namespace AlDarb.WebApiCore.Identity
{
    public static class BasePoliciesConfig
    {
        public static void RegisterPolicies(this AuthorizationOptions opt)
        {
            opt.AddPolicy("AdminOnly", policy => policy.RequireRole(Roles.Admin));
        }
    }
}
