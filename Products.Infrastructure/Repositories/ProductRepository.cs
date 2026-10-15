using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;
using Products.Domain.Entities;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context) => _context = context;

    public Task<List<Product>> GetAllAsync(CancellationToken ct) =>
        _context.Products.AsNoTracking().ToListAsync(ct);

    public Task<Product?> GetByIdAsync(int id, CancellationToken ct) =>
        _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);

    public async Task AddAsync(Product product, CancellationToken ct)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<bool> UpdateAsync(Product product, CancellationToken ct)
    {
        var exists = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id, ct);
        if (exists is null)
            return false;

        exists.Name = product.Name;
        exists.Price = product.Price;

        await _context.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, ct);
        if (product is null)
            return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}