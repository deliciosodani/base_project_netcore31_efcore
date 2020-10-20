using eClinica.Infrastructure.Data.Entities;
using eClinica.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace eClinica.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<AtencionDelDia> AtencionDelDia { get; }
        Task<int> CommitAsync();
        void RollBack();
    }
}
