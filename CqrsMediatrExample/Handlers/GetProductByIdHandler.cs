using CqrsMediatrExample.DataStore;
using CqrsMediatrExample.Models;
using CqrsMediatrExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CqrsMediatrExample.Handlers
{
    public class GetProductByIdHandler: IRequestHandler<GetProductByIdQuery, Product>
    {
        //props
        private readonly FakeDataStore _fakeDataStore;

        //ctor
        public GetProductByIdHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        //methods
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken token)
        {
            var result = await _fakeDataStore.GetProductById(request.id);
            return result;
        }



    }
}
