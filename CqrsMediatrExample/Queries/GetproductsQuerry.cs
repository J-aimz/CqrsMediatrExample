using CqrsMediatrExample.Models;
using MediatR;

namespace CqrsMediatrExample.Queries
{
    public record GetproductsQuerry : IRequest<IEnumerable<Product>>;
    
}
