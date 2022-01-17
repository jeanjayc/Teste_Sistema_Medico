using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Api.Controllers
{
    public class DoctorController : ControllerBase
    {
        private ILogger<DoctorController> _logger;
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService, ILogger<DoctorController> logger)
        {
            _doctorService = doctorService;
            _logger = logger;
        }

        [Route("api/Doctor/GetAllDoctor")]
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
                var DoctorCreated = await _doctorService.CretaDoctorAsync(doctorVM);

                return Ok(DoctorCreated);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Houve erro ao tentar cadastrar um novo médico");
                throw;
            }

        }

        [Route("api/Doctor/UpdateDoctor")]
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(Guid id, [FromBody] DoctorVM doctorVM)
        {
            var doctor = await _doctorService.GetDoctorVMById(id);

            if (doctor == null) return NotFound();

            if (doctor.Id != doctorVM.Id) return BadRequest();

            if(!ModelState.IsValid) return BadRequest();

            var result = await _doctorService.UpdateDoctorAsync(doctorVM);

            return Ok(result);
        }

        [Route("api/Doctor/RemoveDoctor")]
        [HttpDelete]
        public async Task<IActionResult> RemoveDoctor(Guid id)
        {
            var doctor = await _doctorService.GetDoctorVMById(id);

            if (doctor == null) return NotFound();

            if (id != doctor.Id) return BadRequest();

            await _doctorService.RemoveDoctorAsync(doctor);

            return Ok(doctor);
        }

    }
}
