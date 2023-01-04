//  SERVICE
const ProductService = require('../../../Core/PlantHere.Aplication/Services/ProductService').ProductService
const ProductRepository = require('../../../Infratructure/PlantHere.Persistance/Repositories/ProductRepository').ProductRepository

const productRepository = new ProductRepository();
const service = new ProductService(productRepository);

const getProducts = async (req, res, next) => {
    try {
        res.json(await service.getProducts())
    } catch (error) {
        next(error)
    }
}

const getProductsCount = async (req, res, next) => {
    try {
        res.json(await service.getProductsCount())
    } catch (error) {
        next(error)
    }
}

const getProductsByPage = async (req, res, next) => {
    try {
        res.json(await service.getProductsByPage(req))
    } catch (error) {
        next(error)
    }
}

const getProductsByCategoryIdAndPage = async (req, res, next) => {
    try {
        res.json(await service.getProductsByCategoryIdAndPage(req))
    } catch (error) {
        next(error)        
    }
}

const getProductById = async (req, res, next) => {
    try {
        res.json(await service.getProductsById(req))
    } catch (error) {
        next(error)        
    }
}


const deleteProduct = async (req, res, next) => {
    try {
        res.json(await service.deleteProduct(req))
    } catch (error) {
        next(error)        
    }
}

const createProduct = async (req, res, next) => {
    try {
        res.json(await service.createProduct(req))
    } catch (error) {
        next(error)        
    }
}

const updateProduct = async (req, res, next) => {
    try {
        res.json(await service.updateProduct(req))
    } catch (error) {
        next(error)        
    }
}

module.exports = {
    getProducts,
    getProductsCount,
    getProductsByPage,
    getProductsByCategoryIdAndPage,
    getProductById,
    deleteProduct,
    createProduct,
    updateProduct
}



