using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Bll.Interfaces;
using Server.Models;
using Server.Models.DTO;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;
        private readonly IMapper _mapper;
        public DonorController(IDonorService donorService,IMapper mapper)
        {
            _donorService = donorService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonorById(int id)
        {
            var donor = await _donorService.GetDonorById(id);
            if (donor == null)
            {
                return NotFound();
            }
            return Ok(donor);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDonors()
        {
            var donors = await _donorService.GetAllDonors();
            return Ok(donors);
        }
        [HttpGet("/search")]
        public async Task<IActionResult> GetAllDonorsByType(string? mail,string? name,string? giftname)
        {
            var donors = await _donorService.GetAllDonorsByType(mail, name, giftname);
            if (donors == null || !donors.Any())
            {
                return NotFound();
            }
            return Ok(donors);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddDonor([FromBody] DonorDTO donor)
        {
            if (donor == null)
            {
                return BadRequest("Donor cannot be null.");
            }
            var donor1= _mapper.Map<Donor>(donor);
            var result = await _donorService.AddDonor(donor1);
            if (result)
            {
                return CreatedAtAction(nameof(GetDonorById), new { id = donor1.Id }, donor1);
            }
            return BadRequest("Error adding donor.");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonor(int id, [FromBody] DonorDTO donor)
        {
            if (donor == null)
            {
                return BadRequest("Donor cannot be null.");
            }
            var result = await _donorService.UpdateDonor(id, donor);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            var result = await _donorService.DeleteDonor(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
