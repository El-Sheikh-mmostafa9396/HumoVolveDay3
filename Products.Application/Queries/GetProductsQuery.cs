using MediatR;
using Products.Application.DTOs;

namespace Products.Application.Products.Queries;

public record GetProductsQuery() : IRequest<List<ProductDto>>;