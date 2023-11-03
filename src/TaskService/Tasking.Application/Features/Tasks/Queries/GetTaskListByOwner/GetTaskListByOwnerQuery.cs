using System;
using MediatR;

namespace Tasking.Application.Features.Tasks.Queries.GetTaskListByOwner
{
	public class GetTaskListByOwnerQuery: IRequest<List<TaskVM>>
	{
		internal string OwnerName { get; set; }

        public GetTaskListByOwnerQuery(string ownerName)
        {
            OwnerName = ownerName ?? throw new ArgumentNullException(nameof(ownerName));
        }
    }
}

