using System;
using AutoMapper;
using Tasking.Application.Features.Tasks.Commands.CreateTask;
using Tasking.Application.Features.Tasks.Queries.GetTaskById;
using Tasking.Application.Features.Tasks.Queries.GetTaskListByOwner;
using Tasking.Domain.Entities;

namespace Tasking.Application.Mappings
{
	public class MappingProfile : Profile
    {
		public MappingProfile()
		{
			CreateMap<TaskEntity, TaskVM>().ReverseMap();
            CreateMap<TaskEntity, TaskByIdVM>().ReverseMap();
            CreateMap<TaskEntity, CreateTaskCommand>().ReverseMap();
		}
	}
}

