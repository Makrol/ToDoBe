using Application.Common.Queries.GetPageable;
using Domain.Entities;
using Domain.Dtos;
using MapsterMapper;
using Persistence;


namespace Application.Tasks.Queries.GetPageable
{
    public class GetTaskPageableQueryHandler : GetPageableQueryHandler<TaskItem, GetTaskPageableQuery, TaskItemDto>
    {
        public GetTaskPageableQueryHandler(AppDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }
    }
}
