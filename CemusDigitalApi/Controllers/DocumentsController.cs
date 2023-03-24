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

        [HttpGet("{id}")]

        public async Task<ActionResult<Documents>> GetDocumentById(int id)
        {
            var result = await _documents.GetDocumentById(id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDocuments")]

        public async Task<ActionResult<Documents>> GetDocuments()
        {
            var result = await _documents.GetDocuments();

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateDocument/{id}")]
        public async Task<ActionResult<Documents>> UpdateDocuments(int id, Documents documents)
        {
            var result = await _documents.UpdateDocument(id, documents);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("AssignDocumentToVersion/{id}")]
        public async Task<ActionResult<Documents>> AssignDocumentToVersion(int id, Documents documents)
        {
            var result = await _documents.AssignDocumentToVersion(id, documents);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("AssignDocumentToEmployee/{id}")]
        public async Task<ActionResult<Documents>> AssignDocumentToEmployee(int id, Documents documents)
        {
            var result = await _documents.AssignDocumentToEmployee(id, documents);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteDocument/{id}")]

        public async Task<ActionResult<Documents>> DeleteDocument(int id)
        {
            var result = await _documents.DeleteDocument(id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
