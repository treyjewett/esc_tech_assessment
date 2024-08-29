using Microsoft.AspNetCore.Mvc;
using TreyJewett_TechAssessment.Interfaces;
using TreyJewett_TechAssessment.Models;
using TreyJewett_TechAssessment.Services;

namespace TreyJewett_TechAssessment.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HRController : ControllerBase
    {
        private readonly ILogger<HRController> _logger;
        private readonly IHRService _hrService;

        public HRController(ILogger<HRController> logger, IHRService hrService)
        {
            _logger = logger;
            _hrService = hrService;
        }

        [HttpGet(Name = "GetAllEmployees")]
        public List<EmployeeInformation> GetEmployees()
        {
            return _hrService.GetAllEmployees();
        }

        [HttpGet(Name = "GetFilteredEmployess")]
        public List<EmployeeInformation> GetFilteredEmployees([FromQuery] EmployeeFilter filters)
        {
            return _hrService.GetFilteredEmployees(filters);
        }
    }
}
