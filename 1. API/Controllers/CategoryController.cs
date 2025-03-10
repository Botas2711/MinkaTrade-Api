﻿using _1._API.Filter;
using _1._API.Request;
using _1._API.Response;
using _2._Domain.Categories;
using _3._Data.Categories;
using _3._Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryData _categoryData;
        private ICategoryDomain _categoryDomain;
        private IMapper _mapper;

        public CategoryController(ICategoryData categoryData, ICategoryDomain categoryDomain, IMapper mapper)
        {
            _categoryData = categoryData;
            _categoryDomain = categoryDomain;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        /// <summary>
        /// Get all categories without filters
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<List<CategoryResponse>> GetAll()
        {
            var categories = await _categoryData.GetAllAsycnc();
            var response = _mapper.Map<List<Category>, List<CategoryResponse>>(categories);
            return response;
        }

        // GET api/<CategoryController>/5
        /// <summary>
        /// Get one category with a filter of its id
        /// </summary>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<CategoryResponse> Get(int id)
        {
            var category = await _categoryDomain.GetByIdAsync(id);
            var response = _mapper.Map<Category, CategoryResponse>(category);
            return response;
        }

        // POST api/<CategoryController>
        /// <summary>
        /// Register a category
        /// </summary>
        [HttpPost]
        [Authorize("admin")]
        public async Task<IActionResult> Post([FromBody] CategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<CategoryRequest, Category>(request);
                var result = await _categoryDomain.CreateAsync(category);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<CategoryController>/5
        /// <summary>
        /// Update a category
        /// </summary>
        [HttpPut("{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<CategoryRequest, Category>(request);
                var result = await _categoryDomain.UpdateAsync(category, id);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
