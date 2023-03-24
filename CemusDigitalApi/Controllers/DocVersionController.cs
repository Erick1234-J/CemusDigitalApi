using CemusDigitalApi.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace CemusDigitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocVersionController : ControllerBase
    {
        private readonly IDocVersion _doc;

        public DocVersionController(IDocVersion doc)
        {
            _doc = doc;
        }

        [HttpPost]
        [Route("AddVersion")]

        public async Task<ActionResult<DocVersion>> AddVersion(DocVersion docVersion)
        {
            var result = await _doc.SaveData<DocVersion>(docVersion);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<DocVersion>> GetDocVersion(int id)
        {
            var result = await _doc.GetDocVersion(id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDocVersions")]

        public async Task<ActionResult<DocVersion>> GetDocVersions()
        {
            var result = await _doc.GetDocVersions();

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateDocVersion/{id}")]
        public async Task<ActionResult<DocVersion>> UpdateDocVersion(int id, DocVersion docVersion)
        {
            var result = await _doc.UpdateDocVersion(id, docVersion);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("AssignVersion/{id}")]
        public async Task<ActionResult<DocVersion>> AssignVersion(int id, DocVersion docVersion)
        {
            var result = await _doc.AssignVersion(id, docVersion);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteDocVersion/{id}")]

        public async Task<ActionResult<DocVersion>> DeleteDocVersion(int id)
        {
            var result = await _doc.DeleteDocVersion(id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
