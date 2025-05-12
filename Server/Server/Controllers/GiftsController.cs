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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var gifts = await _giftService.GetAllGiftsAsync();
            return Ok(gifts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var gift = await _giftService.GetGiftByIdAsync(id);
            if (gift == null)
            {
                return NotFound();
            }
            return Ok(gift);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GiftDTO giftDTO)
        {
            if (giftDTO == null)
            {
                return BadRequest();
            }
            var gift= _mapper.Map<Gift>(giftDTO);
            await _giftService.AddGiftAsync(gift);
            return CreatedAtAction(nameof(GetById), new { id = gift.Id }, gift);///////
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GiftDTO giftDTO)
        {
            var gift = _mapper.Map<Gift>(giftDTO);
            var gifts = await _giftService.GetAllGiftsAsync();
            if (gifts == null)
                return BadRequest("There are no gifts!!!");
            var foundGift = gifts.First(g => g.Id == id);
            if (foundGift == null)
                return BadRequest("Gift didnwt found!!");
            if (gift.Price != 0)
                foundGift.Price = gift.Price;
            if (gift.CategoryID != 0)//לחפש אם קיים כזה
                foundGift.CategoryID = gift.CategoryID;
            if (gift.GiftName.Equals(""))
                foundGift.GiftName = gift.GiftName;
            if (gift.DonorId != 0)//לחפש אם קיים כזה
                foundGift.DonorId = gift.DonorId;
            await _giftService.UpdateGiftAsync(gift);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _giftService.DeleteGiftAsync(id);
            return NoContent();
        }
    }
}
