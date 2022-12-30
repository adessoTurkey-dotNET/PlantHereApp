// Http Error
const CreateError = require('http-errors')

// Interface
const Interface = require("es6-interface");
const { IBasketRepository } = require('../../../Core/PlantHere.Aplication/Interfaces/Repositories/IBasketRepository')

// Db
const db = require('../AppDbContext');

const { CreateOrderCommand } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Order/Commands/CreateOrder/CreateOrderCommand');
const { CreateOrderItemCommand } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/OrderItem/Commands/CreateOrderItem/CreateOrderItemCommand')

class BasketRepository extends Interface(IBasketRepository)
{
    async createBasket(req) {

        const basket = await this.getBasketByUserIdBase(req)

        if (basket) {
            throw new CreateError.Conflict()
        }
        await db.Baskets.create(req)
    }

    async getBasketByUserId(req) {

        const basket = await this.getBasketByUserIdWithBasketItem(req)

        if (!basket) {
            throw new CreateError.NotFound()
        }
        return basket
    }

    async getBasketByUserIdBase(req) {
        return await db.Baskets.findOne({
            where: { UserId: req.UserId },
            attributes: ["UserId", "CreatedDate"]
        })
    }

    async getBasketByUserIdWithBasketItem(req) {
        return await db.Baskets.findOne({
            where: { UserId: req.UserId },
            include: { model: db.BasketItems, attributes: ['Id','ProductId', 'ProductName', 'Price', 'DiscountedPrice', 'Count'] },
            attributes: ["Id", "UserId", "CreatedDate"]
        })
    }

    async getBasketItemByProductId(basket, productId) {

        return await db.BasketItems.findOne({
            where: {
                ProductId: productId,
                BasketId: basket.Id
            },
            attributes: ["Id", "ProductName", "Count"]
        })
    }

    async buyBasket(req) {

        const basket = await this.getBasketByUserIdWithBasketItem(req)

        if (!basket) {
            throw new CreateError.NotFound()
        }
 
        if (basket.BasketItems == "") {
            throw new CreateError.NotFound()
        }
        const order = await this.createOrderAndOrderItem(req, basket)
        return order
    }

    async createOrderAndOrderItem(req, basket) {
        const order = new CreateOrderCommand(req.Address, req.UserId, basket.BasketItems)
        const orderResult = await db.Orders.create(order)

        basket.BasketItems.forEach(basketItem => {
            const orderItem = new CreateOrderItemCommand(basketItem.ProductId, basketItem.ProductName, basketItem.Price, basketItem.DiscountedPrice, basketItem.Count)
            orderItem.OrderId = orderResult.Id
            db.OrderItems.create(orderItem)
            basketItem.destroy()
        });

        return orderResult
    }

    async createBasketItem(req) {

        const basket = await this.getBasketByUserIdWithBasketItem(req)
        
        if(!basket) {
            throw new CreateError.NotFound()
        }

        const existProduct = await db.BasketItems.findOne({
            where: {
                ProductId: req.ProductId,
                BasketId: basket.Id
            },
            attributes: ["Id", "ProductName", "Count", "Price"]
        })

        if (!existProduct) {
            req.Count = 1;
            req.BasketId = basket.Id;
            await db.BasketItems.create(req)
        }
        else {
            req.Count = existProduct.Count + 1;
            delete req.Id
            this.updateBasketItem(req)
        }
    }

    async updateBasketItem(req) {
        const basketItem = await this.getBasketItem(req)
        basketItem.update(req)
    }

    async deleteBasketItem(req) {
        const basketItem = await this.getBasketItem(req)
        basketItem.destroy()
    }

    async getBasketItem(req) {
        const basket = await this.getBasketByUserIdWithBasketItem(req)

        if (!basket) {
            throw new CreateError.NotFound()
        }

        const basketItem = await db.BasketItems.findOne({
            where: { ProductId: req.ProductId, BasketId: basket.Id }
        })

        if (!basketItem) {
            throw new CreateError.NotFound()
        }

        return basketItem
    }
}

module.exports = { BasketRepository }


