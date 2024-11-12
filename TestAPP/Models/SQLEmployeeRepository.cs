using System;

namespace TestAPP.Models
{
    public class SQLEmployeeRepository:IEmployeeRepository
    {

        private readonly AppDBContext context;

        public SQLEmployeeRepository(AppDBContext _context)
        {
            this.context = _context;
        }

        public Employee AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;
        }

        public Employee GetOneEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }
        public Employee UpdateEmployee(Employee employeeChanges)
        {
            Employee employee = context.Employees.Find(employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
                employee.photo = employeeChanges.photo;
            }

            context.SaveChanges();
            return employeeChanges;
        }


    }
}
