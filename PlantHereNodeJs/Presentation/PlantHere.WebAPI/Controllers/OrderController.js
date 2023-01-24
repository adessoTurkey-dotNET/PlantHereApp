//  SERVICE
const OrderService = require('../../../Core/PlantHere.Aplication/Services/OrderService').OrderService
const OrderRepository = require('../../../Infratructure/PlantHere.Persistance/Repositories/OrderRepository').OrderRepository

const orderRepository = new OrderRepository();
const service = new OrderService(orderRepository);

//Results
const {CustomResult} = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Results/CustomResult')


const getOrdersByUserId = async (req, res) => {
    res.json(CustomResult.Success(await service.getOrdersByUserId(req)))
}

module.exports = {
    getOrdersByUserId,
}



