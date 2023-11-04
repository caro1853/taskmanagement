using System;
using Tasking.Domain.Entities;

namespace Tasking.Application.Contracts.Persistence
{
	public interface ICategoryRepository : IAsyncRepository<CategoryEntity>
    {
	}
}

