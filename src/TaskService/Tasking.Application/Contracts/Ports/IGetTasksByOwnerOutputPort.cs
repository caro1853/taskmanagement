using System;
using Tasking.Application.DTOs;

namespace Tasking.Application.Contracts.Ports
{
	public interface IGetTasksByOwnerOutputPort
	{
        Task Handler(IEnumerable<TaskDTO> lstTasks);
    }
}

