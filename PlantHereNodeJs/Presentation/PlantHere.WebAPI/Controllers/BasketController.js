//  SERVICE
const BasketService = require('../../../Core/PlantHere.Aplication/Services/BasketService').BasketService
const BasketRepository = require('../../../Infratructure/PlantHere.Persistance/Repositories/BasketRepository').BasketRepository


const basketRepository = new BasketRepository();
const service = new BasketService(basketRepository);

const createBasket = async (req, res, next) => {
    try {
        res.status(201).json(await service.createBasket(req))
    } catch (error) {
        next(error)        
    }
}


const getBasketByUserId = async (req, res, next) => {
    try {
        res.json(await service.getBasketByUserId(req))
    } catch (error) {
        next(error)        
    }
}

const buyBasket = async(req,res,next) => {
    try {
        res.json(await service.buyBasket(req))
    } catch (error) {
        next(error)        
    }
}


const createBasketItem = async(req,res,next) => {
    try {
        res.status(201).json(await service.createBasketItem(req))
    } catch (error) {
        next(error)        
    }
}


const updateBasketItem = async(req,res,next) => {
    try {
        res.json(await service.updateBasketItem(req))
    } catch (error) {
        next(error)        
    }
}


const deleteBasketItem = async(req,res,next) => {
    try {
        res.json(await service.deleteBasketItem(req))
    } catch (error) {
        next(error)        
    }
}


module.exports = {
    createBasket,
    getBasketByUserId,
    buyBasket,
    deleteBasketItem,
    updateBasketItem,
    createBasketItem
}



