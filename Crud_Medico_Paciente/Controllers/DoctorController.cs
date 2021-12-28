using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Api.Controllers
{
    public class DoctorController : ControllerBase
    {
        public async Task<IActionResult> GetAllDoctor()
        {
            return Ok();
        }
    }
}
