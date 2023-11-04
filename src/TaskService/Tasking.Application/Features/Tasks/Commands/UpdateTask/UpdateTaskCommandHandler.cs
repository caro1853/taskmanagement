using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tasking.Application.Contracts.Persistence;
using Tasking.Domain.Entities;

namespace Tasking.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTaskCommandHandler> _logger;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository, ICategoryRepository categoryRepository, IMapper mapper, ILogger<UpdateTaskCommandHandler> logger)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskToUpdate = await _taskRepository.GetByIdAsync(request.Id);
            if(taskToUpdate == null)
            {
                throw new ApplicationException($"Task with ({request.Id}) was not found.");
            }

            //Map Entities
            taskToUpdate.Name = request.Name ?? taskToUpdate.Name;
            taskToUpdate.DeadLine = request.DeadLine ?? taskToUpdate.DeadLine;
            taskToUpdate.IsCompleted = request.IsCompleted ?? taskToUpdate.IsCompleted;
            taskToUpdate.UserId = request.UserId ?? taskToUpdate.UserId;
            if (request.CategoryId.HasValue)
            {
                var category = await _categoryRepository.GetByIdAsync(request.CategoryId.Value);
                if (category == null)
                {
                    throw new ApplicationException($"Category with ({request.CategoryId.Value}) was not found.");
                }
                taskToUpdate.Category = category;
            }
            await _taskRepository.UpdateAsync(taskToUpdate);

            _logger.LogInformation($"Task {taskToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}

