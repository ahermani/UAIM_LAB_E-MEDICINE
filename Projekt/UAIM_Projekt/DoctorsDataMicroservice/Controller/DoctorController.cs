namespace DoctorsDataMicroservice.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ModelClassLibrary;
    using DAO;
    using DoctorsDataMicroservice.DTO;
    using Microsoft.AspNetCore.Http;
    using System.Linq;

    [ApiController]
    [Route("doctors")]
    public class DoctorController : ControllerBase
    {

        private readonly ILogger<DoctorController> _logger;
        private readonly IDaoDoctorAsync _daoDoctorAsync;

        public DoctorController(ILogger<DoctorController> logger)
        {
            _logger = logger;
            _daoDoctorAsync = new DaoDoctorXMLAsync();
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Doctor))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult> GetAllDoctors()
        {
            try
            {

                return Ok(await _daoDoctorAsync.GetAllAsync());
            }
            catch
            {
                return BadRequest("Error fetching doctors");
            }

        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Doctor))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctorsById(Guid id)
        {
            var doctor = await _daoDoctorAsync.GetByIdAsync(id);
            if (doctor == default(Doctor) || doctor == null) return NotFound("No such ID");
            return Ok(doctor ?? new object());
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Doctor))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("specialization_id={id}")]
        public async Task<ActionResult<Doctor>> GetDoctorsBySpecialization(int id)
        {
            var doctor = (await _daoDoctorAsync.GetAllBySpecialization(id)).ToList();
            if (doctor.Count == 0)
            {
                return NotFound("No such specialization or no doctors");
            }
            else
            {
                Console.WriteLine(doctor.ToString());
                return Ok(doctor ?? new object());
            }


        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Doctor))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Doctor))]
        [HttpPost]
        public async Task<ActionResult<Doctor>> AppendDoctor([FromBody] DoctorDTO doctor)
        {
            try
            {
                if (doctor == null)
                {
                    return (BadRequest("Invalid Data"));
                }
                var ret = await _daoDoctorAsync.AppendAsync(doctor);
                return Ok(ret);
            }
            catch (Exception e) {
                return (BadRequest("Invalid Data"));
            }


        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Doctor))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Doctor))]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(Guid id)
        {
            try
            {

                var ret = await _daoDoctorAsync.DeleteAsync(id);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return (BadRequest("Invalid Data"));
            }

        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Doctor))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Doctor))]
        [HttpPut("{id}")]
        public async Task<ActionResult<Doctor>> UpdateDoctor(Guid id, [FromBody] DoctorDTO doctor)
        {
                try
                {

                    var ret = await _daoDoctorAsync.UpdateAsync(id, doctor);
                    return Ok(ret);
                }
                catch (Exception e)
                {
                    return (BadRequest("Invalid Data"));
                }
        }

    }
}