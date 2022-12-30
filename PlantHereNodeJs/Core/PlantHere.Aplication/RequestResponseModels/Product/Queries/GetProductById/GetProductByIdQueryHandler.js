const ProductRepository = require('../../../../../../Infratructure/PlantHere.Persistance/Repositories/ProductRepository').ProductRepository
const GetProductsQuery = require('./GetProductsQuery').GetProductsQuery


const repository = new ProductRepository();

@QueryHandler(GetProductByIdQuery)
@Dependencies(repository)
export class GetProductByIdQueryHandler {
  constructor(repository) {
    this.repository = repository;
  }

  async execute(query) {
  }
}