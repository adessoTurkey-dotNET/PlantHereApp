const {GetOrdersByUserIdQueryResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Order/Queries/GetOrdersByUserId/GetOrdersByUserIdQueryResult")
const {AddressQueryResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Address/Queries/AddressQueryResult")

const Mapper = (result) => {
    const adress = new AddressQueryResult(result.Address_Province,result.Address_District,result.Address_Street,result.Address_ZipCode,result.Address_Line)
    return new GetOrdersByUserIdQueryResult(result.CreatedDate,adress,result.BuyerId,result.OrderItems)
}


module.exports = { Mapper }