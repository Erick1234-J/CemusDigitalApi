using Shared.Models;

namespace CemusDigitalApi.Services.Contracts
{
    public interface IDocVersion : IGeneral
    {
        Task<DocVersion> GetDocVersion(int id);

        Task<IEnumerable<DocVersion>> GetDocVersions();

        Task<DocVersion> UpdateDocVersion(int id, DocVersion docVersion);

        Task<DocVersion> DeleteDocVersion(int id);

        Task<DocVersion> AssignVersion(int id, DocVersion docVersion);
    }
}
