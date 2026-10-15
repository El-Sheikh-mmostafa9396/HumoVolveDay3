using MediatR;
using Products.Application.Interfaces;
using Products.Domain.Entities;

namespace Products.Application.Commands;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository) => _repository = repository;

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken ct)
    {
        var product = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Price = request.Price
        };

        return await _repository.UpdateAsync(product, ct);
    }
}
