using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployee : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployee()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){ Department=Dept.Admin, Email="Mary@gmail.com", Id=1, Name="Mary" },
                new Employee(){  Department=Dept.IT, Email="John@gmail.com",Id=2, Name="John"}

            };
        }

        public Employee Add(Employee employe)
        {
           int Id= _employeeList.Max(x => x.Id) + 1;
            employe.Id = Id;
           _employeeList.Add(employe);
            return employe;
        }

        public List<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
           return _employeeList.FirstOrDefault(x => x.Id == Id);
        }
    }
}
