using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ProductDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, ApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validattionResult = _validator.Validate(product);
            if (!validattionResult.IsValid)
            {
                return BadRequest(validattionResult.Errors.Select(t => t.ErrorMessage));
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(new { message = "Ürün ekleme işlemi başarılı", data = product });
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlmei başarılı");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validattionResult = _validator.Validate(product);
            if (!validattionResult.IsValid)
            {
                return BadRequest(validattionResult.Errors.Select(t => t.ErrorMessage));
            }

            _context.Products.Update(product);
            _context.SaveChanges();

            return Ok(new { message = "Ürün güncelleme işlemi başarılı", data = product });
        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult PostProduct(CreateProductDto createProductDto) 
        { 
            var value = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("ProducListWithCategory")]
        public IActionResult ProducListWithCategory()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(values));
        }
    }
}
