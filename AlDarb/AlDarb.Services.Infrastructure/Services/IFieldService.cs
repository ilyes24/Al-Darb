using AlDarb.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface IFieldService
    {
        Task<IEnumerable<FieldDTO>> GetList(bool includeDeleted = false);
        Task<FieldDTO> GetById(int id, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<FieldDTO> Edit(FieldDTO dto);
    }
}
