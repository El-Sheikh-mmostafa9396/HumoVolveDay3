using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Commands;
using Products.Application.Interfaces;
using Products.Domain.Entities;

namespace Products.Application.Products.Commands;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _repository;
    private readonly ILogger<CreateProductHandler> _logger;

    public CreateProductHandler(
        IProductRepository repository,
        ILogger<CreateProductHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken ct)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price
        };

        await _repository.AddAsync(product, ct);

        _logger.LogInformation(
            "Product created successfully. ProductId: {ProductId}, Name: {ProductName}",
            product.Id, product.Name);

        return product.Id;
    }
}