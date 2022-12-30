const dev = {
    DOTNET_AUTHSERVER_API_URL : "http://localhost:5253",
    DOTNET_PLANTHERE_API_URL : "http://localhost:5277",
    NODEJS_PLANTHERE_API_URL : "http://localhost:4000"
}

const prod = {
    DOTNET_AUTHSERVER_API_URL : "http://localhost:5253",
    DOTNET_PLANTHERE_API_URL : "http://localhost:5277",
    NODEJS_PLANTHERE_API_URL : "http://localhost:4000"
}

const enviroment = process.env.NODE_ENV === 'development' ? dev : prod

export default enviroment
