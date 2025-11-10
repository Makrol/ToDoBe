using Application.Common.Queries.GetById;
using Domain.Entities;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetById
{
    public class GetTaskByIdQueryHandler : GetByIdQueryHandler<TaskItem, GetTaskByIdQuery, TaskItem>
    {
        public GetTaskByIdQueryHandler(AppDbContext dbContext, MapsterMapper.IMapper mapper)
            : base(dbContext, mapper)
        {
        }
    }
}
