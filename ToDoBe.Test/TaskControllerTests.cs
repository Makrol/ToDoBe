using Application.Common.Models;
using Application.Tasks.Commands.AddTask;
using Domain.Dtos;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistance.Interceptors;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoBe.Controllers;
using Wolverine;
using Xunit;

namespace ToDoBe.Tests.Controllers
{
    public class TaskControllerTests
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public TaskControllerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var auditableInterceptor = new Mock<AuditableInterceptor>().Object;

            _dbContext = new AppDbContext(options, auditableInterceptor);

            var config = new TypeAdapterConfig();
            _mapper = new Mapper(config);
        }

        [Fact]
        public async Task Add_ReturnsCreatedResponse()
        {
            var mockBus = new Mock<IMessageBus>();

            var taskDto = new TaskItemDto
            {
                Id = Guid.NewGuid(),
                Title = "Test Task",
                Description = "Test Description",
                IsDone = false
            };

            var response = new BaseResponse<TaskItemDto>(System.Net.HttpStatusCode.Created, taskDto);

            mockBus
            .Setup(bus => bus.InvokeAsync<BaseResponse<TaskItemDto>>(
                It.IsAny<AddTaskCommand>(),
                It.IsAny<CancellationToken>(),
                null 
            ))
            .ReturnsAsync(new BaseResponse<TaskItemDto>(
                System.Net.HttpStatusCode.Created,
                new TaskItemDto { Id = taskDto.Id, Title = "Test Task", Description = "Test Description", IsDone = false }
            ));

            var controller = new TaskController(mockBus.Object);

            var command = new AddTaskCommand
            {
                Title = "Test Task",
                Description = "Test Description",
                IsDone = false
            };

            var result = await controller.Add(command);

            var createdResult = Assert.IsType<CreatedResult>(result.Result);
            var baseResponse = Assert.IsType<BaseResponse<TaskItemDto>>(createdResult.Value);

            Assert.Equal(taskDto.Id, baseResponse.Content.Id);
            Assert.Equal("Test Task", baseResponse.Content.Title);
            Assert.Equal("Test Description", baseResponse.Content.Description);
            Assert.False(baseResponse.Content.IsDone);
        }

   
       

        [Fact]
        public async Task Handle_Should_Add_Task_And_Return_Created_Response()
        {
            var handler = new AddTaskCommandHandler(_dbContext, _mapper);
            var command = new AddTaskCommand
            {
                Title = "Test Task",
                Description = "Test Description",
                IsDone = false
            };

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.Created, result.StatusCode);
            Assert.NotNull(result.Content);
            Assert.Equal("Test Task", result.Content.Title);

            var taskInDb = await _dbContext.Tasks.FirstOrDefaultAsync();
            Assert.NotNull(taskInDb);
            Assert.Equal("Test Task", taskInDb.Title);
        }
    }
}
