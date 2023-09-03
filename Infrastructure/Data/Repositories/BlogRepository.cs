using PrimeiroAppAws.Domain.Entities;
using PrimeiroAppAws.Domain.Interfaces;
using PrimeiroAppAws.Infrastructure.Data.Commom;
using PrimeiroAppAws.Infrastructure.Data.Repositories.Base;

namespace PrimeiroAppAws.Infrastructure.Data.Repositories
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(RegisterContext context) : base(context)
        {
                
        }
    }
}
