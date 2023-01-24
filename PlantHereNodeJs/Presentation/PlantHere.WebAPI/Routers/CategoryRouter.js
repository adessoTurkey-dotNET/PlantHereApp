const router = require('express').Router()

const categoryController = require('../Controllers/CategoryController')

const { CatchErrors } = require('../../../Core/PlantHere.Aplication/Middlewares/CustomExceptionHandler')
const AuthenticationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const AuthorizationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')
const setRole = require('./SetRole')

router.get('/', categoryController.getCategories)
router.get('/:id', categoryController.getCategoryById)
router.post('/', setRole(["seller", "superadmin"]), [AuthenticationMiddleware, AuthorizationMiddleware], CatchErrors(categoryController.createCategory))
router.put('/', setRole(['superadmin']), [AuthenticationMiddleware, AuthorizationMiddleware], CatchErrors(categoryController.updateCategory))
router.delete('/', setRole(['superadmin']), [AuthenticationMiddleware, AuthorizationMiddleware], CatchErrors(categoryController.deleteCategory))

module.exports = router;