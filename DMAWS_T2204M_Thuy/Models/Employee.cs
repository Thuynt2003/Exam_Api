namespace DMAWS_T2204M_Thuy.Models
{
    public class Employee
    {
        public int EmployeeId {get;set;}
        public string EmployeeName { get;set;}
        public DateTime EmployeeDOB { get;set;}
        public string EmployeeDepartment { get;set;}
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set;}
    }
}
