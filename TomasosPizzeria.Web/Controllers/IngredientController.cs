using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TomasosPizzeria.UseCases.Ingredient.Create;
using TomasosPizzeria.UseCases.Ingredient.GetAll;
using TomasosPizzeria.UseCases.Ingredient.Remove;
using TomasosPizzeria.UseCases.Interfaces;

namespace TomasosPizzeria.Web.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class IngredientController(IErrorHandler errorHandler, ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddIngredient([FromBody]  CreateIngredientCommand command)
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
        
        [HttpDelete]
        public async Task<IActionResult> RemoveIngredient([FromBody]  RemoveIngredientCommand command)
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
        public async Task<IActionResult> GetAllIngredients()
        {
            try
            {
                return Ok(await sender.Send(new GetAllIngredientsQuery()));
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
    }
}
