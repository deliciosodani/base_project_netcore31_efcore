using eClinica.Infrastructure.Data;
using eClinica.Infrastructure.Data.Entities;
using eClinica.Infrastructure.Interfaces;
using eClinica.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eClinica.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        private IBaseRepository<AtencionDelDia> _atencionDelDiaRepository;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;            
        }

        public IBaseRepository<AtencionDelDia> AtencionDelDia => _atencionDelDiaRepository ??= new BaseRepository<AtencionDelDia>(_dataContext);        

        public async Task<int> CommitAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public void RollBack()
        {
            _dataContext.ChangeTracker.Entries()
                .Where(e => e.Entity != null).ToList()
                .ForEach(e => e.State = EntityState.Detached);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
