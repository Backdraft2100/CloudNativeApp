namespace Catalog.API;

//Using constants avoid memory allocation

public static class Constants
{
    public static class Routes
    {
        public const string CreateProduct = "/products";
        public const string GetProduct = "/products";
        public const string GetProductsById = "/products/{id}";
        public const string GetProductsByCategory = "/products/category/{category}";
        public const string UpdateProduct = "/products";
        public const string DeleteProduct = "/products/{id}";
    }
}
