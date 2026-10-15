using MediatR;
using Products.Application.Interfaces;

namespace Products.Application.Commands;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository) => _repository = repository;

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken ct)
    {
        return await _repository.DeleteAsync(request.Id, ct);
    }
}
