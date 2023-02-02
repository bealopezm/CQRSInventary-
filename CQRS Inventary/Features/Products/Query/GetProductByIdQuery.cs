using CQRS_Inventary.Models;
using CQRS_Inventary.Services;
using MediatR;

namespace CQRS_Inventary.Features.Products.Query
{
    public class GetProductByIdQuery: IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IProductsService _productsService;
            public GetProductByIdQueryHandler(IProductsService productsService)
            {
                _productsService = productsService;
            }

            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellation)
            {
                return await _productsService.GetProductByIdAsync(query.Id);
            }
        }
    }
}
