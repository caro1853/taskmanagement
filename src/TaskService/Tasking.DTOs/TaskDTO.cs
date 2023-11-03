using System;
namespace Tasking.DTOs
{
	public class TaskDTO
	{
        public string? Name { get; set; }
        public DateTime? DeadLine { get; set; }

        //Owner
        public int? UserId { get; set; }

        //Category
        public int? CategoryId { get; set; }
    }
}

