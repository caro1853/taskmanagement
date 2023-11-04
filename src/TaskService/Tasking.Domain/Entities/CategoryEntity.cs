using System;
using Tasking.Domain.Common;

namespace Tasking.Domain.Entities
{
	public class CategoryEntity : BaseEntity
    {
		public string? Name { get; set; }
        public CategoryEntity()
        {
        }

        public CategoryEntity(int id)
		{
			this.Id = id;
		}
		
	}
}

