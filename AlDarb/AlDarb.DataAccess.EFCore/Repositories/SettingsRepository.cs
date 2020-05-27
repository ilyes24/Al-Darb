/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using AlDarb.Entities;
using AlDarb.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AlDarb.DataAccess.EFCore
{
    public class SettingsRepository : BaseRepository<Settings, DataContext>, ISettingsRepository
    {
        public SettingsRepository(DataContext context) : base(context) { }

        public override async Task<bool> Exists(Settings obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Settings.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public override async Task<Settings> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Settings.Where(obj => obj.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
