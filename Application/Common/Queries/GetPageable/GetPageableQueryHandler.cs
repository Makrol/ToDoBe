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

namespace Application.Common.Queries.GetPageable
{
    public abstract class GetPageableQueryHandler<TEntity,TRequest,TResponse>
        where TEntity : BaseAuditableEntity
        where TRequest : GetPageableQuery<TResponse>
        where TResponse : class
    {
        protected readonly AppDbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IMapper Mapper;
        public GetPageableQueryHandler(AppDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
            Mapper = mapper;
        }
        public async Task<BaseResponse<PaginationResult<TResponse>>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var allElementsQuery = DbSet.Where(e => e.IsActive);

            allElementsQuery = allElementsQuery.Skip((request.PageNumber - 1) * request.PageSize)
                                             .Take(request.PageSize);

            var entities = await allElementsQuery.ToListAsync(cancellationToken);

            var totalCount = await DbSet.CountAsync(cancellationToken);

            var result = Mapper.Map<IEnumerable<TResponse>>(entities);

            return new BaseResponse<PaginationResult<TResponse>>(HttpStatusCode.OK,new PaginationResult<TResponse>(result,totalCount));
        }
    }
}
