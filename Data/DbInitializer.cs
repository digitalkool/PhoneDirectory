using PhoneDirectory.Models;

namespace PhoneDirectory.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DirectoryContext context)
        {
            // Look for any students.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
                new Employee{FirstName="Carson",LastName="Alexander",Email = "calexander@oganization.com",Phone1 = "999-999-9999",Phone2 = "888-888-8888",Ext = "1001",Notes =""},
                new Employee{FirstName="Meredith",LastName="Alonso",Email = "ameredith@oganization.com",Phone1 = "999-999-9991",Phone2 = "888-888-8881",Ext = "1002",Notes =""},
                new Employee{FirstName="Arturo",LastName="Anand",Email = "aanand@oganization.com",Phone1 = "999-999-9993",Phone2 = "888-888-8883",Ext = "1003",Notes =""},
                new Employee{FirstName="Gytis",LastName="Barzdukas",Email = "gbarzdukas@oganization.com",Phone1 = "999-999-9994",Phone2 = "888-888-8884",Ext = "1004",Notes =""},
                new Employee{FirstName="Yan",LastName="Li",Email = "yli@oganization.com",Phone1 = "999-999-9995",Phone2 = "888-888-8885",Ext = "1005",Notes =""},
                new Employee{FirstName="Peggy",LastName="Justice",Email = "pjustice@oganization.com",Phone1 = "999-999-9996",Phone2 = "888-888-8886",Ext = "1006",Notes =""},
                new Employee{FirstName="Laura",LastName="Norman",Email = "lnorman@oganization.com",Phone1 = "999-999-9997",Phone2 = "888-888-8887",Ext = "1007",Notes =""},
                new Employee{FirstName="Nino",LastName="Olivetto",Email = "nolivetto@oganization.com",Phone1 = "999-999-9998",Phone2 = "888-888-8889",Ext = "1008",Notes =""}
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();

            if (context.Departments.Any())
            {
                return;   // DB has been seeded
            }

            var departments = new Department[]
            {
                new Department{DepartmentName = "Administration"},
                new Department{DepartmentName = "Accounting"},
                new Department{DepartmentName = "Purchasing"},
                new Department{DepartmentName = "Marketing"},
                new Department{DepartmentName = "Operations"},
                new Department{DepartmentName = "Information Technology"},
                new Department{DepartmentName = "Communications"}
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();

        }
    }
}