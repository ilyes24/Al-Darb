/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using AlDarb.DTO;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure;
using AlDarb.Utils;
using System.Threading.Tasks;

namespace AlDarb.Services
{
    public class SettingsService : BaseService, ISettingsService
    {
        protected readonly ISettingsRepository settingsRepository;

        public SettingsService(ICurrentContextProvider contextProvider, ISettingsRepository settingsRepository) : base(contextProvider)
        {
            this.settingsRepository = settingsRepository;
        }

        public async Task<SettingsDTO> Edit(SettingsDTO dto)
        {
            var settings = dto.MapTo<Settings>();
            await settingsRepository.Edit(settings, Session);
            return settings.MapTo<SettingsDTO>();
        }

        public async Task<SettingsDTO> GetById(int id)
        {
            var user = await settingsRepository.Get(id, Session);
            return user.MapTo<SettingsDTO>();
        }
    }
}
