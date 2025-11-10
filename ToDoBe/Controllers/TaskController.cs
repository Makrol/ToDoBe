using Application.Common.Models;
using Application.Tasks.Commands.MarkAsDone;
using Application.Tasks.Queries.GetById;
using Application.Tasks.Queries.GetPageable;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace ToDoBe.Controllers
{
    public class TaskController : BaseApiController
    {
        public TaskController(IMessageBus messageBus) : base(messageBus)
        { }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TaskItemDto>>> Add([FromBody] Application.Tasks.Commands.AddTask.AddTaskCommand command)
        {
            return await ExecuteRequest<Application.Tasks.Commands.AddTask.AddTaskCommand, TaskItemDto>(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<TaskItem>>> GetById(Guid id)
        {
            var query = new GetTaskByIdQuery { Id = id };
            return await ExecuteRequest<GetTaskByIdQuery, TaskItem>(query);
        }
        [HttpGet("pageable")]
        public async Task<ActionResult<BaseResponse<PaginationResult<TaskItemDto>>>> GetPageable([FromQuery] GetTaskPageableQuery query)
        {
            return await ExecuteRequest<GetTaskPageableQuery, PaginationResult<TaskItemDto>>(query);
        }
        [HttpPut("MarkAsDone/{id}")]
        public async Task<ActionResult<BaseResponse>> MarkAsDone(Guid id)
        {
            var command = new MarkAsDoneCommand { Id = id };
            return await ExecuteRequest<MarkAsDoneCommand>(command);
        }
    }
}
