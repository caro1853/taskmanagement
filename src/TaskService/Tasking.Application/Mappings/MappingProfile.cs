using System;
using AutoMapper;
using Tasking.Application.Features.Categories.Queries.GetCategoriesList;
using Tasking.Application.Features.Tasks.Commands.CreateTask;
using Tasking.Application.Features.Tasks.Queries.GetTaskById;
using Tasking.Application.Features.Tasks.Queries.GetTaskListByOwner;
using Tasking.Application.Features.Tasks.Queries.GetTasksListByOwnerByCategory;
using Tasking.Domain.Entities;

namespace Tasking.Application.Mappings
{
	public class MappingProfile : Profile
    {
		public MappingProfile()
		{
			CreateMap<TaskEntity, TaskVM>().ReverseMap();
            CreateMap<CategoryEntity, CategoryVM>().ReverseMap();

            CreateMap<TaskEntity, TaskByIdVM>().ReverseMap();
            CreateMap<CategoryEntity, CategoryByIdVM>().ReverseMap();

            CreateMap<CategoryEntity, GetCategoriesListVM>().ReverseMap();

            CreateMap<TaskEntity, TaskListByOwnerByCategoryVM>().ReverseMap();
            CreateMap<CategoryEntity, CategoryListByOwnerByCategoryVM>().ReverseMap();
       
            CreateMap<TaskEntity, CreateTaskCommand>().ReverseMap();
		}
	}
}

