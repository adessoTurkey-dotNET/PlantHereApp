class PaymentService {
    async ReceiverPayment(payment) {
        console.log(payment)
        return true
    }
}

module.exports = {PaymentService}