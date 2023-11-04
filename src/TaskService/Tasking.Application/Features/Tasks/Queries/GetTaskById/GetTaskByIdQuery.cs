using System;
using AutoMapper;
using MediatR;
using Tasking.Application.Contracts.Persistence;

namespace Tasking.Application.Features.Tasks.Queries.GetTaskById
{
    public class GetTaskByIdQuery: IRequest<TaskByIdVM>
    {
        internal int Taskid { get; set; }

        public GetTaskByIdQuery(int taskid)
        {
            Taskid = taskid;
        }
    }
}

