﻿using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ElectronicsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IOrderLineRepository _orderLineRepository;

        public ProductsController(IProductRepository productRepository, IProductTypeRepository productTypeRepository, IOrderLineRepository orderLineRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _orderLineRepository = orderLineRepository;
        }

        // GET: <ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            var products = _productRepository.GetProducts();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ProductDtos = new List<ProductDto>();
            foreach (var Product in products)
            {
                var ProductDto = new ProductDto(Product);
                ProductDtos.Add(ProductDto);
            }

            return Ok(ProductDtos);
        }

        // GET <ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            if (!_productRepository.ProductExists(id))
            {
                return NotFound();
            }

            var product = _productRepository.GetProduct(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productDto = new ProductDto(product);

            return Ok(productDto);
        }

        // POST <ProductsController>
        [HttpPost]
        public ActionResult PostProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest(ModelState);
            }

            if (!_productTypeRepository.ProductTypeExists(product.ProductTypeId))
            {
                return NotFound("Product type was not found!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_productRepository.CreateProduct(product))
            {
                ModelState.AddModelError("", $"Something went wrong saving the Product");
                return StatusCode(500, ModelState);
            }

            var productDto = new ProductDto(product);

            return CreatedAtAction("GetProduct", new { id = productDto.Id }, productDto);
        }

        // PUT <ProductsController>/5
        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest(ModelState);
            }

            if (productId != product.Id)
            {
                ModelState.AddModelError("", $"The URL ProductId '{productId}' does not match the Productobjects Id '{product.Id}'");
                return BadRequest(ModelState);
            }

            if (!_productRepository.ProductExists(product.Id))
            {
                ModelState.AddModelError("", "Product does not exist!");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_productRepository.UpdateProduct(product))
            {
                ModelState.AddModelError("", $"Something went wrong updating Product with Id({product.Id})");
                return StatusCode(500, ModelState);
            }

            // Usually nothing is returned when updating. 
            return NoContent();
        }

        // DELETE <ProductsController>/5
        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            if (!_productRepository.ProductExists(productId))
            {
                return NotFound();
            }

            if (_orderLineRepository.GetOrderLinesFromProduct(productId).Count() > 0)
            {
                ModelState.AddModelError("", $"Product with Id({productId}) cannot be deleted because it is associated with at least one orderline");
                return StatusCode(409, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_productRepository.DeleteProduct(productId))
            {
                ModelState.AddModelError("", $"Something went wrong deleting Product with Id { productId }");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
