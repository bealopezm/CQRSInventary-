using CQRS_Inventary.Models;
using CQRS_Inventary.Services;
using MediatR;

namespace CQRS_Inventary.Features.Products.Commands
{
    public class CreateProductCommand: IRequest<Product>
    {
        public string ProductName { get; set; }
        public DateTime ProductExpirationDate { get; set; }
        public string ProductType { get; set; }
        public double ProductNetPrice { get; set; }
        public double ProductWeight { get; set; }
        public byte ProductQuantity { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
        {
            private readonly IProductsService _productsService;
            public CreateProductCommandHandler(IProductsService productsService)
            {
                _productsService = productsService;
            }

            public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellation) 
            {
                var product = new Product()
                {
                    ProductName = command.ProductName,
                    ProductExpirationDate = command.ProductExpirationDate,
                    ProductType = command.ProductType,
                    ProductNetPrice = command.ProductNetPrice,
                    ProductWeight = command.ProductWeight,
                    ProductQuantity = command.ProductQuantity,
                };

                return await _productsService.CreateProductAsync(product);
            }
        }
    }
}
