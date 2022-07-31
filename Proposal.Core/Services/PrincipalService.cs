using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Proposal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Proposal.Core.Utils;

namespace Proposal.Core.Services
{
    public interface IPrincipalService : IBaseService<Principal, long, ProposalDbContext>
    {
        IEnumerable<Principal> Search(PrincipalSearchModel model);
        bool PrincipalnameExists(string principalname);
    }

    public class PrincipalService : BaseService<Principal, long, ProposalDbContext>, IPrincipalService
    {
        private readonly ILogger<PrincipalService> logger;
        public PrincipalService(ILogger<PrincipalService> logger, ProposalDbContext ctx = null)
            : base(ctx)
        {
            this.logger = logger;
        }

        public override Principal Find(long id)
        {   
            return ctx.Principal
                .Where(x => x.Id == id).FirstOrDefault();
        }


        public IEnumerable<Principal> Search(PrincipalSearchModel model)
        {
            var query = ctx.Principal.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.Surname))
                query = query.Where(x => x.Surname.StartsWith(model.Surname));
            if (!string.IsNullOrWhiteSpace(model.Name))
                query = query.Where(x => x.Name.StartsWith(model.Name));
            if (!string.IsNullOrWhiteSpace(model.Username))
                query = query.Where(x => x.Username.StartsWith(model.Username));
            if (!string.IsNullOrWhiteSpace(model.Role))
                query = query.Where(x => x.Role == model.Role);

            //Paging Server side
            query = query.ApplyPaging(model);
            
            return query.ToList();
        }

        
        public bool PrincipalnameExists(string username)
        {
            return ctx.Principal.Where(x => x.Username == username).Any();
        }

    }

    public class PrincipalSearchModel : QueryBuilderSearchModel
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }
        public string? Role { get; set; }
        public bool? Disabled { get; set; }
    }

}