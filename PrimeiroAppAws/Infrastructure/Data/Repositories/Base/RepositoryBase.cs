using Microsoft.EntityFrameworkCore;
using PrimeiroAppAws.Domain.Entities.Base;
using PrimeiroAppAws.Domain.Interfaces.Base;
using PrimeiroAppAws.Infrastructure.Data.Commom;

namespace PrimeiroAppAws.Infrastructure.Data.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseModel
    {
        protected readonly RegisterContext _context;
        public RepositoryBase(RegisterContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            await Task.FromResult(_context.Set<T>().Remove(entity));
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            await Task.FromResult(_context.Set<T>().Update(entity));
        }
    }
}
