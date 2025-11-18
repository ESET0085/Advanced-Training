using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ProductCatalogAPI.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApp : ControllerBase
    {

        // Add a static instance of ProductRepository to access Products
        private static ProductRepository _productRepository = new ProductRepository();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ProductApp is running...");
        }


        [HttpGet]
        [Route("All")]
        public IEnumerable<ProductDTO> Products()
        {
            return _productRepository.Products;
        }

        [HttpGet("{id:int}", Name = "getproductbyid")]
        //[Route("All")]
        public ActionResult<ProductDTO> getproductbyid(int id)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductID == id);
            //if (product == null)
            //{
            //    return NotFound();
            //}

            var productDTO = new ProductDTO()
            {
                
                ProductID = product.ProductID,
                Name = product.Name,
                Category = product.Category,
                Price = product.Price,
                StockQuantity = product.StockQuantity
            };
            return Ok(productDTO);

        }

        [HttpPost("Create")]

        public ActionResult<ProductDTO> Create([FromBody] ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var newProduct = new Product()
            {
                Name = product.Name,
                Category = product.Category,
                Price = product.Price,
                StockQuantity = product.StockQuantity
            };

            
            _productRepository.Products.Add(product);

            
            return CreatedAtRoute("getproductbyid", new { id = product.ProductID }, product);
        }


        [HttpPut("Update/{id:int}")]

        public IActionResult Update(int id, [FromBody] ProductDTO product)
        {
            if (product == null || product.ProductID != id)
            {
                return BadRequest();
            }
            var existingProduct = _productRepository.Products.FirstOrDefault(p => p.ProductID == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;
            return NoContent();
        }

        [HttpPatch("UpdatePartial/{id:int}")]
        public IActionResult UpdatePartial(int id, [FromBody] ProductDTO product)
        {
            if (product == null || product.ProductID != id)
            {
                return BadRequest();
            }
            var existingProduct = _productRepository.Products.FirstOrDefault(p => p.ProductID == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(product.Name))
            {
                existingProduct.Name = product.Name;
            }
            if (!string.IsNullOrEmpty(product.Category))
            {
                existingProduct.Category = product.Category;
            }
            if (product.Price != 0)
            {
                existingProduct.Price = product.Price;
            }
            if (product.StockQuantity != 0)
            {
                existingProduct.StockQuantity = product.StockQuantity;
            }
            return NoContent();
        }



















    }
}
