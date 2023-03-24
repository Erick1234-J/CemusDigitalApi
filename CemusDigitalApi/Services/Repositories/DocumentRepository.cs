using CemusDigitalApi.Data;
using CemusDigitalApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace CemusDigitalApi.Services.Repositories
{
    public class DocumentRepository : IDocuments
    {
        private readonly CemusDbContext _db;

        public DocumentRepository(CemusDbContext db)
        {
            _db = db;
        }

        public async Task<Documents> AssignDocumentToEmployee(int id, Documents documents)
        {
            try
            {
                var emp = await _db.Documents.FindAsync(id);

                if (emp != null)
                {
                    emp.EmployeeId = documents.EmployeeId;
                    _db.Documents.Update(emp);
                    await _db.SaveChangesAsync();
                }
                return documents;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Documents> AssignDocumentToVersion(int id, Documents documents)
        {
            try
            {
                var docVersion = await _db.Documents.FindAsync(id);

                if (docVersion != null)
                {
                    docVersion.VersionId = documents.VersionId;
                    _db.Documents.Update(docVersion);
                    await _db.SaveChangesAsync();
                }
                return documents;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Documents> DeleteDocument(int id)
        {
            try
            {
                var doc = await _db.Documents.FindAsync(id);

                if(doc != null)
                {
                    doc.RouteFlag = doc.Status;
                    doc.Status = "ACHIEVED";
                    _db.Documents.Update(doc);
                    await _db.SaveChangesAsync();
                }
                return doc!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Documents> GetDocumentById(int id)
        {
            try
            {
                var doc = await _db.Documents.Where(c => c.Id == id)
                    .Include(v => v.Version).Where(v => v.VersionId == 0 || v.VersionId != 0)
                    .Include(d => d.Employee).Where(d => d.EmployeeId == 0 || d.EmployeeId != 0).FirstOrDefaultAsync();

                return doc!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Documents>> GetDocuments()
        {
            try
            {
                var doc = await _db.Documents.Where(c => c.Status != "ACHIEVED")
                    .Include(v => v.Version).Where(v => v.VersionId == 0 || v.VersionId != 0)
                    .Include(d => d.Employee).Where(d => d.EmployeeId == 0 || d.EmployeeId != 0).ToListAsync();

                return doc!;
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

        public async Task<Documents> SearchDocument(string searchItem)
        {
            try
            {
                var searched = await _db.Documents.Where(c => c.Name.Contains(searchItem) || c.Type.Contains(searchItem))
                    .Include(v => v.Version).Where(v => v.VersionId == 0 || v.VersionId != 0)
                    .Include(d => d.Employee).Where(d => d.EmployeeId == 0 || d.EmployeeId != 0).FirstOrDefaultAsync();

                return searched!;
                
            }catch(Exception)
            {
                throw;
            }
        }

        public async Task<Documents> UpdateDocument(int id, Documents documents)
        {
            try
            {
                var doc = await _db.Documents.FindAsync(id);

                if(doc != null)
                {
                    doc.Name = documents.Name;
                    doc.Type = documents.Type;
                    _db.Documents.Update(doc);
                    await _db.SaveChangesAsync();
                }
                return documents!;
            }catch(Exception)
            {
                throw;
            }
        }
    }
}