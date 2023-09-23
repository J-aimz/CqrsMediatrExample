using CqrsMediatrExample.Models;
using MediatR;

namespace CqrsMediatrExample.Command
{
    public class AddProductCommand : IRequest<Product>
    {
        public Product Product { get; }
        public AddProductCommand(Product product) => Product = product;
    }

}
