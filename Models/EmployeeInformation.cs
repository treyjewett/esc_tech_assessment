namespace TreyJewett_TechAssessment.Models
{
    public class EmployeeInformation
    {
        public Employee Employee { get; set; }
        public Dependent Dependent { get; set; }
        public Job Job { get; set; }
        public Department Department { get; set; }
        public Location Location { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }
        //public string DependentFirstName { get; set; }
        //public string DependentLastName { get; set; }
        //public string JobTitle { get; set; }
        //public string SalaryRange { get; set; }
        //public string DepartmentName { get; set; }
        //public string DepartmentLocation { get; set; }
        //public string Country { get; set; }
        //public string Region { get; set; }
    }
}
