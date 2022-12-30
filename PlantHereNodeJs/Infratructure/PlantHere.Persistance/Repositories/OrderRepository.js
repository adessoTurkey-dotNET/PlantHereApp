// Http Error
const CreateError = require('http-errors')

// Interface
const Interface = require("es6-interface");
const { IOrderRepository } = require('../../../Core/PlantHere.Aplication/Interfaces/Repositories/IOrderRepository')

// Db
const db = require('../AppDbContext');

class OrderRepository extends Interface(IOrderRepository)
{
    async getOrdersByUserId(req) {

        const order = await db.Orders.findOne({
            where: { BuyerId: req.UserId },
            include: { model: db.OrderItems, attributes: ['ProductId', 'ProductName', 'Price', 'DiscountedPrice', 'Count'] },
            attributes: ["Id", "CreatedDate", "Address_Province","Address_District","Address_Street","Address_ZipCode","Address_Line","BuyerId"]
        })
        return order
    }
}

module.exports = { OrderRepository }


