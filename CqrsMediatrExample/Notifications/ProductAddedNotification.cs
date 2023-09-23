using CqrsMediatrExample.DataStore;
using CqrsMediatrExample.Models;
using MediatR;

namespace CqrsMediatrExample.Notifications
{
    public class ProductAddedNotification : INotification
    {
        public Product Product { get; }

        public ProductAddedNotification(Product product) => Product = product;

    }

}
