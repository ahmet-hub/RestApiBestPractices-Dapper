using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.Api.Dal;
using Rest.Api.Dtos;
using Rest.Api.Entities;
using Rest.Api.Helpers;
using Rest.Api.Helpers.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        /// <summary>
        ///     Kategorilerin listesini döner.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDataResponse<List<CategoryDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _categoryRepository.GetAll();

                if (result != null)
                {
                    return Ok(new SuccessDataResponse<List<CategoryDto>>(_mapper.Map<List<CategoryDto>>(result)));
                }

                return BadRequest(new ErrorResponse());
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


        [HttpGet("products")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDataResponse<List<CategoryDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        public async Task<IActionResult> GetAllDetails()
        {
            try
            {
                var result = await _categoryRepository.GetAllWithProducts();

                if (result != null)
                {
                    return Ok(new SuccessDataResponse<List<CategoryDetailDto>>(_mapper.Map<List<CategoryDetailDto>>(result)));
                }

                return BadRequest(new ErrorResponse());
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        /// <summary>
        ///     Id'si grilen kategoriyi döner.
        /// </summary>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDataResponse<CategoryDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _categoryRepository.Get(id);

                if (result != null)
                {
                    return Ok(new SuccessDataResponse<CategoryDto>(_mapper.Map<CategoryDto>(result)));
                }

                return BadRequest(new ErrorResponse());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
           

        }

        /// <summary>
        ///    Kategori ekler.
        /// </summary>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDataResponse<CategoryDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        public async Task<IActionResult> Post(CategoryDto categoryDto)
        {
            try
            {
                var result = await _categoryRepository.Add(_mapper.Map<Category>(categoryDto));

                if (result != null)
                {
                    return Ok(new SuccessDataResponse<CategoryDto>(_mapper.Map<CategoryDto>(result)));
                }

                return BadRequest(new ErrorResponse());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        ///    Kategori günceller.
        /// </summary>
        /// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        public async Task<IActionResult> Put(CategoryUpdateDto categoryDto)
        {
            try
            {
                var result = await _categoryRepository.Update(_mapper.Map<Category>(categoryDto));

                if (result > 0)
                {
                    return Ok(new SuccessResponse("Kategori güncellendi."));
                }

                return BadRequest(new ErrorResponse());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        /// <summary>
        ///    Kategori siler.
        /// </summary>
        /// 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _categoryRepository.Delete(id);

                if (result > 0)
                {
                    return Ok(new SuccessResponse("Kategori silindi."));
                }

                return BadRequest(new ErrorResponse());

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}
