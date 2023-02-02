using CQRS_Inventary.Models;
using CQRS_Inventary.Services;
using MediatR;

namespace CQRS_Inventary.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime ProductExpirationDate { get; set; }
        public string ProductType { get; set; }
        public double ProductNetPrice { get; set; }
        public double ProductWeight { get; set; }
        public byte ProductQuantity { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IProductsService _productsService;
            public UpdateProductCommandHandler(IProductsService productsService)
            {
                _productsService = productsService;
            }

            public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellation)
            {
                var product = await _productsService.GetProductByIdAsync(command.Id);
                if(product == null)
                {
                    return default;
                }

                product.ProductName = command.ProductName;
                product.ProductExpirationDate = command.ProductExpirationDate;
                product.ProductType = command.ProductType;
                product.ProductNetPrice = command.ProductNetPrice;
                product.ProductWeight = command.ProductWeight;
                product.ProductQuantity = command.ProductQuantity;
                

                return await _productsService.UpdateProductAsync(product);
            }
        }
    }
}
