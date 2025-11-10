using Application.Common.Models;
using Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Queries.GetById
{
    public class GetByIdQueryHandler<TEntity, TRequest, TResponse>
        where TEntity : BaseAuditableEntity
        where TRequest : GetByIdQuery<TResponse>
        where TResponse : class
    {
        protected readonly AppDbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IMapper Mapper;

        public GetByIdQueryHandler(AppDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
            Mapper = mapper;
        }

        public virtual async Task<BaseResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TEntity? entity = await DbSet.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
             if(entity != null)
            {
                var content = Mapper.Map<TResponse>(entity);
                return new BaseResponse<TResponse>(HttpStatusCode.OK, content);

            }
            return new BaseResponse<TResponse>(
               HttpStatusCode.NotFound,
               content: null
           );

        }
    }
}
