using Shared.Models;

namespace CemusDigitalApi.Services.Contracts
{
    public interface IBatch : IGeneral
    {
        Task<IEnumerable<Batch>> GetBatchs();

        Task<Batch> GetBatchById(int id);

        Task<Batch> UpdateBatch(int id, Batch batch);

        Task<Batch> DeleteBatch(int id);

        Task<Batch> AssignBatchToDepartment(int id, Batch batch);
    }
}
