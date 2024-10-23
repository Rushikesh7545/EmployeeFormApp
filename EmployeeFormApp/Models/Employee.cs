using System.ComponentModel.DataAnnotations;

namespace EmployeeFormApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; } 
        public string Department { get; set; }
        public string Designation { get; set; }
        public double BasicSalary { get; set; }
    }
}
