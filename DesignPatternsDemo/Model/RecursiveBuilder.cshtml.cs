using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DesignPatternsDemo.Model
{
    public class RecursiveBuilderModel : PageModel
    {
        public abstract class EmployeeBuilder
        {
            protected Employee emp = new Employee();

            public Employee Build()
            {
                return emp;
            }
        }

        public class EmployeeInfoBuilder<SELF> : EmployeeBuilder where SELF : EmployeeInfoBuilder<SELF>
        {
            public SELF Called(string name)
            {
                emp.Name = name;
                return (SELF)this;
            }
        }

        public class EmployeeJobBuilder<SELF> : EmployeeInfoBuilder<EmployeeJobBuilder<SELF>> where SELF : EmployeeJobBuilder<SELF>
        {
            public SELF WorksAsA(string position)
            {
                emp.Position = position;
                return (SELF)this;
            }
        }
        public class EmployeeBirthDateBuilder<SELF> : EmployeeJobBuilder<EmployeeBirthDateBuilder<SELF>> where SELF : EmployeeBirthDateBuilder<SELF>
        {
            public SELF Born(DateTime dateOfBirth)
            {
                emp.DateOfBirth = dateOfBirth;
                return (SELF)this;
            }
        }


        public class Employee
        {
            public string Name;
            public string Position;
            public DateTime DateOfBirth;

            public class Builder : EmployeeBirthDateBuilder<Builder>
            {
                internal Builder() { }
            }

            public static Builder New => new Builder();

            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
            }
        }

    }
}
