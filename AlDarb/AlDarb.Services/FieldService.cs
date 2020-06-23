using AlDarb.DTO;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure;
using AlDarb.Services.Infrastructure.Repositories;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services
{
    public class FieldService<TField> : BaseService, IFieldService where TField : Field, new()
    {
        protected readonly IFieldRepository<TField> fieldRepository;

        public FieldService(ICurrentContextProvider contextProvider, IFieldRepository<TField> fieldRepository) : base(contextProvider)
        {
            this.fieldRepository = fieldRepository;
        }

        public async Task<IEnumerable<FieldDTO>> GetList(bool includeDeleted = false)
        {
            var entitiy = await fieldRepository.GetList(Session, includeDeleted);
            return entitiy.MapTo<IEnumerable<FieldDTO>>();
        }

        public async Task<bool> Delete(int id)
        {
            await fieldRepository.Delete(id, Session);
            return true;
        }

        public async Task<FieldDTO> Edit(FieldDTO dto)
        {
            var field = dto.MapTo<TField>();
            await fieldRepository.Edit(field, Session);
            return field.MapTo<FieldDTO>();
        }

        public async Task<FieldDTO> GetById(int id, bool includeDeleted = false)
        {
            var field = await fieldRepository.Get(id, Session, includeDeleted);
            return field.MapTo<FieldDTO>();
        }
    }
}
