using System;
using MediatR;

namespace Tasking.Application.Features.Tasks.Queries.GetTasksListByOwnerByCategory
{
	public class GetTasksListByOwnerByCategoryQuery: IRequest<List<TaskListByOwnerByCategoryVM>>
	{
        internal int UserId { get; set; }
        internal int CategorId { get; set; }

        public GetTasksListByOwnerByCategoryQuery(int userid, int categoryid)
		{
			this.UserId = userid;
			this.CategorId = categoryid;
		}
	}
}

