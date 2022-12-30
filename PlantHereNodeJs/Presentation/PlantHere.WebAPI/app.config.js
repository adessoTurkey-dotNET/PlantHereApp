const config = {
    app:{
      name:"PlantHere"  
    },
    connection: {
        client:"mssql",
        server:"localhost",
        user:"sa",
        password:"123",
        database:"PlantHereDb"
    },
    apiUrl:{
      baseUrl:"http://localhost:4000/",
      port:4000
    }
    ,
    tokenOption:{
      securityKey :"marvindennisgames2022*"
    }
}


module.exports = (config)