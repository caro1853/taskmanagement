using System;
using Tasking.Application.Contracts.Persistence;
using Tasking.Domain.Entities;
namespace Tasking.Application.Contracts.Persistence
{
	public interface ITaskRepository : IAsyncRepository<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetTaskListByOwner(string ownerName);
    }
}

