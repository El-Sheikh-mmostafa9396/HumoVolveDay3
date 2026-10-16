using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.DTOs;
using Products.Application.Interfaces;

namespace Products.Application.Products.Queries;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _repository;
    private readonly ILogger<GetProductByIdHandler> _logger;

    public GetProductByIdHandler(
        IProductRepository repository,
        ILogger<GetProductByIdHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken ct)
    {
        var p = await _repository.GetByIdAsync(request.Id, ct);

        if (p is null)
        {
            _logger.LogWarning("Product with Id {ProductId} was not found", request.Id);
            return null;
        }

        return new ProductDto(p.Id, p.Name, p.Price);
    }
}