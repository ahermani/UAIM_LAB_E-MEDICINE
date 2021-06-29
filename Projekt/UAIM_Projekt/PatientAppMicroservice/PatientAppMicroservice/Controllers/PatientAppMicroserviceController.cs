namespace PatientAppMicroservice.Controllers
{
    using PatientAppMicroservice.Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using PatientAppMicroservice.Dtos;
    using Microsoft.AspNetCore.Http;
    using ModelClassLibrary;

    [ApiController]
    public class PatientAppMicroserviceController : ControllerBase
    {
        private readonly ILogger<PatientAppMicroserviceController> logger;
        private readonly IPatientAppMicroserviceHandler patientAppMicroserviceHandler;

        public PatientAppMicroserviceController(ILogger<PatientAppMicroserviceController> logger, IPatientAppMicroserviceHandler examinationRoomsSelectorHandler)
        {
            this.logger = logger;
            this.patientAppMicroserviceHandler = examinationRoomsSelectorHandler;
        }

        [HttpGet("doctors")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Doctor>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllDoctors()
        {
            IEnumerable<Doctor> ret;
            try
            {
                ret = await patientAppMicroserviceHandler.GetAllDoctors();
            }
            catch (Exception e)
            {
                return BadRequest("Can't filter the request");
            }

            return Ok(ret);
        }

        [HttpGet("doctors/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Doctor))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDoctorsById(Guid id)
        {
            var ret = await patientAppMicroserviceHandler.GetDoctorById(id);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }

        [HttpGet("doctors/{id}/appointments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Appointment>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDoctorsAppointmentsInFrame( Guid id, [FromQuery] DateTime from, DateTime to)
        {
            var ret = await patientAppMicroserviceHandler.GetDoctorsAppointmentsInFrame(id, from, to);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }

        [HttpGet("patients/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Patient))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var ret = await patientAppMicroserviceHandler.GetPatientById(id);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }

        [HttpGet("appointments/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Appointment))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            var ret = await patientAppMicroserviceHandler.GetAppointmentById(id);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }

        [HttpPut("patients/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Patient))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] PatientDto patient)
        {
            var ret = await patientAppMicroserviceHandler.UpdatePatient(id, patient);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }

        [HttpGet("patients/{id}/appointments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Appointment>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPatientAppointmentsInFrame(Guid id, [FromQuery] DateTime from , DateTime to)
        {

            var ret = await patientAppMicroserviceHandler.GetPatientAppointmentsInFrame(id,from , to);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }

        [HttpPut("appointments/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Appointment))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] AppointmentDto appointment)
        {
            var ret = await patientAppMicroserviceHandler.UpdateAppointment(id, appointment);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }

        [HttpPost("appointments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Appointment))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAppointment([FromBody] AppointmentDto appointment)
        {
            Appointment ret;
            try
            {
                ret = await patientAppMicroserviceHandler.PostAppointment(appointment);

            }
            catch (Exception e)
            {
                return BadRequest("Can't filter the request");
            }
            return Ok(ret);
        }

        [HttpGet("treatments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TreatmentDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllTreatments()
        {
            IEnumerable<TreatmentDto> ret;
            try
            {
                ret = await patientAppMicroserviceHandler.GetAllTreatments();
            }
            catch (Exception e)
            {
                return BadRequest("Can't filter the request");
            }

            return Ok(ret);
        }

        [HttpGet("treatments/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TreatmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTreatmentById (Guid id)
        {
            var ret = await patientAppMicroserviceHandler.GetTreatmentById(id);
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
