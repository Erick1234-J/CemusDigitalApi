using Shared.Models;

namespace CemusDigitalApi.Services.Contracts
{
    public interface IDepartment : IGeneral
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task<Department> GetDepartmentById(int id);

        Task<Department> UpdateDepartment(int id, Department department);

        Task<Department> DeleteDepartment(int id);
    }
}
