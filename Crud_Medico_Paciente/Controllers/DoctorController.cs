using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Api.Controllers
{
    [Route("api/[controller]/")]
    public class DoctorController : ControllerBase
    {
        private ILogger<DoctorController> _logger;
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService, ILogger<DoctorController> logger)
        {
            _doctorService = doctorService;
            _logger = logger;
        }
        
        [HttpGet()]
        public async Task<IActionResult> GetAllDoctor()
        {
            var doctors = await _doctorService.GetDoctorsVM();
            return Ok(doctors);
        }

        [Route("api/Doctor/CreateDoctor")]
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorVM doctorVM)
        {
            try
            {
                var result = await _doctorService.CretaDoctorAsync(doctorVM);

                if (!result) return BadRequest();

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Houve erro ao tentar cadastrar um novo médico");
                throw;
            }

        }
    }
}
