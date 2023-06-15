using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
    {
        // Check if the user already exists
        var userExists = await _authService.UserExists(userRegisterDto.Email);
        if (userExists)
        {
            return BadRequest("Email is already in use");
        }

        // Create the new user
        var user = await _authService.Register(userRegisterDto.Email, userRegisterDto.Password);

        if (user == null)
        {
            return BadRequest("Registration failed");
        }

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        var token = await _authService.Login(userLoginDto.Email, userLoginDto.Password);

        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized("Invalid email or password");
        }

        return Ok(new { Token = token });
    }
}
