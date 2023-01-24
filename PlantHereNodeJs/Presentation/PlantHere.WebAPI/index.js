
// Express 
const express = require('express')

// Middlewares
const { CustomExceptionHandle } = require('../../Core/PlantHere.Aplication/Middlewares/CustomExceptionHandler')
const Authentication = require('../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const Authorization = require('../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')
const { CatchErrors } = require('../../Core/PlantHere.Aplication/Middlewares/CustomExceptionHandler')

// Chalk
const chalk = require('chalk')

// Router
const productRouter = require('./routers/productRouter')
const categoryRouter = require('./Routers/CategoryRouter')
const basketRouter = require('./Routers/BasketRouter')
const basketItemRouter = require('./Routers/BasketItemRouter')
const orderRouter = require('./Routers/OrderRouter')

// Connect DB
require('../../Infratructure/PlantHere.Persistance/AppDbContext')

// App
const app = express();

app.use(express.json())


// Router
app.use('/product', productRouter)
app.use('/category', categoryRouter)
app.use('/basket', basketRouter)
app.use('/basketItem', basketItemRouter)
app.use('/order', orderRouter)

//Swagger Integration
var swaggerUi = require('swagger-ui-express');
swaggerDocument = require('./swagger/swagger.json');
app.use('/swagger', swaggerUi.serve, swaggerUi.setup(swaggerDocument));

function catchAsyncErrors(middleware) {
    return async function(req, res, next) {
      try {
        await middleware(req, res, next);
      } catch(err) {
        next(err);
      }
    };
  }
// Middlewares
app.use(catchAsyncErrors)
app.use(CustomExceptionHandle)
app.use(Authentication)
app.use(Authorization)

// Listen
const config = require('./app.config')

app.listen(config.apiUrl.port, () => {
    console.log(chalk.rgb(0, 255, 0)(`------- Service Active On Port ${config.apiUrl.port} -------`))
})
