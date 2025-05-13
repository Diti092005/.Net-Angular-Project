using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Bll;
using Server.Dal;
using Server.Models;
using Server.Models.DTO;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiftsController : ControllerBase
    {
        private readonly IGiftService _giftService;
        private readonly IMapper _mapper;

        public GiftsController(IGiftService giftService, IMapper mapper)
        {
            _giftService = giftService;
            this._mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGiftById(int id)
        {
            try
            {
                var gift = await _giftService.GetGiftById(id);
                return Ok(gift);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGifts()
        {
            try
            {
                var gifts = await _giftService.GetAllGifts();
                return Ok(gifts);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddGift([FromBody] GiftDTO gift)
        {
            try
            {
                if (gift == null)
                {
                    return BadRequest("Gift cannot be null.");
                }
                if (await _giftService.IsTitleExists(gift.GiftName))
                {
                    return Conflict("Gift with this title already exists.");
                }
                var newGift = _mapper.Map<Gift>(gift);
                await _giftService.AddGift(newGift);
                return CreatedAtAction(nameof(GetGiftById), new { id = newGift.Id }, gift);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGift(int id, [FromBody] GiftDTO gift)
        {
            try
            {
                if (gift == null)
                {
                    return BadRequest("Gift cannot be null.");
                }
                var existingGift = await _giftService.GetGiftById(id);
                if (await _giftService.IsTitleExists(gift.GiftName)&& existingGift.GiftName!=gift.GiftName)
                {
                    return Conflict("Gift with this title already exists.");
                }
                await _giftService.UpdateGift(id, gift);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGift(int id)
        {
            try
            {
                await _giftService.DeleteGift(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("sort/category")]
        public async Task<IActionResult> SortByCategory()
        {
            try
            {
                var gifts = await _giftService.SortByCategory();
                return Ok(gifts);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("sort/price")]
        public async Task<IActionResult> SortByPrice()
        {
            try
            {
                var gifts = await _giftService.SortByPrice();
                return Ok(gifts);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] int? numBuyers, [FromQuery] string? donorname, [FromQuery] string? giftname)
        {
            try
            {
                var gifts = await _giftService.Search(numBuyers, donorname, giftname);
                return Ok(gifts);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
