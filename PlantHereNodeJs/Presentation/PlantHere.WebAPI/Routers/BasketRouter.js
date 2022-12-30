const router = require('express').Router()
const basketController = require('../Controllers/BasketController')

const AuthenticationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const AuthorizationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')
const setRole = require('./SetRole')

router.post('/',setRole(["customer","superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware],basketController.createBasket)
router.get('/',setRole(["customer"]),[AuthenticationMiddleware,AuthorizationMiddleware],basketController.getBasketByUserId)
router.post('/BuyBasket',setRole(["customer","superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware],basketController.buyBasket)

module.exports = router;