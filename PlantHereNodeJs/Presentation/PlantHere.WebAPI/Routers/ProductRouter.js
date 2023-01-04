const router = require('express').Router()
const productController = require('../Controllers/ProductController')

const AuthenticationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const AuthorizationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')
const setRole = require('./SetRole')


router.get('/', productController.getProducts)
router.get('/GetProductsByPage/:page/:pageSize',productController.getProductsByPage)
router.get('/ByCategory/:categoryId',productController.getProductsByCategoryIdAndPage)
router.get('/GetProductsCount',productController.getProductsCount)
router.get('/:id',productController.getProductById)

router.post('',setRole(["seller","superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware],productController.createProduct)
router.put('',setRole(["seller","superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware],productController.updateProduct)
router.delete('/:id',setRole(["superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware],productController.deleteProduct)

module.exports = router;