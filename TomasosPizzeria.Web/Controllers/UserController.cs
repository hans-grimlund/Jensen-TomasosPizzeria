using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TomasosPizzeria.UseCases.Interfaces;
using TomasosPizzeria.UseCases.User.ChangeRole;
using TomasosPizzeria.UseCases.User.Create;
using TomasosPizzeria.UseCases.User.GetAll;
using TomasosPizzeria.UseCases.User.GetProfile;
using TomasosPizzeria.UseCases.User.Login;
using TomasosPizzeria.UseCases.User.Update;

namespace TomasosPizzeria.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IErrorHandler errorHandler, ISender sender) : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddUser([FromBody] CreateUserCommand command)
        {
            try
            {
                var result = await sender.Send(command);
                if (result == string.Empty)
                    return Ok();

                return BadRequest(result);
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginQuery query)
        {
            try
            {
                var result = await sender.Send(query);
                return result.Response switch
                {
                    SharedKernel.Response.None => Problem(),
                    SharedKernel.Response.Ok => Ok(result.Token),
                    SharedKernel.Response.NotFound => NotFound(),
                    SharedKernel.Response.Unauthorized => Unauthorized(),
                    SharedKernel.Response.Error => Problem(),
                    _ => throw new Exception("Failed to create user")
                };
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
        
        [HttpPut("updatebyid")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserByIdCommand byIdCommand)
        {
            try
            {
                var result = await sender.Send(byIdCommand);
                return result switch
                {
                    SharedKernel.Response.None => Problem(),
                    SharedKernel.Response.Ok => Ok(),
                    SharedKernel.Response.NotFound => NotFound(),
                    SharedKernel.Response.Unauthorized => Unauthorized(),
                    SharedKernel.Response.Error => Problem(),
                    _ => throw new Exception("Failed to update user")
                };
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateUserById([FromQuery] string username, string email, string phone)
        {
            try
            {
                var result = await sender.Send(new UpdateUserCommand(User, username, email, phone));
                return result switch
                {
                    SharedKernel.Response.None => Problem(),
                    SharedKernel.Response.Ok => Ok(),
                    SharedKernel.Response.NotFound => NotFound(),
                    SharedKernel.Response.Unauthorized => Unauthorized(),
                    SharedKernel.Response.Error => Problem(),
                    _ => throw new Exception("Failed to update user")
                };
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMyProfile()
        {
            try
            {
                return Ok(await sender.Send(new GetUserProfileQuery(User)));
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
        
        [HttpGet("getall")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await sender.Send(new GetAllUsersQuery()));
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
        
        [HttpPatch("role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole([FromBody]  ChangeUserRoleCommand command)
        {
            try
            {
                var result = await sender.Send(command);
                return result switch
                {
                    SharedKernel.Response.None => Problem(),
                    SharedKernel.Response.Ok => Ok(),
                    SharedKernel.Response.NotFound => NotFound(),
                    SharedKernel.Response.Unauthorized => Unauthorized(),
                    SharedKernel.Response.Error => Problem(),
                    _ => throw new Exception("Failed to change role")
                };
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
        
        [HttpGet("testlogging")]
        [AllowAnonymous]
        public IActionResult TestLogging()
        {
            try
            {
                throw new Exception("This is an exception");
            }
            catch (Exception e)
            {
                errorHandler.LogError(e);
                return Problem();
            }
        }
    }
}
