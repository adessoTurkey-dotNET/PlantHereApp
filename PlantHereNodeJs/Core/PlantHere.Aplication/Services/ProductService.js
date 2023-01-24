// Interface
const Interface = require("es6-interface");
const IProductService = require('../../../Core/PlantHere.Aplication/Interfaces/Services/IProductService').IProductService

// Mapper
const { Mapper } = require('../../../Core/PlantHere.Aplication/Mapping/ProductProfile');

// Results
const CustomResult = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Results/CustomResult").CustomResult;

// RequestResponseModels

// GetProducts
const GetProductsQuery = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProducts/GetProductsQuery').GetProductsQuery
const GetProductsQueryResult = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProducts/GetProductsQueryResult').GetProductsQueryResult

// GetProductsCount
const GetProductsCountQuery = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductsCount/GetProductsCountQuery').GetProductsCountQuery
const GetProductsCountQueryResult = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductsCount/GetProductsCountQueryResult').GetProductsCountQueryResult

// GetProductsByPage
const GetProductsByPageQuery = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductsByPage/GetProductsByPageQuery').GetProductsByPageQuery
const GetProductsByPageQueryResult = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductsByPage/GetProductsByPageQueryResult').GetProductsByPageQueryResult

// GetProductsByCategoryIdAndPage
const GetProductsByCategoryIdAndPageQuery = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductByCategoryIdAndPage/GetProductByCategoryIdAndPageQuery').GetProductsByCategoryIdAndPageQuery
const GetProductsByCategoryIdAndPageQueryResult = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductByCategoryIdAndPage/GetProductByCategoryIdAndPageQueryResult').GetProductsByPageAndCategoryIdQueryResult

// GetProductById
const GetProductByIdQuery = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductById/GetProductByIdQuery').GetProductByIdQuery
const GetProductByIdQueryResult = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductById/GetProductByIdQueryResult').GetProductByIdQueryResult


// DeleteProductById
const  DeleteProductCommand  = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Commands/DeleteProduct/DeleteProductCommand').DeleteProductCommand
const  DeleteProductCommandResult  = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Commands/DeleteProduct/DeleteProductCommandResult').DeleteProductCommandResult

// UpdateProduct
const  UpdateProductCommand  = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Commands/UpdateProduct/UpdateProductCommand').UpdateProductCommand
const  UpdateProductCommandResult  = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Commands/UpdateProduct/UpdateProductCommandResult').UpdateProductCommandResult

// CreateProduct 
const  CreateProductCommand  = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Commands/CreateProduct/CreateProductCommand').CreateProductCommand
const  CreateProductCommandResult  = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Commands/CreateProduct/CreateProductCommandResult').CreateProductCommandResult;



class ProductService extends Interface(IProductService)
{
    constructor(repository) {
        super()
        this.repository = repository;
    }

    async getProducts() {
        const products = await this.repository.getProducts(new GetProductsQuery())
        return Mapper(products, GetProductsQueryResult)
    }

    async getProductsCount() {
        const count = await this.repository.getProductsCount(new GetProductsCountQuery())
        return new GetProductsCountQueryResult(count)
    }

    async getProductsByPage(req) {
        const products = await this.repository.getProductsByPage(new GetProductsByPageQuery(req.params.page, req.params.pageSize))
        return Mapper(products, GetProductsByPageQueryResult)
    }

    async getProductsByCategoryIdAndPage(req) {
        const products = await this.repository.getProductsByCategoryIdAndPage(new GetProductsByCategoryIdAndPageQuery(req.body.page, req.body.pageSize), req.params.categoryId)
        return new GetProductsByCategoryIdAndPageQueryResult(products)
    }

    async getProductsById(req) {
        const product = await this.repository.getProductsById(new GetProductByIdQuery(req.params.id))
        return Mapper(product, GetProductByIdQueryResult)
    }
    
    async deleteProduct(req) {
        return new DeleteProductCommandResult(await this.repository.deleteProduct(new DeleteProductCommand(req.params.id)))
    }
    
    async createProduct(req) {
        return new CreateProductCommandResult(await this.repository.createProduct(new CreateProductCommand(
            req.body.name,
            req.body.description,
            req.body.price,
            req.body.sellerId,
            req.body.categoryId,
            req.body.discount,
            req.body.stock)))
    }
    
    async updateProduct(req) {
        return new  UpdateProductCommandResult(await this.repository.updateProduct(new UpdateProductCommand(
            req.body.id,
            req.body.name,
            req.body.description,
            req.body.price,
            req.body.sellerId,
            req.body.categoryId,
            req.body.discount)))
    }
}

module.exports = { ProductService }