using BlazorAirBnb.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorAirBnb.Models;
using BlazorAirBnb.Models.Response;

namespace BlazorAirBnb.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService? _categoryService;

        public CategoryController(ICategoryService? categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Category cannot be null" });
            }
            var categoryResp = await _categoryService!.AddCategory(category);
            if (categoryResp)
            {
                return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "Category Created Successfully" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to Create Category" });
        }


        [HttpGet]
        [Route("allCategories")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategory()
        {
            var categoryResp = await _categoryService!.GetAllCategories();
            if (categoryResp is not null)
            {
                return StatusCode(StatusCodes.Status200OK, categoryResp);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to get Categories" });
        }

    }



}
