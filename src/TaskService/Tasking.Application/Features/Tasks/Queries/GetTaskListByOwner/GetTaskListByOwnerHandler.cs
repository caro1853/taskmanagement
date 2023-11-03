using System;
using MediatR;
using AutoMapper;

using Tasking.Application.Contracts.Persistence;

namespace Tasking.Application.Features.Tasks.Queries.GetTaskListByOwner
{
	public class GetTaskListByOwnerHandler : IRequestHandler<GetTaskListByOwnerQuery, List<TaskVM>>
    {
		public ITaskRepository _taskRepository { get; set; }
        private readonly IMapper _mapper;

        public GetTaskListByOwnerHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<TaskVM>> Handle(GetTaskListByOwnerQuery request, CancellationToken cancellationToken)
        {
            var taskListByOwner = await _taskRepository.GetTaskListByOwner(request.OwnerName);
            return _mapper.Map<List<TaskVM>>(taskListByOwner);
        }
    }
}

