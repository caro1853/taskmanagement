using System;
using AutoMapper;
using MediatR;
using Tasking.Application.Contracts.Persistence;

namespace Tasking.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListHandler : IRequestHandler<GetCategoriesListQuery, List<GetCategoriesListVM>>
    {
        public ICategoryRepository _categoryRepository { get; set; }
        private readonly IMapper _mapper;

        public GetCategoriesListHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetCategoriesListVM>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<GetCategoriesListVM>>(categories);
        }
    }
}

