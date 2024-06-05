using SharedKernel;

namespace TomasosPizzeria.UseCases.User.Login;

public record UserLoginResponse(Response Response, string Token);