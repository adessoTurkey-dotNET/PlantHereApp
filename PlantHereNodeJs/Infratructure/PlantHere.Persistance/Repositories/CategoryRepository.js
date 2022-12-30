// Http Error
const CreateError = require('http-errors')

// Interface
const Interface = require("es6-interface");
const {ICategoryRepository}= require('../../../Core/PlantHere.Aplication/Interfaces/Repositories/ICategoryRepository')

// Db
const db = require('../AppDbContext');

class CategoryRepository extends Interface(ICategoryRepository)
{
    async getCategories() {
        return await db.Categories.findAll({
            attributes: ["NameTr", "NameEn", "Id"]
        })
    }

    async getCategoryById(id) {

        const category = await db.Categories.findOne({
            where: { Id: id },
            attributes: ["NameTr", "NameEn", "Id"]
        })

        if (!category) {
            throw new CreateError.NotFound()
        }
        
        return category
    }

    async createCategory(req){
        await db.Categories.create(req)
    }

    async updateCategory(req){
        const category = await this.getCategoryById(req.Id)
        delete req.Id
        category.update(req)
    }

    async deleteCategory(req){
        const category = await this.getCategoryById(req.Id)
        category.destroy()     
    }

}

module.exports = { CategoryRepository }


