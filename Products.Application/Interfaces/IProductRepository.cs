using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Products.Domain.Entities;

namespace Products.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(CancellationToken ct);
        Task<Product?> GetByIdAsync(int id, CancellationToken ct);
        Task AddAsync(Product product, CancellationToken ct);
        Task<bool> UpdateAsync(Product product, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
    }
}
