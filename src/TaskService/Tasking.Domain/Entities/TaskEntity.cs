using System;
using Tasking.Domain.Common;

namespace Tasking.Domain.Entities
{
	public class TaskEntity: BaseEntity
    {
		public string Name { get; set; }
		public DateTime DeadLine { get; set; }
		public bool IsCompleted { get; set; }

		//Owner
		public int UserId { get; set; }

		//Category
		public int CategoryId { get; set; }

	}
}

