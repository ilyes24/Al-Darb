﻿/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

namespace AlDarb.Entities
{
    public class UserClaim : BaseEntity
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
    }
}
