using Application.Common.Commands.Add;
using Domain.Dtos;
using Domain.Entities;
using MapsterMapper;
using Persistence;
namespace Application.Tasks.Commands.AddTask
{
    public class AddTaskCommandHandler : AddEntityCommandHandler<TaskItem,AddTaskCommand, TaskItemDto>
    {
        public AddTaskCommandHandler(AppDbContext db, IMapper mapper)
            :base(db,mapper)
        {

        }
    }
}
