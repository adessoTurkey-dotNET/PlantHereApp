// Interface - Service

const Interface = require("es6-interface");
const {IBasketService} = require('../../../Core/PlantHere.Aplication/Interfaces/Services/IBasketService')
const {PaymentService} = require('../../../Infratructure/PlantHere.Infratructure/PaymentService')
// Results
const {CustomResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Results/CustomResult");

// RequestResponseModels

const {CreateBasketCommandResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Basket/Commands/CreateBasket/CreateBasketCommandResult")
const {CreateBasketCommand} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Basket/Commands/CreateBasket/CreateBasketCommand")

const {GetBasketByUserIdQuery} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Basket/Queries/GetBasketByUserId/GetBasketByUserIdQuery")
const {GetBasketByUserIdQueryResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Basket/Queries/GetBasketByUserId/GetBasketByUserIdQueryResult")

const {CreateBasketItemCommand} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/BasketItem/Commands/CreateBasketItem/CreateBasketItemCommand")
const {CreateBasketItemCommandResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/BasketItem/Commands/CreateBasketItem/CreateBasketItemCommandResult")

const {DeleteBasketItemCommand} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/BasketItem/Commands/DeleteBasketItem/DeleteBasketItemCommand")
const {DeleteBasketItemCommandResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/BasketItem/Commands/DeleteBasketItem/DeleteBasketItemCommandResult")

const {UpdateBasketItemCommand} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/BasketItem/Commands/UpdateBasketItem/UpdateBasketItemCommand")
const {UpdateBasketItemCommandResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/BasketItem/Commands/UpdateBasketItem/UpdateBasketItemCommandResult")

const {BuyBasketCommand} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Basket/Commands/BuyBasket/BuyBasketCommand")
const {BuyBasketCommandResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Basket/Commands/BuyBasket/BuyBasketComamndResult")


// Mapper
const { Mapper } = require('../../../Core/PlantHere.Aplication/Mapping/BasketProfile');

class BasketService extends Interface(IBasketService)
{
    constructor(repository) {
        super()
        this.repository = repository;
        this.paymentService = new PaymentService()
    }

    async createBasket(req){
        return CustomResult.Success(new  CreateBasketCommandResult(await this.repository.createBasket(new CreateBasketCommand(req.userId))))
    }

    async getBasketByUserId(req) {

        const result = await this.repository.getBasketByUserId(new GetBasketByUserIdQuery(req.userId))
        return CustomResult.Success(Mapper(result,GetBasketByUserIdQueryResult))
    }

    async buyBasket(req){

        if(this.paymentService.ReceiverPayment(req.payment))
        {
            await this.repository.buyBasket(new BuyBasketCommand(req.userId,req.body.address))
            return CustomResult.Success(new BuyBasketCommandResult("Payment Successful..."))
        }
        else
        {
            return CustomResult.Fail(new BuyBasketCommandResult("Payment Failed..."))
        }
    }

    async createBasketItem(req){
        return CustomResult.Success(new  CreateBasketItemCommandResult(await this.repository.createBasketItem(new CreateBasketItemCommand(req.body.productId,req.userId,req.body.productName,req.body.price,req.body.discountedPrice))))
    }

    async deleteBasketItem(req){
        return CustomResult.Success(new  DeleteBasketItemCommandResult(await this.repository.deleteBasketItem(new DeleteBasketItemCommand(req.userId,req.body.productId))))
    }

    async updateBasketItem(req){
        return CustomResult.Success(new  UpdateBasketItemCommandResult(await this.repository.updateBasketItem(new UpdateBasketItemCommand(req.body.productId,req.userId,req.body.count))))
    }
}

module.exports = { BasketService }