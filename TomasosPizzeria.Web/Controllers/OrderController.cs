using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TomasosPizzeria.UseCases.Interfaces;
using TomasosPizzeria.UseCases.Order.ChangeStatus;
using TomasosPizzeria.UseCases.Order.Create;
using TomasosPizzeria.UseCases.Order.GetAll;
using TomasosPizzeria.UseCases.Order.GetFromUser;
using TomasosPizzeria.UseCases.Order.Remove;

namespace TomasosPizzeria.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(IErrorHandler errorHandler, ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] IEnumerable<int> dishes)
        {
            try
            {
                var status = await sender.Send(new CreateOrderCommand(User, dishes));
                return status switch
                {
                    SharedKernel.Response.None => Problem(),
                    SharedKernel.Response.Ok => Ok(),
                    SharedKernel.Response.NotFound => NotFound(),
                    SharedKernel.Response.Error => Problem(),
                    _ => throw new Exception("Failed to add order")
                };
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete]    
        public async Task<IActionResult> RemoveOrder([FromBody] RemoveOrderCommand command)
        {
            try
            {
                var status = await sender.Send(command);
                return status switch
                {
                    SharedKernel.Response.Ok => Ok(),
                    SharedKernel.Response.NotFound => NotFound(),
                    _ => throw new Exception("Failed to add order")
                };
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> GetMyOrders()
        {
            try
            {
                return Ok(await sender.Send(new GetOrdersFromUserQuery(User)));
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
        
        [HttpGet("getall")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                return Ok(await sender.Send(new GetAllOrdersQuery()));
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeOrderStatusCommand command)
        {
            try
            {
                await sender.Send(command);
                return Ok();
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
    }
}
