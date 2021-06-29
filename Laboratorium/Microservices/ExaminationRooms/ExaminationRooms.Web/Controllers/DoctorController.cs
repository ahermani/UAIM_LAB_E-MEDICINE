namespace ExaminationRooms.Web.Controllers
{
    using ExaminationRooms.Web.Application.Commands;
    using ExaminationRooms.Web.Application.Dtos;
    using ExaminationRooms.Web.Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> logger;
        private readonly IDoctorQueriesHandler doctorQueriesHandler;
        private readonly ICommandHandler<AddDoctorCommand> addDoctorCommandHandler;

        public DoctorController(ILogger<DoctorController> logger, IDoctorQueriesHandler doctorQueriesHandler, ICommandHandler<AddDoctorCommand> addDoctorCommandHandler)
        {
            this.logger = logger;
            this.doctorQueriesHandler = doctorQueriesHandler;
            this.addDoctorCommandHandler = addDoctorCommandHandler;
        }

        [HttpGet("doctors")]
        public IEnumerable<DoctorDto> GetAll()
        {
            return doctorQueriesHandler.GetAll();
        }

        [HttpGet("doctor")]
        public IEnumerable<DoctorDto> GetBySpecialityNumber([FromQuery] int specialityNumber)
        {
            return doctorQueriesHandler.GetBySpecialityNumber(specialityNumber);
        }

        [HttpPost("doctor")]
        public void AddDoctor([FromBody] AddDoctorCommand doctorCommand)
        {
            addDoctorCommandHandler.Handle(doctorCommand);
        }
    }
}
