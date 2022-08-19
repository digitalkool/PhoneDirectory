using System.ComponentModel.DataAnnotations;

namespace PhoneDirectory.Models
{
    public enum Title
    {
        VP, Director, AssistDirector, Manager, AssistManager, Supervisor, Employee

    }


    public class Employee
    {
        public int EmployeeID { get; set; }
        public int DepartmentID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        
        [Display(Name ="Department")]
        public Department Department { get; set; }

        [Display(Name ="Title")]
        public Title? Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [Display(Name ="Main")]
        public string Phone1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name ="Mobile")]
        public string Phone2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name ="Extension")]
        public string Ext { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Notes")]
        public string Notes { get; set; }
        
        
    }
}