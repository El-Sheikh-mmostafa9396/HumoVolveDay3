using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace Products.Application.Commands
{
    public record CreateProductCommand(string Name, decimal Price) : IRequest<int>;
}
