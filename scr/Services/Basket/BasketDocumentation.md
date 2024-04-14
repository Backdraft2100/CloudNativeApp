# Basket.API

## Basket Use cases
### CRUD Operations
* Get shopping cart with items
* Store, create/upsert shopping items including
  * Add item to shopping cart
  * Remove item to shopping cart
  * Update Shoppin cart item (change quantity)
* Delete shopping cart with items

### gRPC Operations
* When store basket: Get discount and deduct discount coupon from item price

### Async Basket Operations
*  Chackout basket and publish event to RabbitMQ Message broker


### Available REST API operations

| Operation | Use Cases | Request URI |
| --------- | --------- | ------------- |
| GET | Get ShoppingCart | /basket/{userName} |
| POST | [Store ShoppingCart](#CStore-ShoppingCart)  | /basket/{userName} |
| DELETE | Delete ShoppingCart  | /basket/{userName} |
| POST | [Checkout ShoppingCart](#Checkout-ShoppingCart)  | /basket/checkout |

### <a id="Store-ShoppingCart"></a> Request message
```json
{
  "Cart": {
    "UserName": "TheUserName",
    "Items": [
      {
        "Quantity": 2,
        "Color": "Red",
        "Price": 500,
        "ProductId": "5334c996-8457-4cf0-815c-ed2b77c4ff61",
        "ProductName": "IPhone X"
      },
      {
        "Quantity": 1,
        "Color": "Blue",
        "Price": 500,
        "ProductId": "c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914",
        "ProductName": "Samsung 10"
      }
    ]
  }
}
```

### <a id="Checkout-ShoppingCart"></a> Request message
```json
{
  
}
```