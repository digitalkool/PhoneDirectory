using System.ComponentModel.DataAnnotations;

namespace PhoneDirectory.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        
        [Display(Name ="Department")]
        public string DepartmentName { get; set; }

        //public ICollection<Employee> Employees { get; set; }
    }
}
