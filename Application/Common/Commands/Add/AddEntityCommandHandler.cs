using Application.Common.Models;
using Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.Common.Commands.Add
{
    public class AddEntityCommandHandler<TEntity,TRequest,TResponse>
        where TEntity : BaseAuditableEntity
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;
        protected readonly IMapper _mapper;


        protected AddEntityCommandHandler(DbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
            dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<BaseResponse<TResponse>> Handle(TRequest command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var entity = _mapper.Map<TEntity>(command);

            dbSet.Add(entity);

            await dbContext.SaveChangesAsync();

            var response = _mapper.Map<TResponse>(entity);

            return new BaseResponse<TResponse>(HttpStatusCode.Created, response);
        }

    }
}
