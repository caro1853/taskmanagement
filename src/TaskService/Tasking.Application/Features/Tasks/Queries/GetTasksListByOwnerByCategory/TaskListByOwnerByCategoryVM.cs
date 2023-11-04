using System;

namespace Tasking.Application.Features.Tasks.Queries.GetTasksListByOwnerByCategory
{
	public class TaskListByOwnerByCategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Deadline { get; set; }
        public string Deadlineview
        {
            get
            {
                if (!this.Deadline.HasValue)
                    return "";

                var d = "";
                d = this.Deadline.Value.ToString("yyyy-MM-dd");
                return d;
            }
        }
        public bool? Iscompleted { get; set; }

        //Category
        public CategoryListByOwnerByCategoryVM? Category { get; set; }
    }
}

