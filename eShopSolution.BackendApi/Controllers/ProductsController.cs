using Azure.Core;
using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Catalog.ProductImage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IManageProductService _manageProductService;

        public ProductsController( IManageProductService manageProductService)
        {
            _manageProductService = manageProductService;
        }
        [HttpGet("{languageId}")]
        public async Task<IActionResult> Get(string languageId)
        {
            var products = await _manageProductService.GetAll(languageId);
            return Ok(products);
        }

        [HttpGet("public-paging/{languageId}")]
        public async Task<IActionResult> GetAllByCategoryId(string languageId,[FromQuery]GetPublicProductPagingRequest request)
        {
            var products = await _manageProductService.GetAllByCategoryId(languageId, request);
            return Ok(products);
        }

        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _manageProductService.GetById(productId, languageId );
            if (product == null)
            {
                return BadRequest("Cannot find product");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]ProductCreateRequest request)
        {
            var productsId = await _manageProductService.Create(request);
            if(productsId == 0)
            {
                return BadRequest();
            }
            var product = await _manageProductService.GetById(productsId, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new {id = productsId, languageId = request.LanguageId } ,product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductUpateRequest request)
        {
            var affectedResult = await _manageProductService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var affectedResult = await _manageProductService.Delete(productId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var isSuccess = await _manageProductService.UpdatePrice(productId, newPrice);
            if (isSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("{productId}/iamges")]
        public async Task<IActionResult> CreateIamge(int productId ,[FromForm] ProductImageCreateRequest request)
        {
            var productImage = await _manageProductService.AddImage(productId,request);
            if (productImage == 0)
            {
                return BadRequest();
            }
            var image = await _manageProductService.GetImageById(productId);
            return CreatedAtAction(nameof(GetImageById), new { id = productImage }, image);
        }

        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateIamge(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            var productImage = await _manageProductService.UpdateImage( imageId, request);
            if (productImage == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> DeleteIamge( int imageId)
        {
            var productImage = await _manageProductService.DeleteImage(imageId);
            if (productImage == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("{productId}/image/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId)
        {
            var image = await _manageProductService.GetImageById(productId);
            if (image == null)
            {
                return BadRequest("Cannot find product");
            }
            return Ok(image);
        }

    }
}
