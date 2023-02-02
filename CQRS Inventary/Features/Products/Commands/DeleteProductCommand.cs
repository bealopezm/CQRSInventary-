using CQRS_Inventary.Features.Products.Query;
using CQRS_Inventary.Models;
using CQRS_Inventary.Services;
using MediatR;

namespace CQRS_Inventary.Features.Products.Commands
{
    public class DeleteProductCommand: IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
        {
            private readonly IProductsService _productsService;
            public DeleteProductCommandHandler(IProductsService productsService)
            {
                _productsService = productsService;
            }

            public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellation)
            {
                var product =  await _productsService.GetProductByIdAsync(command.Id);

                if (product == null)
                {
                    return default;
                }

                return await _productsService.DeleteProductAsync(command.Id);
            }
        }
    }
}
