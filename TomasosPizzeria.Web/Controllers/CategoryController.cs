using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TomasosPizzeria.UseCases.Category.Create;
using TomasosPizzeria.UseCases.Category.GetAll;
using TomasosPizzeria.UseCases.Category.Remove;
using TomasosPizzeria.UseCases.Interfaces;

namespace TomasosPizzeria.Web.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class CategoryController(ISender sender, IErrorHandler errorHandler) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryCommand command)
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
        public async Task<IActionResult> RemoveCategory([FromBody]  RemoveCategoryCommand command)
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
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                return Ok(await sender.Send(new GetAllCategoriesQuery()));
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
    }
}
