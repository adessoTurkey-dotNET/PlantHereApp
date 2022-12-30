const IProductRepository = {
    async getProducts() { },
    async getProductsByPage(getProductsByPageQuery) { },
    async getProductsByCategoryIdAndPage(getProductsByCategoryIdAndPageQuery,categoryId){},
    async getProductsById(req) { }, 
    async deleteProduct(req) { }, 
    async createProduct(req) { }, 
    async updateProduct(req) { }, 
}

module.exports = { IProductRepository }