using CQRS_Inventary.Models;
using CQRS_Inventary.Services;
using MediatR;

namespace CQRS_Inventary.Features.Products.Query
{
    public class GetAllProductsQuery: IRequest<IEnumerable<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly IProductsService _productService;

            public GetAllProductsQueryHandler(IProductsService playerService)
            {
                _productService = playerService;
            }

            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                return await _productService.GetProductListAsync();
            }
        }
    }
}
