using PrimeiroAppAws.Domain.Entities;
using PrimeiroAppAws.Domain.Interfaces;
using PrimeiroAppAws.Infrastructure.Data.Commom;
using PrimeiroAppAws.Infrastructure.Data.Repositories.Base;

namespace PrimeiroAppAws.Infrastructure.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RegisterContext context) : base(context)
        {
            
        }
    }
}
