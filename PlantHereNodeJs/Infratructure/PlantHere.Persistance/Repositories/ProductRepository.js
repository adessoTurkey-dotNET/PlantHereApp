// Http Error
const CreateError = require('http-errors')

// Interface
const Interface = require("es6-interface");
const IProductRepository = require('../../../Core/PlantHere.Aplication/Interfaces/Repositories/IProductRepository').IProductRepository

// Db
const db = require('../AppDbContext')

class ProductRepository extends Interface(IProductRepository)
{
    async getProducts() {
        return await db.Products.findAll({
            attributes: ['Name', 'Description', 'Price', 'Discount', 'UniqueId']
        })
    }

    async getProductsByPage(getProductsByPageQuery) {

        const limit = getProductsByPageQuery.pageSize
        const offset = (getProductsByPageQuery.page - 1) * limit;
        const products = await db.Products.findAll(
            {
                attributes: ['Name', 'Description', 'Price', 'Discount', 'UniqueId'],
                limit,
                offset,
            }
        )
        return products
    }

    async getProductsByCategoryIdAndPage(getProductsByCategoryIdAndPageQuery, categoryId) {

        const limit = getProductsByCategoryIdAndPageQuery.pageSize
        const offset = (getProductsByCategoryIdAndPageQuery.page - 1) * limit;

        return await db.Products.findAll(
            {
                where: { CategoryId: categoryId },
                attributes: ['Name', 'UniqueId', 'Description', 'Price', 'CategoryId', 'Discount'],
                offset,
                limit,
            }
        )
    }

    async getProductsById(req) {
        const product = await db.Products.findOne(
            {
                where: { id: req.Id },
                attributes: ['Name', 'UniqueId', 'SellerId', 'Description', 'Price', 'Discount','Id'],
                include: { model: db.Categories, attributes: ['NameTr', 'NameEn'] },
            }
        )

        if (!product) {
            throw new CreateError.NotFound()
        }

        return product
    }

    async createProduct(req){
        await db.Products.create(req)
    }

    async updateProduct(req){
        const product = await this.getProductsById(req)
        product.update(req)
    }

    async deleteProduct(req){
        const product = await this.getProductsById(req)
        if(product){
            product.destroy()     
        }
    }
}

module.exports = { ProductRepository }