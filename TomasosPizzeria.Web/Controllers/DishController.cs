using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TomasosPizzeria.UseCases.Dish.Create;
using TomasosPizzeria.UseCases.Dish.GetAll;
using TomasosPizzeria.UseCases.Dish.Update;
using TomasosPizzeria.UseCases.Interfaces;

namespace TomasosPizzeria.Web.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class DishController(IErrorHandler errorHandler, ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddDish([FromBody] CreateDishCommand command)
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

        [HttpPut]
        public async Task<IActionResult> UpdateDish([FromBody] UpdateDishCommand command)
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
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllDishes()
        {
            try
            {
                return Ok(await sender.Send(new GetAllDishesQuery()));
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
    }
}
