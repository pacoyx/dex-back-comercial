using Microsoft.AspNetCore.Mvc;

namespace DexterCompany.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceListMainController : ControllerBase
    {
        private readonly IPriceListMainService _priceListMainService;

        public PriceListMainController(IPriceListMainService priceListMainService)
        {
            _priceListMainService = priceListMainService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceListMain>>> GetAll()
        {
            var priceListMains = await _priceListMainService.GetAll();
            return Ok(new ApiResponse { Code = 100, Message = "Lista de precios encontradas", Data = priceListMains });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PriceListMain>> GetById(int id)
        {
            var priceListMain = await _priceListMainService.GetById(id);
            if (priceListMain == null)
            {
                return NotFound(new ApiResponse { Code = 99, Message = "Lista de precio no encontrada", Data = null });

            }
            return Ok(new ApiResponse { Code = 100, Message = "Lista de precio encontrada", Data = priceListMain });
        }

        [HttpPost]
        public async Task<ActionResult<PriceListMain>> Create(CreatePriceListDto priceListMainDto)
        {
            var priceListMain = priceListMainDto.AsPriceListMain();
            await _priceListMainService.Create(priceListMain);
            return Ok(new ApiResponse { Code = 100, Message = "Lista de precio registrado", Data = priceListMain });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdatePriceListDto updatePriceListMainDto)
        {
            if (id != updatePriceListMainDto.Id)
            {
                return BadRequest();
            }

            var updated = await _priceListMainService.Update(id, updatePriceListMainDto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var priceListMain = await _priceListMainService.GetById(id);
            if (priceListMain == null)
            {
                return NotFound();
            }
            var deleted = await _priceListMainService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}