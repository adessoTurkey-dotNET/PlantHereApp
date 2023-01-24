const router = require('express').Router()
const productController = require('../Controllers/ProductController')

const { CatchErrors } = require('../../../Core/PlantHere.Aplication/Middlewares/CustomExceptionHandler')
const AuthenticationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const AuthorizationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')
const setRole = require('./SetRole')


router.get('/', CatchErrors(productController.getProducts))
router.get('/GetProductsByPage/:page/:pageSize', CatchErrors(productController.getProductsByPage))
router.get('/ByCategory/:categoryId', CatchErrors(productController.getProductsByCategoryIdAndPage))
router.get('/GetProductsCount', CatchErrors(productController.getProductsCount))
router.get('/:id', CatchErrors(productController.getProductById))

router.post('',setRole(["seller","superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware], CatchErrors(productController.createProduct))
router.put('',setRole(["seller","superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware], CatchErrors(productController.updateProduct))
router.delete('/:id',setRole(["superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware], CatchErrors(productController.deleteProduct))

module.exports = router;