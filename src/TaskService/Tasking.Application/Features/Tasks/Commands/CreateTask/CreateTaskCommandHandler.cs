using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tasking.Application.Contracts.Persistence;
using Tasking.Domain.Entities;

namespace Tasking.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTaskCommandHandler> _logger;

        public CreateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper, ILogger<CreateTaskCommandHandler> logger)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            //Map
            var taskEntity = new TaskEntity();
            taskEntity.Name = request.Name;
            taskEntity.DeadLine = request.DeadLine ?? taskEntity.DeadLine;
            taskEntity.UserId = request.UserId;
            if (request.CategoryId.HasValue)
                taskEntity.Category = new CategoryEntity(request.CategoryId.Value);

            var newTaskEntity = await _taskRepository.AddAsync(taskEntity);

            _logger.LogInformation($"Task {newTaskEntity.Id} is successfully created.");
            return newTaskEntity.Id;
        }
    }
}

