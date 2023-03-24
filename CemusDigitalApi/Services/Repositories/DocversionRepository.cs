using CemusDigitalApi.Data;
using CemusDigitalApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace CemusDigitalApi.Services.Repositories
{
    public class DocversionRepository : IDocVersion
    {
        private readonly CemusDbContext _db;

        public DocversionRepository(CemusDbContext db)
        {
            _db = db;
        }

        public async Task<DocVersion> AssignVersion(int id, DocVersion docVersion)
        {
            try
            {
                var doc = await _db.Versions.FindAsync(id);
                
                if (doc != null)
                {
                    doc.BatchId = docVersion.BatchId;
                    _db.Versions.Update(doc);
                    await _db.SaveChangesAsync();
                }
                return docVersion;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DocVersion> DeleteDocVersion(int id)
        {
            try
            {
                var doc = await _db.Versions.FindAsync(id);

                var documents = await _db.Documents.Where(c => c.VersionId == id).Include(v => v.Version).Where(v => v.VersionId == 0 || v.VersionId != 0).ToListAsync();

                if(documents != null)
                {
                    foreach (var document in documents)
                    {
                        document.VersionId = null;
                        _db.Documents.Update(document);
                    }
                    await _db.SaveChangesAsync();
                }

                if (doc != null)
                {
                    doc.RouteFlag = doc.Status;
                    doc.Status = "ACHIEVED";
                    _db.Versions.Update(doc);
                   await _db.SaveChangesAsync();
                }
                return doc!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DocVersion> GetDocVersion(int id)
        {
            try
            {
                var docversion = await _db.Versions.Where(c => c.Id == id).Include(v => v.Batch).Where(v => v.BatchId == 0 || v.BatchId != 0).FirstOrDefaultAsync();
                return docversion!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<DocVersion>> GetDocVersions()
        {
            try
            {
                var docVersions = await _db.Versions.Where(c => c.Status != "ACHIEVED")
                    .Include(v => v.Batch).Where(v => v.BatchId == 0 || v.BatchId != 0).ToListAsync();

                return docVersions;
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

        public async Task<DocVersion> UpdateDocVersion(int id, DocVersion docVersion)
        {
            try
            {
                var doc = await _db.Versions.FindAsync(id);

                if (doc != null)
                {
                    doc.Name = docVersion.Name;
                    doc.VersionNumber = docVersion.VersionNumber;
                    _db.Versions.Update(doc);
                    await _db.SaveChangesAsync();
                }
                return docVersion!;
            }catch(Exception)
            {
                throw;
            }
        }
    }
}
