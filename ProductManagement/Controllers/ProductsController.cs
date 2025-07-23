using Application.Products.Commands;
using Application.Products.Commands.CreateProduct;
using Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetAllProductsQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) =>
            Ok(await _mediator.Send(new GetProductByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPut("{id}")]
        public async Task Update(Guid id, UpdateProductCommand command)
        {
            if (id != command.Id)
                throw new ArgumentException("URL ID does not match payload ID.");
            await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }
    }
}
