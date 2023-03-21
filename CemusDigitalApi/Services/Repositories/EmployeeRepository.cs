using CemusDigitalApi.Data;
using CemusDigitalApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace CemusDigitalApi.Services.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly CemusDbContext _db;

        public EmployeeRepository(CemusDbContext db)
        {
            _db = db;
        }

        public async Task<Employee> AssignEmployee(int id, Employee employee)
        {
            try
            {
                var emp = await _db.Employees.FindAsync(id);
                if (emp != null)
                {
                    emp.DepartmentsId = employee.DepartmentsId;
                    _db.Employees.Update(emp);
                    await _db.SaveChangesAsync();
                }
                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _db.Employees.FindAsync(id);

                var documents = await _db.Documents.Where(c => c.EmployeeId == id).Include(v => v.Employee).Where(v => v.EmployeeId == 0 || v.EmployeeId != 0).ToListAsync();

                if(documents != null)
                {
                    foreach (var document in documents)
                    {
                        document.EmployeeId = null;
                        _db.Documents.Update(document);
                        await _db.SaveChangesAsync();
                    }
                }

                if(employee!= null)
                {
                    employee.RouteFlag = employee.Status;
                    employee.Status = "ACHIEVED";
                    _db.Employees.Update(employee);
                    await _db.SaveChangesAsync();
                }
                return employee!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _db.Employees.Where(c => c.Id == id).Include(v => v.Departments).Where(v => v.DepartmentsId == 0 || v.DepartmentsId != 0).FirstOrDefaultAsync();
                return employee!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                var employees = await _db.Employees.Where(c => c.Status != "ACHIEVED").Include(v => v.Departments).Where(v => v.DepartmentsId == 0 || v.DepartmentsId != 0).ToListAsync();
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> SaveData<T>(T entity) where T : class
        {
            try
            {
                if (entity != null)
                {
                    await _db.Set<T>().AddAsync(entity);
                    await _db.SaveChangesAsync();


                }
                return entity!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var emp = await _db.Employees.FindAsync(id);
                
                if (emp != null)
                {
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.Title = employee.Title;
                    emp.Address = employee.Address;
                    emp.EmployeeNo = employee.EmployeeNo;
                    _db.Employees.Update(emp);
                    await _db.SaveChangesAsync();
                }
                return employee!;
            }catch(Exception)
            {
                throw;
            }
        }
    }
    
}
