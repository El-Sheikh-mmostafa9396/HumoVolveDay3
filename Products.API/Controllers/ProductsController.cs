using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.API.Contracts;
using Products.Application.Commands;
using Products.Application.DTOs;
using Products.Application.Products.Queries;

namespace Products.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender) => _sender = sender;

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAll(CancellationToken ct)
        => Ok(await _sender.Send(new GetProductsQuery(), ct));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetById(int id, CancellationToken ct)
    {
        var product = await _sender.Send(new GetProductByIdQuery(id), ct);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateProductRequest request, CancellationToken ct)
    {
        var id = await _sender.Send(new CreateProductCommand(request.Name, request.Price), ct);
        return CreatedAtAction(nameof(GetById), new { id }, new { Id = id });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductRequest request, CancellationToken ct)
    {
        var updated = await _sender.Send(new UpdateProductCommand(id, request.Name, request.Price), ct);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var deleted = await _sender.Send(new DeleteProductCommand(id), ct);
        return deleted ? NoContent() : NotFound();
    }
}