# Catalog.API

### Available operations

| Operation | Use Cases | Request URI |
| --------- | --------- | ------------- |
| GET | List all products | /products    |
| GET | Get products by id  | /products/{id}    |
| GET | Get products by categroy  | /products/category    |
| POST | [Create new product](#Create-product)  | /products  |
| PUT | Update product  | /products/{id}  |
| DELETE | Delete product  | /products/{id}  |


### <a id="Create-product"></a> Request message
```json
{
  "Name": "New product A",
  "Category": ["c1", "c2"],
  "Description": "Description product A",
  "ImageFile": "ImageFile product A",
  "Price": 199
}
```

### Response message
```json
{
  "ID": "00000000-0000-0000-0000-000000000000"
}
```
