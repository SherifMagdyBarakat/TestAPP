namespace TestAPP.Models
{
    public interface IEmployeeRepository
    {
      
            Employee GetOneEmployee(int Id);
            IEnumerable<Employee> GetAllEmployees();
            Employee AddEmployee(Employee employee);
            Employee UpdateEmployee(Employee employeeChanges);
            Employee DeleteEmployee(int Id);
        

    }
}
