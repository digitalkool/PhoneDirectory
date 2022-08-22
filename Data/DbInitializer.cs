using PhoneDirectory.Models;

namespace PhoneDirectory.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DirectoryContext context)
        {
            // Look for any departments
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

            // Look for any students.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
                // Administration
                new Employee{DepartmentID = 1,FirstName="Carson",LastName="Alexander",Title=Title.AssistDirector,Email = "calexander@oganization.com",Phone1 = "999-999-9999",Ext = "1001",Phone2 = "888-888-8888", Notes =""},
                new Employee{DepartmentID = 1,FirstName="Meredith",LastName="Alonso",Title=Title.AssistManager,Email = "ameredith@oganization.com",Phone1 = "999-999-9991",Ext = "1002", Phone2 = "888-888-8881",Notes =""},
                new Employee{DepartmentID = 1,FirstName="Arturo",LastName="Anand",Title=Title.Supervisor,Email = "aanand@oganization.com",Phone1 = "999-999-9993",Ext = "1003",Phone2 = "888-888-8883",Notes =""},
                new Employee{DepartmentID = 1,FirstName="Gytis",LastName="Barzdukas",Title=Title.Manager,Email = "gbarzdukas@oganization.com",Phone1 = "999-999-9994",Ext = "1004",Phone2 = "888-888-8884",Notes =""},
                new Employee{DepartmentID = 1,FirstName="Yan",LastName="Li",Title=Title.VP,Email = "yli@oganization.com",Phone1 = "999-999-9995",Ext = "1005",Phone2 = "888-888-8885",Notes =""},
                new Employee{DepartmentID = 1,FirstName="Peggy",LastName="Justice",Title=Title.Employee,Email = "pjustice@oganization.com",Phone1 = "999-999-9996",Ext = "1006",Phone2 = "888-888-8886",Notes =""},
                new Employee{DepartmentID = 1,FirstName="Laura",LastName="Norman",Title=Title.Employee,Email = "lnorman@oganization.com",Phone1 = "999-999-9997",Ext = "1007",Phone2 = "888-888-8887",Notes =""},
                new Employee{DepartmentID = 1,FirstName="Nino",LastName="Olivetto",Title=Title.Employee,Email = "nolivetto@oganization.com",Phone1 = "999-999-9998",Ext = "1008",Phone2 = "888-888-8889",Notes =""},
                // Accounting
                new Employee{DepartmentID = 2,FirstName="Efrain",LastName="Cruz",Title=Title.AssistDirector,Email = "calexander@oganization.com",Phone1 = "999-999-9999",Ext = "1001",Phone2 = "888-888-8888", Notes =""},
                new Employee{DepartmentID = 2,FirstName="Tony",LastName="Cruz",Title=Title.AssistManager,Email = "ameredith@oganization.com",Phone1 = "999-999-9991",Ext = "1002", Phone2 = "888-888-8881",Notes =""},
                new Employee{DepartmentID = 2,FirstName="Dezi",LastName="Arnez",Title=Title.Supervisor,Email = "aanand@oganization.com",Phone1 = "999-999-9993",Ext = "1003",Phone2 = "888-888-8883",Notes =""},
                new Employee{DepartmentID = 2,FirstName="Mickey",LastName="Mouse",Title=Title.Manager,Email = "gbarzdukas@oganization.com",Phone1 = "999-999-9994",Ext = "1004",Phone2 = "888-888-8884",Notes =""},
                new Employee{DepartmentID = 2,FirstName="James",LastName="Kirk",Title=Title.VP,Email = "yli@oganization.com",Phone1 = "999-999-9995",Ext = "1005",Phone2 = "888-888-8885",Notes =""},
                new Employee{DepartmentID = 2,FirstName="Romeo",LastName="Salas",Title=Title.Employee,Email = "pjustice@oganization.com",Phone1 = "999-999-9996",Ext = "1006",Phone2 = "888-888-8886",Notes =""},
                new Employee{DepartmentID = 2,FirstName="Sophia",LastName="Tianio",Title=Title.Employee,Email = "lnorman@oganization.com",Phone1 = "999-999-9997",Ext = "1007",Phone2 = "888-888-8887",Notes =""},
                new Employee{DepartmentID = 2,FirstName="Nino",LastName="Rodrigues",Title=Title.Employee,Email = "nolivetto@oganization.com",Phone1 = "999-999-9998",Ext = "1008",Phone2 = "888-888-8889",Notes =""},
                // IT
                new Employee{DepartmentID = 6,FirstName="Ruben",LastName="Ordonez",Title=Title.VP,Email = "ruben@ordonez.us",Phone1 = "626-488-7029",Ext = "",Phone2 = "626-488-7029",Notes ="Ruben Ordonez is an IT kung fu god!"}

            };

            context.Employees.AddRange(employees);
            context.SaveChanges();


        }
    }
}