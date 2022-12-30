//  SERVICE
const OrderService = require('../../../Core/PlantHere.Aplication/Services/OrderService').OrderService
const OrderRepository = require('../../../Infratructure/PlantHere.Persistance/Repositories/OrderRepository').OrderRepository

const orderRepository = new OrderRepository();
const service = new OrderService(orderRepository);

const getOrdersByUserId = async (req, res, next) => {
    try {
        res.json(await service.getOrdersByUserId(req))
    } catch (error) {
        next(error)        
    }
}

module.exports = {
    getOrdersByUserId,
}



