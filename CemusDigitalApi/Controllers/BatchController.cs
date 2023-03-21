using CemusDigitalApi.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace CemusDigitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatch _batch;

        public BatchController(IBatch batch)
        {
            _batch = batch;
        }
        [HttpPost]
        [Route("AddBatch")]
        public async Task<ActionResult<Batch>> SaveData(Batch batch)
        {
            var result = await _batch.SaveData<Batch>(batch); 

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetBatch/{id}")]
        public async Task<ActionResult<Batch>> GetBatchById(int id)
        {
            var result = await _batch.GetBatchById(id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetBatchs")]

        public async Task<ActionResult<Batch>> GetBatchs()
        {
            var result = await _batch.GetBatchs();

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateBatch/{id}")]
        public async Task<ActionResult<Batch>> UpdateBatch(int id, Batch batch)
        {
            var result = await _batch.UpdateBatch(id, batch);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteBatch/{id}")]

        public async Task<ActionResult<Batch>> DeleteBatch(int id)
        {
            var result = await _batch.DeleteBatch(id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
