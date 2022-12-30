class GetOrdersByUserIdQueryResult{

    constructor(createdDate,address,buyerId,orderItems) {
        this.createDate = createdDate,
        this.address = address,
        this.buyerId = buyerId,
        this.orderItems = orderItems
    }
}

module.exports = { GetOrdersByUserIdQueryResult }