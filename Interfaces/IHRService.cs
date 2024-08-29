using TreyJewett_TechAssessment.Models;

namespace TreyJewett_TechAssessment.Interfaces
{
    public interface IHRService
    {
        List<EmployeeInformation> GetAllEmployees();
        List<EmployeeInformation> GetFilteredEmployees(EmployeeFilter filters);
    }
}
