const router = require('express').Router()
const OrderController = require('../Controllers/OrderController')

const { CatchErrors } = require('../../../Core/PlantHere.Aplication/Middlewares/CustomExceptionHandler')
const AuthenticationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const AuthorizationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')
const setRole = require('./SetRole')

router.get('/GetOrderByUserId',setRole(["superadmin","customer"]),[AuthenticationMiddleware,AuthorizationMiddleware],CatchErrors(OrderController.getOrdersByUserId))

module.exports = router;