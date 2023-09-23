using CqrsMediatrExample.Command;
using CqrsMediatrExample.Handlers;
using CqrsMediatrExample.Models;
using CqrsMediatrExample.Notifications;
using CqrsMediatrExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetproductsQuerry());

            return Ok(products);
        }

        [HttpGet("GetProductById/{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = _mediator.Send(new GetProductByIdQuery(id));
            return Ok(result);  
        }

        //[HttpPost]
        //public async Task<IActionResult> AddProduct([FromBody]Product product)
        //{
        //    await _mediator.Send(new AddProductCommand(product));
        //    return StatusCode(201);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateProductWithNotification([FromBody]Product product)
        {
            var productToReturn = await _mediator.Send(new AddProductCommand(product));

            await _mediator.Publish(new ProductAddedNotification(productToReturn));
            
            return CreatedAtRoute("GetProductById", new {id = productToReturn.Id }, productToReturn);
        }


        


    }
}
