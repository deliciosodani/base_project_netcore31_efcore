using eClinica.Infrastructure;
using eClinica.Infrastructure.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CapacFeria.Infrastructure.Repositories
{
    public class ResilientTransaction
    {
        // Uso 
        //await ResilientTransaction.ExecuteAsync<Repository<TEntity>>(async (repo) =>
        //    {
        //    await repo.AddAsync(entity);
        //    await repo.AddAsync(entity);
        //    await repo.AddAsync(entity);

        //    //Ejmplo de Error:
        //    new Exception("Custom Error");
        //});
        public static async Task ExecuteAsync<T>(Func<T, Task> action)
        {
            var logger = ServiceLocator.Current.GetInstance<ILogger<ResilientTransaction>>();
            var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            try
            {
                var repository = unitOfWork.GetValue<T>();
                await action(repository);
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                unitOfWork.RollBack();
            }
        }
    }
}
