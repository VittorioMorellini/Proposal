using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Proposal.Core.Models;
using Proposal.Core.Services;
using Proposal.Core.Utils;

namespace Proposal.Core
{
    public static class ServiceCollectionUtils
    {
        public static void AddProposalCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddCore(configuration);
        }

        private static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddScoped(x => x.GetService<IServiceFactory>().Principal);
            services.AddScoped(x => x.GetService<IServiceFactory>().Product);
        }
    }

    public interface IServiceFactory
    {
        IPrincipalService Principal { get; }
        IProductService Product { get; }
    }

    public class ServiceFactory : IServiceFactory
    {
        protected readonly IServiceProvider provider;

        public ServiceFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }

        protected ProposalDbContext dbContext => (ProposalDbContext)provider.GetService(typeof(ProposalDbContext));

        public IPrincipalService Principal => new PrincipalService(
            (ILogger<PrincipalService>)provider.GetService(typeof(ILogger<PrincipalService>)),
            dbContext);
        public virtual IProductService Product => new ProductService(
            (ILogger<ProductService>)provider.GetService(typeof(ILogger<ProductService>)),
            dbContext);
    }

}
