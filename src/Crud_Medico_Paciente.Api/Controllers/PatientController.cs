using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Api.Controllers
{
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientService patientService, ILogger<PatientController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        [Route("api/Patients/CreatePatient")]
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientInputModel patientVM)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var result = await _patientService.CretaPatientAsync(patientVM);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
