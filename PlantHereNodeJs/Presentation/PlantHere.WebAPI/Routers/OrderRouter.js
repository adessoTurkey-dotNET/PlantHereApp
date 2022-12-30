const router = require('express').Router()
const OrderController = require('../Controllers/OrderController')

const AuthenticationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const AuthorizationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')
const setRole = require('./SetRole')

router.get('/GetOrderByUserId',setRole(["superadmin","customer"]),[AuthenticationMiddleware,AuthorizationMiddleware],OrderController.getOrdersByUserId)

module.exports = router;