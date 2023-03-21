using CemusDigitalApi.Data;
using CemusDigitalApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace CemusDigitalApi.Services.Repositories
{
    public class DepartmentRepository : IDepartment
    {
        private readonly CemusDbContext _db;

        public DepartmentRepository(CemusDbContext db)
        {
            _db = db;
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            try
            {
                var dept = await _db.Departments.FindAsync(id);
                var employees = await _db.Employees.Where(v => v.DepartmentsId == id).Include(c => c.Departments).Where(c => c.DepartmentsId ==0 || c.DepartmentsId != 0).ToListAsync();

                if(employees != null)
                {
                    foreach (var employ in employees)
                    {
                        employ.DepartmentsId = null;
                        _db.Employees.Update(employ);
                    }
                    await _db.SaveChangesAsync();
                }

                if(dept != null)
                {
                    dept.RouteFlag = dept.Status;
                    dept.Status = "ACHIEVED";
                    _db.Departments.Update(dept);
                    await _db.SaveChangesAsync();
                }
                return dept!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            try
            {
                var dept = await  _db.Departments.FindAsync(id);
                return dept!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            try
            {
                var dept = await _db.Departments.Where(v => v.Status != "ACHIEVED").ToListAsync();
                return dept;
            }catch(Exception)
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

        public async Task<Department> UpdateDepartment(int id, Department department)
        {
            try
            {
                var dept = await _db.Departments.FindAsync(id);

                if(dept != null)
                {
                    dept.Name = department.Name;
                    _db.Departments.Update(dept);
                    await _db.SaveChangesAsync();
                }
                return department;
            }catch(Exception)
            {
                throw;
            }
        }
    }
}
