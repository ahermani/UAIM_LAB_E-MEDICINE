namespace PatientsDataMicroservice.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ModelClassLibrary;
    using PatientDataMicroservice.DAO;
    using PatientDataMicroservice.DTO;

    [ApiController]
    [Route("patient")]
    public class PatientController : ControllerBase
    {

        private readonly ILogger<PatientController> _logger;
        private readonly IDaoPatientAsync _daoPatientAsync;

        public PatientController(ILogger<PatientController> logger)
        {
            _logger = logger;
            _daoPatientAsync = new DaoPatientXMLAsync();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Patient>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPatients()
        {
            IEnumerable<Patient> ret;
            try
            {
                ret = await _daoPatientAsync.GetAllAsync();
            }
            catch(Exception e)
            {
                return BadRequest("Can't filter the request");
            }

            return Ok(ret);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Patient))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPatientsById(Guid id)
        {
            var ret = await _daoPatientAsync.GetByIdAsync(id);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Patient))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AppendPatient([FromBody] PatientDTO patient)
        {
            Patient ret;
            try
            {
                 ret = await _daoPatientAsync.AppendAsync(patient);

            }
            catch(Exception e)
            {
                return BadRequest("Can't filter the request");
            }
            return Ok(ret);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Patient>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var ret = await _daoPatientAsync.DeleteAsync(id);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Patient))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] PatientDTO patient)
        {
            var ret = await _daoPatientAsync.UpdateAsync(id, patient);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }
    }
}