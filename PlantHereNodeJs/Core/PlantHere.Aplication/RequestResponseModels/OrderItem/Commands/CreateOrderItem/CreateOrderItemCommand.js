const Guid = require("../../../../../PlantHere.Aplication/Services/GuidService")

class CreateOrderItemCommand{
    constructor(productId,productName,price,discountedPrice,count) {
        this.ProductId = productId,
        this.ProductName = productName,
        this.Price = price,
        this.DiscountedPrice = discountedPrice,
        this.UniqueId  = Guid.createGuid(),
        this.CreatedDate =  Guid.dateNow(); 
        this.UpdatedDate = Guid.dateNow(),
        this.Count = count
    }
}

module.exports =  {CreateOrderItemCommand}