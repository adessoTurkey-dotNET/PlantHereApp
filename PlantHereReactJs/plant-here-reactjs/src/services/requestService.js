// Axios
import axios from "axios";

// App Setting
import enviroment from '../enviroment'

// Type 
import { API_TYPE } from '../models/enum/apiType'


const selectApi = (api) => {
    switch (api) {
        case API_TYPE.AUTH_SERVER:
            return enviroment.DOTNET_AUTHSERVER_API_URL
        case API_TYPE.PLANT_HERE_DOTNET:
            return enviroment.DOTNET_PLANTHERE_API_URL
        case API_TYPE.PLANT_HERE_NODEJS:
            return enviroment.NODEJS_PLANTHERE_API_URL
        default:
            return enviroment.DOTNET_PLANTHERE_API_URL
    }
}

const prepareUrl = (url, apitype,isSelectedDotnetApi) => {

    if (apitype === API_TYPE.AUTH_SERVER) {
        console.log(`${selectApi(apitype)}${url}`,'AUTH SERVER')
        return `${selectApi(apitype)}${url}`
    
    }
    else if (isSelectedDotnetApi) {
        console.log(`${selectApi(API_TYPE.PLANT_HERE_DOTNET)}${url}`, '.NET')
        return `${selectApi(API_TYPE.PLANT_HERE_DOTNET)}${url}`
    }
    else {
        console.log(`${selectApi(API_TYPE.PLANT_HERE_NODEJS)}${url}`,'NODEJS')
        return `${selectApi(API_TYPE.PLANT_HERE_NODEJS)}${url}`
    }
}

export const request = async (url, body, method, apitype,isSelectedDotnetApi = true) => {
    try {
        if (localStorage.getItem('token') !== null) {
            const { accessToken } = JSON.parse(localStorage.getItem('token'))
            const response = await axios.request({
                method: method,
                url: prepareUrl(url, apitype,isSelectedDotnetApi),
                data: body,
                contentType: "application/json",
                headers: {
                    Authorization: "Bearer " + accessToken
                }
            });
            return response
        }
        else {
            const response = await axios.request({
                method: method,
                url: prepareUrl(url, apitype,isSelectedDotnetApi),
                data: body,
                contentType: "application/json",
            });
            return response
        }

    } catch (error) {
        const { response } = error
        return response
    }
}

export const requestAllowAnonymous = async (url, body, method, apitype,isSelectedDotnetApi = true) => {
    try {
        return await axios.request({
            method: method,
            url: prepareUrl(url, apitype,isSelectedDotnetApi),
            data: body,
            contentType: "application/json",
        });

    } catch (error) {
        const { response } = error
        return response
    }
}

export default request

