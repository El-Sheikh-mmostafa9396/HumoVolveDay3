
using MediatR;
using Products.Application.Interfaces;
using Products.Domain.Entities;

namespace Products.Application.Commands;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
        => _repository = repository;

    public async Task<int> Handle(CreateProductCommand request, CancellationToken ct)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price
        };

        await _repository.AddAsync(product, ct);
        return product.Id;
    }
}