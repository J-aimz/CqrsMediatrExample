using CqrsMediatrExample.DataStore;
using CqrsMediatrExample.Models;
using CqrsMediatrExample.Queries;
using MediatR;

namespace CqrsMediatrExample.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetproductsQuerry, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetProductsHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<IEnumerable<Product>> Handle(GetproductsQuerry request, CancellationToken cancellationToken) => await _fakeDataStore.GetAllProducts();
    }
}
