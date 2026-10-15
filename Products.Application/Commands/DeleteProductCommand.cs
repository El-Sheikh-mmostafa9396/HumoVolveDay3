using MediatR;

namespace Products.Application.Commands;

public record DeleteProductCommand(int Id) : IRequest<bool>;
