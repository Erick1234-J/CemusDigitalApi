using Shared.Models;

namespace CemusDigitalApi.Services.Contracts
{
    public interface IDocuments : IGeneral
    {
        Task<IEnumerable<Documents>> GetDocuments();

        Task<Documents> GetDocumentById(int id);

        Task<Documents> UpdateDocument(int id, Documents documents);

        Task<Documents> DeleteDocument(int id);

        Task<Documents> AssignDocumentToEmployee(int id, Documents documents);

        Task<Documents> AssignDocumentToVersion(int id, Documents documents);

        Task<Documents> SearchDocument(string searchItem);


    }
}
