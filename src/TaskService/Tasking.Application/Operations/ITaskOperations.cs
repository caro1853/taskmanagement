using System;
using Tasking.Application.DTOs;

namespace Tasking.Application.Operations
{
    public interface ITaskOperations
    {
        Task<IEnumerable<TaskDTO>> GetTasksByOwner(string ownerName);
    }
}

