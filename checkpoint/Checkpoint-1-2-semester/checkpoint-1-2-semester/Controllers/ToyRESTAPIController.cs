using checkpoint_1_2_semester.Controllers.DTO;
using checkpoint_1_2_semester.mapper;
using checkpoint_1_2_semester.Services;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint_1_2_semester.Controllers
{

    [ApiController]
    [Route("api/v1/toy")]
    public class ToyRESTAPIController : Controller
    {

        private readonly IToyService _toyService;

        public ToyRESTAPIController(IToyService toyService)
        {
            _toyService = toyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetToys()
        {
            var toys = await _toyService.GetAllToysAsync();
            var toysResponse = ToyMapper.ToDTO(toys);
            
            return Ok(toysResponse);
        }

        [HttpGet("{toyId}")]
        public async Task<IActionResult> GetToy(int toyId)
        {
            var toy = await _toyService.GetToyByIdAsync(toyId);
            if(toy == null)
            {
                return NotFound();
            }

            return Ok(toy);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToy([FromBody] CreateToyRequestDTO createRequest)
        {
            var createToy = ToyMapper.ToDomainObj(createRequest);
            var toyCreated = await _toyService.AddToyAsync(createToy);
            return Ok(toyCreated);
        }

        [HttpPut("{toyId}")]
        public async Task<IActionResult> UpdateToy(int toyId, [FromBody] UpdateToyRequestDTO updateRequest)
        {
            var toyToUpdate = ToyMapper.ToDomainObj(updateRequest);
            var toyFound = await _toyService.EditToyAsync(toyId, toyToUpdate);

            if(toyFound == null)
            {
                return NotFound();
            }
            
            var toyUpdated = await _toyService.UpdateToyAsync(toyFound);
            var toyResponse = ToyMapper.ToDTO(toyUpdated);
            return Ok(toyResponse);
        }

        [HttpDelete("{toyId}")]
        public async Task<IActionResult> DeleteToy(int toyId)
        {
            var toyFound = await _toyService.GetToyByIdAsync(toyId);

            if (toyFound == null)
            {
                return NotFound();
            }

            await _toyService.DeleteToyAsync(toyFound.ToyId);
            return NoContent();
        }
        
    }
}
















