using MediatR;
using Products.Application.DTOs;

namespace Products.Application.Products.Queries;

public record GetProductByIdQuery(int Id) : IRequest<ProductDto?>;