const { CustomResult } = require('../RequestResponseModels/Results/CustomResult');

const CustomExceptionHandle = (err, req, res, next) => {
    let statusCode = 400;

    if(!err)
    {
        statusCode = 500;
    }
    else if(err.name.includes('Token'))
    {
        statusCode = 401
    }
    else if (err.name == 'SequelizeDatabaseError' || err.name.includes('Validation')) {
        statusCode = 400
    }
    else if (!err.statusCode) {
        statusCode = 500
    }
   
    res.status(statusCode).json(CustomResult.Fail([err.message]))
}

module.exports = CustomExceptionHandle