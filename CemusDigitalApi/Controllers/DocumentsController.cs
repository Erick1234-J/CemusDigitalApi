using CemusDigitalApi.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace CemusDigitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocuments _documents;

        public DocumentsController(IDocuments documents)
        {
            _documents = documents;
        }

        [HttpPost]
        [Route("AddDocument")]

        public async Task<ActionResult<Documents>> AddDocument(Documents documents)
        {
            var result = await _documents.SaveData<Documents>(documents);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
