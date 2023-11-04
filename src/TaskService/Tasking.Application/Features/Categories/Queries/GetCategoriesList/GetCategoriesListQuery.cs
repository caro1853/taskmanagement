using System;
using MediatR;

namespace Tasking.Application.Features.Categories.Queries.GetCategoriesList
{
	public class GetCategoriesListQuery: IRequest<List<GetCategoriesListVM>>
	{
    }
}

