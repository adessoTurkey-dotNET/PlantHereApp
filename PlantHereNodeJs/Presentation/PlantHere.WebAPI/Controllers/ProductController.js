//  SERVICE
const ProductService = require('../../../Core/PlantHere.Aplication/Services/ProductService').ProductService
const ProductRepository = require('../../../Infratructure/PlantHere.Persistance/Repositories/ProductRepository').ProductRepository

const productRepository = new ProductRepository();
const service = new ProductService(productRepository);

//Results
const {CustomResult} = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Results/CustomResult')


const getProducts = async (req, res) => {
    res.json(CustomResult.Success(await service.getProducts()))
}

const getProductsCount = async (req, res) => {
    res.json(CustomResult.Success(await service.getProductsCount()))
}

const getProductsByPage = async (req, res) => {
    res.json(CustomResult.Success(await service.getProductsByPage(req)))
}

const getProductsByCategoryIdAndPage = async (req, res) => {
    res.json(CustomResult.Success(await service.getProductsByCategoryIdAndPage(req)))
}

const getProductById = async (req, res) => {
    res.json(CustomResult.Success(await service.getProductsById(req)))
}


const deleteProduct = async (req, res) => {
    res.json(CustomResult.Success(await service.deleteProduct(req)))
}

const createProduct = async (req, res) => {
    res.json(CustomResult.Success(await service.createProduct(req)))
}

const updateProduct = async (req, res) => {
    res.json(CustomResult.Success(await service.updateProduct(req)))
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



