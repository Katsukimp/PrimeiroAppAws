using Microsoft.EntityFrameworkCore;
using PrimeiroAppAws.Domain.Interfaces;
using PrimeiroAppAws.Infrastructure.Data.Commom;
using PrimeiroAppAws.Infrastructure.Data.Commom.Interfaces;
using PrimeiroAppAws.Infrastructure.Data.Repositories;

namespace PrimeiroAppAws.Infrastructure.Data.Setup
{
    public static class SetupEnvironment
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services) => services.AddTransient<IUnitOfWork, UnitOfWork>();

        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services
                .AddTransient<IBlogRepository, BlogRepository>()
                .AddTransient<IPostRepository, PostRepository>();

        public static IServiceCollection AddContext(this IServiceCollection services) => services.AddDbContext<RegisterContext>(x => x.UseInMemoryDatabase("Teste"));
    }
}