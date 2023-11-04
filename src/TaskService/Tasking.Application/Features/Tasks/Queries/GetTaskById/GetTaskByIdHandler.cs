using System;
using AutoMapper;
using MediatR;
using Tasking.Application.Contracts.Persistence;

namespace Tasking.Application.Features.Tasks.Queries.GetTaskById
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskByIdVM>
    {
        public ITaskRepository _taskRepository { get; set; }
        private readonly IMapper _mapper;

        public GetTaskByIdHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TaskByIdVM> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Taskid);
            return _mapper.Map<TaskByIdVM>(task);
        }
    }
}

