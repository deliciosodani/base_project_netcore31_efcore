using eClinica.Models.Atenciones.AtencionesDelDia;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eClinica.Core.Interfaces
{
    public interface IAtencionDelDiaService
    {
        Task<IEnumerable<AtencionDelDiaModel>> GetAllAsync();
        IEnumerable<AtencionDelDiaModel> GetAllByUserAsync(long id);
        Task<AtencionDelDiaModel> GetByIdAsync(long id);
        Task<bool> AddAsync(AtencionDelDiaRequestModel entity);
        Task UpdateAsync(AtencionDelDiaRequestModel entity, long Id);
        Task DeleteAsync(long id);
    }
}
