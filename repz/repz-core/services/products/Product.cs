
using repz_core.mysql;

namespace repz_core.services.product
{
    public class ProductService
    {

        private ProductStore _productStore;

        public ProductService(ProductStore productStore)
        {
            _productStore = productStore;
        }

        public List<views.Product>? GetAllProducts() => _productStore.GetAllProducts();
    }
}
