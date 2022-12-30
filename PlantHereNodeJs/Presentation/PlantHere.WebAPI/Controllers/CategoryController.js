const { GetCategoriesQuery } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Queries/GetCategories/GetCategoriesQuery');
const { GetCategoryByIdQuery } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Queries/GetCategoryById/GetCategoryByIdQuery');
const { CreateCategoryCommand } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Command/CreateCategory/CreateCategoryCommand')
const { UpdateCategoryCommand } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Command/UpdateCategory/UpdateCategoryCommand')
const { DeleteCategoryCommand } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Command/DeleteCategory/DeleteCategoryCommand')

//  SERVICE
const CategoryService = require('../../../Core/PlantHere.Aplication/Services/CategoryService').CategoryService
const CategoryRepository = require('../../../Infratructure/PlantHere.Persistance/Repositories/CategoryRepository').CategoryRepository
const Guid = require('../../../Core/PlantHere.Aplication/Services/GuidService')


const categoryRepository = new CategoryRepository();
const service = new CategoryService(categoryRepository);


const getCategories = async (req, res, next) => {
    try {
        res.json(await service.getCategories(new GetCategoriesQuery))
    } catch (error) {
        next(error)        
    }
}

const getCategoryById = async (req, res, next) => {
    try {
        res.json(await service.getCategoryById(new GetCategoryByIdQuery(req.params.id)))
    } catch (error) {
        next(error)        
    }
}

const createCategory = async (req, res, next) => {
    try {
        res.status(201).json(await service.createCategory(new CreateCategoryCommand(req.body.nameEn,req.body.nameTr, Guid.createGuid())))
    } catch (error) {
        next(error)        
    }
}

const updateCategory = async (req, res, next) => {
    try {
        res.json(await service.updateCategory(new UpdateCategoryCommand(req.body.id,req.body.nameEn,req.body.nameTr)))
    } catch (error) {
        next(error)        
    }
}

const deleteCategory = async (req, res, next) => {
    try {
        res.json(await service.deleteCategory(new DeleteCategoryCommand(req.body.id)))
    } catch (error) {
        next(error)        
    }
}
module.exports = {
    getCategories,
    getCategoryById,
    createCategory,
    updateCategory,
    deleteCategory
}



