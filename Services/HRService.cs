using TreyJewett_TechAssessment.Interfaces;
using TreyJewett_TechAssessment.Models;

namespace TreyJewett_TechAssessment.Services
{
    public class HRService : IHRService
    {
        private readonly HRContext _context;

        public HRService(HRContext context) {
            _context = context;
        }

        public List<EmployeeInformation> GetAllEmployees()
        {
            return (from emp in _context.Employees join
                                dep in _context.Dependents on emp.EmployeeID equals dep.EmployeeID into emp_dep
                                from e in emp_dep.DefaultIfEmpty() join
                                job in _context.Jobs on emp.JobId equals job.JobID join
                                dpt in _context.Departments on emp.DepartmentID equals dpt.DepartmentID join
                                loc in _context.Locations on dpt.LocationID equals loc.LocationID join
                                cty in _context.Countries on loc.CountryID equals cty.CountryID join
                                reg in _context.Regions on cty.RegionID equals reg.RegionID
                                select new EmployeeInformation
                                {
                                    Employee = emp,
                                    Dependent = e,
                                    Job = job,
                                    Department = dpt,
                                    Location = loc,
                                    Country = cty,
                                    Region = reg
                                }).ToList();
        }

        public List<EmployeeInformation> GetFilteredEmployees(EmployeeFilter filters)
        {
            var allEmployees = GetAllEmployees();
            if (filters.EmployeeID != null)
            {
                allEmployees = allEmployees.Where(e => e.Employee.EmployeeID == filters.EmployeeID).ToList();
            }
            if (!string.IsNullOrEmpty(filters.EmployeeFirstname))
            {
                allEmployees = allEmployees.Where(e => e.Employee.FirstName == filters.EmployeeFirstname).ToList();
            }
            if (!string.IsNullOrEmpty(filters.EmployeeLastname))
            {
                allEmployees = allEmployees.Where(e => e.Employee.LastName == filters.EmployeeLastname).ToList();
            }
            if (!string.IsNullOrEmpty(filters.EmployeeEmail))
            {
                allEmployees = allEmployees.Where(e => e.Employee.Email == filters.EmployeeEmail).ToList();
            }
            if (!string.IsNullOrEmpty(filters.EmployeeDepartmentName))
            {
                allEmployees = allEmployees.Where(e => e.Department.DepartmentName == filters.EmployeeDepartmentName).ToList();
            }
            if (!string.IsNullOrEmpty(filters.EmployeeCountryName))
            {
                allEmployees = allEmployees.Where(e => e.Country.CountryName == filters.EmployeeCountryName).ToList();
            }
            if (!string.IsNullOrEmpty(filters.EmployeeRegionName))
            {
                allEmployees = allEmployees.Where(e => e.Region.RegionName == filters.EmployeeRegionName).ToList();
            }
            return allEmployees;
        }
    }
}
