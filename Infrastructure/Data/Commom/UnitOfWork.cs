using PrimeiroAppAws.Infrastructure.Data.Commom.Interfaces;

namespace PrimeiroAppAws.Infrastructure.Data.Commom
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RegisterContext _context;

        public UnitOfWork(RegisterContext context) => _context = context;

        public async Task CommitAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);

        public async Task RollbackAsync(CancellationToken cancellationToken) => await Task.CompletedTask;
    }
}
