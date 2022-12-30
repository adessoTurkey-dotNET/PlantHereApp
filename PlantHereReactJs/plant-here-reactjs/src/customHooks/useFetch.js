import { useState, useEffect } from "react";

// Axios
import request from '../services/requestService';

import { METHOD_TYPE } from '../models/enum/methodType';
import { API_TYPE } from '../models/enum/apiType';

//Provider

import { useAPI } from '../providers/ApiProvider'

const useFetch = (url) => {

    const [data, setData] = useState([]);

    const { isSelectedDotnetApi } = useAPI();

    useEffect(() => {
        const fetchData = async () => {
            return await request(url, null, METHOD_TYPE.GET, API_TYPE.PLANT_HERE_DOTNET,isSelectedDotnetApi)
        }
        fetchData().then(response => {
            setData(response.data.data)
        })
    }, [url]);
    return [data];
};

export default useFetch;