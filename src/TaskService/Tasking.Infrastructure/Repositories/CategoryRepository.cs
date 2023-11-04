using System;
using Tasking.Application.Contracts.Persistence;
using Tasking.Domain.Entities;
using Tasking.Infrastructure.Persistence;

namespace Tasking.Infrastructure.Repositories
{
	public class CategoryRepository: RepositoryBase<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(TaskContext dbContext) : base(dbContext)
        {
        }
    }
}

