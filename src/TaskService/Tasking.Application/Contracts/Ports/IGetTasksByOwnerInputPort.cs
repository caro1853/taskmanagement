using System;
namespace Tasking.Application.Contracts.Ports
{
	public interface IGetTasksByOwnerInputPort
	{
		Task Handler(string userName);
	}
}

