using Crud_Medico_Paciente.Application.Utils;
using Crud_Medico_Paciente.Application.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Api.Controllers
{
    [Route("api/")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _sinInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly NotificationContext _notificationContext;
        public AuthController(SignInManager<IdentityUser> sinInManager,
                              UserManager<IdentityUser> userManager,
                              NotificationContext notificationContext)
        {
            _userManager = userManager;
            _sinInManager = sinInManager;
            _notificationContext = notificationContext;
        }

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Registrar(RegisterUserViewModel registerUserVM)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUserVM.Email,
                Email = registerUserVM.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUserVM.Password);

            if (result.Succeeded)
            {
                await _sinInManager.SignInAsync(user, isPersistent: false);
                return Ok(result);
            }
            foreach(var error in result.Errors)
            {
                _notificationContext.AddNotification("RegisterUser", error.Description);
            }


            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserVM loginUser)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _sinInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (!result.Succeeded)
            {
                _notificationContext.AddNotification("Login", "Usuário ou senha incorretos");
                return BadRequest();
            }
            if (result.IsLockedOut)
            {
                _notificationContext.AddNotification("Login", "Usuário bloqueado por mais de 5 tentativas de login inválidas");
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
