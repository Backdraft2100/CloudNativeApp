# Basket.API

## Ordering Use cases
### CRUD Operations
* Get Order with Item (can filter by Name and Customer)
* CRUD operations including
  * Create a new order
  * Update an exisiting order
  * Delete order
  * Add and remove Item from Order
### Async Ordering operations
* Basket checkout: Consume Basket event from RabbitMQ
* Orde Fulfilment: Perform order fulfilment operation (billing, shipment, notification)
* Raise ORDER_CREATED domain event that leads to integration event.

### Available REST API operations

| Operation | Use Cases | Request URI |
| --------- | --------- | ------------- |
| GET | Get Orders /w Pagination | /orders |
| GET | Get Orders by OrderName | /orders/{orderName} |
| GET | Get Orders by Customer | /orders/customer/{customerId} |
| POST | [NewOrder](#Create a new Order)  | /orders |
| PUT | [UpdateOrder](#Update existing  Order)  | /orders |
| DELETE | Delete order  | /order/{id} |

### <a id="NewOrder"></a> Request message
```json
{
  "Todo" : "Todo"
}
```

### <a id="UpdateOrder"></a> Request message
```json
{
  "Todo" : "Todo"
  
}
```

# diagram

```plantuml
@startuml
!theme amiga
skinparam linetype ortho
Top to bottom direction
rectangle "Presentation" {
package "Web services" {
  HTTPS - [ORDERING.API]
}
}
rectangle "App server" {
together {
package "Domain Model Layer" {
  [Domain entities]
  [Domain Services]
}

package "Application Layer" {
  FTP - [Application Services]
}


}
package "Infrastructure Layer" {
  [Repositories]
}
}

[Presentation] --> [Application Layer]
[Application Layer] -[dashed]-> [Infrastructure Layer]
[Application Layer] --> [Domain Model Layer]
[Infrastructure Layer] --> [Domain Model Layer]

@enduml
```