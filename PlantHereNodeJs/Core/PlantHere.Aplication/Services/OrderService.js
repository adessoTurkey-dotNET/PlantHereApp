// Interface - Service

const Interface = require("es6-interface");
const {IOrderService} = require('../../../Core/PlantHere.Aplication/Interfaces/Services/IOrderService')


// RequestResponseModels

const {GetOrdersByUserIdQuery} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Order/Queries/GetOrdersByUserId/GetOrdersByUserIdQuery")

// Mapper
const { Mapper } = require('../../../Core/PlantHere.Aplication/Mapping/OrderProfile');

class OrderService extends Interface(IOrderService)
{
    constructor(repository) {
        super()
        this.repository = repository;
    }

    async getOrdersByUserId(req) {
        const result = await this.repository.getOrdersByUserId(new GetOrdersByUserIdQuery(req.userId))
        return Mapper(result)
    }
}

module.exports = { OrderService }