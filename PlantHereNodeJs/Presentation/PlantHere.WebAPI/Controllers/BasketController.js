//  SERVICE
const BasketService = require('../../../Core/PlantHere.Aplication/Services/BasketService').BasketService
const BasketRepository = require('../../../Infratructure/PlantHere.Persistance/Repositories/BasketRepository').BasketRepository

const basketRepository = new BasketRepository();
const service = new BasketService(basketRepository);

//Results
const {CustomResult} = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Results/CustomResult')

const createBasket = async (req, res) => {
    res.json(CustomResult.Success(await service.createBasket(req)))
}


const getBasketByUserId = async (req, res) => {
    res.json(CustomResult.Success(await service.getBasketByUserId(req)))
}

const buyBasket = async (req, res) => {
    res.json(CustomResult.Success(await service.buyBasket(req)))
}


const createBasketItem = async (req, res) => {
    res.json(CustomResult.Success(await service.createBasketItem(req)))
}


const updateBasketItem = async (req, res) => {
    res.json(CustomResult.Success(await service.updateBasketItem(req)))
}


const deleteBasketItem = async (req, res) => {
    res.json(CustomResult.Success(await service.deleteBasketItem(req)))
}


module.exports = {
    createBasket,
    getBasketByUserId,
    buyBasket,
    deleteBasketItem,
    updateBasketItem,
    createBasketItem
}



