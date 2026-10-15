using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Application.DTOs
{
    public record ProductDto(int Id, string Name, decimal Price);
}
