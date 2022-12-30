const ProductRepository = require('../../../../../../Infratructure/PlantHere.Persistance/Repositories/ProductRepository').ProductRepository
const GetProductsQuery = require('./GetProductsQuery').GetProductsQuery


const repository = new ProductRepository();

@QueryHandler(GetProductsQuery)
@Dependencies(repository)
export class GetProductsByPaginationQueryHandler {
  constructor(repository) {
    this.repository = repository;
  }

  async execute(query) {
    console.log(query)
  }
}