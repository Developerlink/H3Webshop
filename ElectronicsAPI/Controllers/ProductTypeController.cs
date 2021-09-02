using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypesController(IProductRepository productRepository, IProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }

        // GET: <ProductTypesController>
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProductTypes()
        {
            var productTypes = _productTypeRepository.GetProductTypes();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productTypeDtos = new List<ProductTypeDto>();
            foreach (var productType in productTypes)
            {
                var productTypeDto = new ProductTypeDto(productType);
                productTypeDtos.Add(productTypeDto);
            }

            return Ok(productTypeDtos);
        }

        // GET <ProductTypesController>/5
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProductType(int id)
        {
            if (!_productTypeRepository.ProductTypeExists(id))
            {
                return NotFound();
            }

            var productType = _productTypeRepository.GetProductType(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productTypeDto = new ProductTypeDto(productType);

            return Ok(productTypeDto);
        }

        // POST <ProductTypesController>
        [HttpPost]
        public ActionResult PostProductType([FromBody] ProductType productType)
        {
            if (productType == null)
            {
                return BadRequest(ModelState);
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (!_productTypeRepository. .CreateProduct(productType))
            //{
            //    ModelState.AddModelError("", $"Something went wrong saving the Product");
            //    return StatusCode(500, ModelState);
            //}

            //var productDto = new ProductTypeDto(productType);

            //return CreatedAtAction("GetProduct", new { id = productDto.Id }, productDto);
            return CreatedAtAction("GetProduct", new { id = productType.Id }, productType);
        }

        // PUT <ProductTypesController>/5
        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody] Product product)
        {
            //if (product == null)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (productId != product.Id)
            //{
            //    ModelState.AddModelError("", $"The URL ProductId '{productId}' does not match the Productobjects Id '{product.Id}'");
            //    return BadRequest(ModelState);
            //}

            //if (!_productRepository.ProductExists(product.Id))
            //{
            //    ModelState.AddModelError("", "Product does not exist!");
            //}

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (!_productRepository.UpdateProduct(product))
            //{
            //    ModelState.AddModelError("", $"Something went wrong updating Product with Id({product.Id})");
            //    return StatusCode(500, ModelState);
            //}

            // Usually nothing is returned when updating. 
            return NoContent();
        }

        // DELETE <ProductTypesController>/5
        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            //if (!_productRepository.ProductExists(productId))
            //{
            //    return NotFound();
            //}

            //if (_orderLineRepository.GetOrderLinesFromProduct(productId).Count() > 0)
            //{
            //    ModelState.AddModelError("", $"Product with Id({productId}) cannot be deleted because it is associated with at least one orderline");
            //    return StatusCode(409, ModelState);
            //}

            //var orderLinesToDelete = _orderLineRepository.GetOrderLinesFromProduct(productId);
            //var storeProductTypesToDelete = _storeProductRepository.GetStoreProductTypesFromProduct(productId);

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (orderLinesToDelete.Count > 0)
            //{
            //    if (!_orderLineRepository.DeleteOrderLinesByProduct(productId))
            //    {
            //        ModelState.AddModelError("", $"Something went wrong deleting orderlines with Product with Id { productId }");
            //        return StatusCode(500, ModelState);
            //    }
            //}

            //if (storeProductTypesToDelete.Count > 0)
            //{
            //    if (!_storeProductRepository.DeleteStoreProductByProduct(productId))
            //    {
            //        ModelState.AddModelError("", $"Something went wrong deleting store ProductTypes by Product with Id { productId }");
            //        return StatusCode(500, ModelState);
            //    }
            //}

            //if (!_productRepository.DeleteProduct(productId))
            //{
            //    ModelState.AddModelError("", $"Something went wrong deleting Product with Id { productId }");
            //    return StatusCode(500, ModelState);
            //}

            return NoContent();
        }
    }
}
