using CemusDigitalApi.Data;
using CemusDigitalApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace CemusDigitalApi.Services.Repositories
{
    public class BatchRepository : IBatch
    {
        private readonly CemusDbContext _db;

        public BatchRepository(CemusDbContext db)
        {
            _db = db;
        }
        public async Task<Batch> DeleteBatch(int id)
        {
          try
            {
                var batch = await _db.Batchs.FindAsync(id);
                var version = await _db.Versions.Where(c => c.BatchId == id).Include(v => v.Batch).Where(v => v.BatchId == 0 || v.BatchId != 0).ToListAsync();
            
                if(version != null)
                {
                    foreach(var ver in version)
                    {
                        ver.BatchId = null;
                        _db.Versions.Update(ver);
                        await _db.SaveChangesAsync();
                    }
                }

                if(batch != null)
                {
                    batch.RouteFlag = batch.Status;
                    batch.Status = "ACHIEVED";
                    _db.Batchs.Update(batch);
                    await _db.SaveChangesAsync();
                }
                return batch!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Batch> GetBatchById(int id)
        {
            try
            {
                var batch = await _db.Batchs.FindAsync(id);
                return batch!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Batch>> GetBatchs()
        {
            try
            {
                var batches = await _db.Batchs.Where(c => c.Status != "ACHIEVED").ToListAsync();
                return batches!;
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

        public async Task<Batch> UpdateBatch(int id, Batch batch)
        {
            try
            {
                var bat = await _db.Batchs.FindAsync(id);

                if(bat != null)
                {
                    bat.Name = batch.Name;
                    bat.BatchCode = batch.BatchCode;
                    _db.Batchs.Update(bat);
                    await _db.SaveChangesAsync();
                }
                return batch!;
            }catch(Exception)
            {
                throw;
            }
        }
    }
}
