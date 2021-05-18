using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.Api.Dal;
using Rest.Api.Dal.Concrete;
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
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        ///     Ürünlerin listesini döner.
        /// </summary>
        /// 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDataResponse<List<ProductDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _productRepository.GetAll();

                if (result != null)
                {
                    return Ok(new SuccessDataResponse<List<ProductDto>>(_mapper.Map<List<ProductDto>>(result)));
                }

                return BadRequest(new ErrorResponse());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }
        /// <summary>
        ///    Ürünleri kategori bilgisi ile döner.
        /// </summary>
        [HttpGet("categories")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDataResponse<List<ProductDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        public async Task<IActionResult> GetAllDetails()
        {
            try
            {
                var result = await _productRepository.GetAllDetails();

                if (result != null)
                {
                    return Ok(new SuccessDataResponse<List<ProductDetailsDto>>(_mapper.Map<List<ProductDetailsDto>>(result)));
                }

                return BadRequest(new ErrorResponse());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        ///    Id'si girilen ürünü döner.
        /// </summary>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDataResponse<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _productRepository.Get(id);

                if (result != null)
                {
                    return Ok(new SuccessDataResponse<ProductDto>(_mapper.Map<ProductDto>(result)));
                }

                return BadRequest(new ErrorResponse());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
        }
        /// <summary>
        ///   Ürün ekler.
        /// </summary>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDataResponse<List<ProductDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        public async Task<IActionResult> Post(ProductDto productDto)
        {
            try
            {
                var result = await _productRepository.Add(_mapper.Map<Product>(productDto));

                if (result != null)
                {
                    return Ok(new SuccessDataResponse<ProductDto>(_mapper.Map<ProductDto>(result)));
                }

                return BadRequest(new ErrorResponse());

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }
        /// <summary>
        ///   Ürün günceller.
        /// </summary>

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        public async Task<IActionResult> Put(ProductUpdateDto productDto)
        {
            try
            {
                var result = await _productRepository.Update(_mapper.Map<Product>(productDto));

                if (result > 0)
                {
                    return Ok(new SuccessResponse("Ürün güncellendi."));
                }
                return BadRequest(new ErrorResponse());

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///   Ürün siler.
        /// </summary>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Rest.Api.Helpers.Responses.ErrorResponse))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _productRepository.Delete(id);

                if (result > 0)
                {
                    return Ok(new SuccessResponse("Ürün Silindi."));
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
