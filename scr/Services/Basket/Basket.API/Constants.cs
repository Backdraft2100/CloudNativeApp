namespace Basket.API;

//Using constants avoid memory allocation

public static class Constants
{
    public static class Routes
    {
        public const string GetBasket = "/basket/{userName}";
        public const string StoreBasket = "/basket";
        public const string DeleteBasket = "/basket/{userName}";
    }
}
