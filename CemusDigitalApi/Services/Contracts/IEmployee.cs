using Shared.Models;

namespace CemusDigitalApi.Services.Contracts
{
    public interface IEmployee : IGeneral
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task<Employee> UpdateEmployee(int id, Employee employee);

        Task<Employee> DeleteEmployee(int id);

        Task<Employee> AssignEmployee(int id, Employee employee);
    }
}
