using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Bll;
using Server.Bll.Interfaces;
using Server.Models;
using Server.Models.DTO;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {

        private readonly ICatergoryService _icatergoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICatergoryService icatergoryService, IMapper mapper)
        {
            this._icatergoryService = icatergoryService;
            this._mapper = mapper;
        }
        [HttpGet("")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            try
            {
                var categories = await _icatergoryService.GetAllCategoryAsync();
                return Ok(categories);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: CategoryController/Create
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GeCategorytById(int id)
        {
            try
            {
                var category = await _icatergoryService.GetCategoryByIdAsync(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryforpost)
        {
            var found = await _icatergoryService.IsExist(categoryforpost.Name);
            if (found)
                return Conflict($"Gift with name {categoryforpost.Name} is exist");
            var category = _mapper.Map<Category>(categoryforpost);
            try
            {
                await _icatergoryService.AddCategoryAsync(category);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: CategoryController/Edit/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] CategoryDTO categoryforupdate)
        {
            if (id == null)
                return BadRequest("id is requaierd");
            if (id < 0)
                return BadRequest("not valid id");
            var category = _mapper.Map<Category>(categoryforupdate);
            try
            {
                await _icatergoryService.UpdateCategoryAsync(id, category);///////////////////////
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id < 0)
                return BadRequest("not valid id");
            try
            {
                await _icatergoryService.DeleteCategoryAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
