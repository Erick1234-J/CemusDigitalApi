namespace CemusDigitalApi.Services.Contracts
{
    public interface IGeneral
    {
        Task<T> SaveData<T>(T entity) where T : class;
    }
}
