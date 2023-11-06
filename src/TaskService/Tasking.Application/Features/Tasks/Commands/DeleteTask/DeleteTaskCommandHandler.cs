using System;
using MediatR;
using Tasking.Application.Contracts.Persistence;

namespace Tasking.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskToDelete = await _taskRepository.GetByIdAsync(request.Taskid);
            if (taskToDelete == null)
            {
                throw new ApplicationException($"Task with ({request.Taskid}) was not found.");
            }

            await _taskRepository.DeleteAsync(taskToDelete);
            return Unit.Value;
        }
    }
}

