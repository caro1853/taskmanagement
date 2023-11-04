using System;
using AutoMapper;
using MediatR;
using Tasking.Application.Contracts.Persistence;

namespace Tasking.Application.Features.Tasks.Queries.GetTasksListByOwnerByCategory
{
    public class GetTasksListByOwnerByCategoryHandler : IRequestHandler<GetTasksListByOwnerByCategoryQuery, List<TaskListByOwnerByCategoryVM>>
    {
        public ITaskRepository _taskRepository { get; set; }
        private readonly IMapper _mapper;

        public GetTasksListByOwnerByCategoryHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<TaskListByOwnerByCategoryVM>> Handle(GetTasksListByOwnerByCategoryQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetTaskListByUserByCategory(request.UserId, request.CategorId);
            return _mapper.Map<List<TaskListByOwnerByCategoryVM>>(tasks);
        }
    }
}

