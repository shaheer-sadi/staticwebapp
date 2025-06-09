using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;

namespace Api;

public class ProductGet
{
    private readonly ILogger<ProductGet> _logger;

    private readonly IProductData _productData;

    public ProductGet(IProductData productData)
    {
        _productData = productData;
    }

    [FunctionName("ProductGet")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req)
    {
        var products = await _productData.GetProducts();
        return new OkObjectResult(products);
    }
}
