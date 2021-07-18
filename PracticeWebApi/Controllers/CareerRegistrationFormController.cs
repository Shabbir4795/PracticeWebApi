using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticeWebApi.Model;
using PracticeWebApi.Services;

namespace PracticeWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CareerRegistrationFormController : ControllerBase
    {
        private readonly ILogger<CareerRegistrationFormController> _logger;

        private CareerRegistrationService _careerService;

        public CareerRegistrationFormController(ILogger<CareerRegistrationFormController> logger, CareerRegistrationService careerService)
        {
            _logger = logger;
            _careerService = careerService;
        }
        [HttpGet]
        public List<CareerRegistration> GetCandidateDetails()
        {
            List<CareerRegistration> ListOfCandidates = new List<CareerRegistration>();
            ListOfCandidates = _careerService.GetCandidateDetails();
            return ListOfCandidates;
        }

        [HttpDelete("{Id:int}")]
        [Route("DeleteCandidate/{Id}")]
        public string DeleteCandidateRecord(int Id)
        {
            //int Id1 = 2;
            string RecordDeleted;
            RecordDeleted = _careerService.DeleteSingleRec(Id);
            return RecordDeleted;
        }

        [HttpDelete("{Id:int}")]
        [Route("UpdateRecord/{Id}")]
        public string UpdateCandidateRecord(int Id)
        {
            //int Id1 = 2;
            string RecordUpdated;
            RecordUpdated = _careerService.UpdateCandidateRecord(Id);
            return RecordUpdated;
        }

        [HttpGet]
        [Route("AddCandidate")]
        public string AddCandidateRecord()
        {
            string RecordAdded;
            RecordAdded = _careerService.AddCandidate();
            return RecordAdded;
        }
    }
}
