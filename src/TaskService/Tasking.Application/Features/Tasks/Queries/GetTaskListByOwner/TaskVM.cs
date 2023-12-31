﻿using System;
using Tasking.Domain.Entities;

namespace Tasking.Application.Features.Tasks.Queries.GetTaskListByOwner
{
	public class TaskVM
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
        public CategoryVM? Category { get; set; }
    }
}

