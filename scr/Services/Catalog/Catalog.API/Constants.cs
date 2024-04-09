namespace Catalog.API;

public static class Constants
{
    public static class Routes
    {
        public const string GetProductsById = "/products/{id}";
        public const string GetProductsByCategory = "/products/category/{category}";
        public const string UpdateProduct = "/products";
    }
}
