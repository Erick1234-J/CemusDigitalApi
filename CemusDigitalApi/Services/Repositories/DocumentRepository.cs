using CemusDigitalApi.Data;
using CemusDigitalApi.Services.Contracts;

namespace CemusDigitalApi.Services.Repositories
{
    public class DocumentRepository : IDocuments
    {
        private readonly CemusDbContext _db;

        public DocumentRepository(CemusDbContext db)
        {
            _db = db;
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
    }
}

//gets title based on the search query
//SELECT titile from Document where title = $searchQuery;
//gets nrc and phonumber based on the search query and the parent Document id foreignkey 
//Select nrc, phoneNumber from ExtractedDocument where nrc = $searchQuery AND DocumentId = id;

//gets nrc from ExtratedDocument table and then joins it with title from Document table and returns them as one query
//Select nrc from ExtractedDocumement JOIN title from Document on ExtractedDocument.DocumentId equals Document.id;