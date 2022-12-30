import { createContext, useContext, useEffect, useState } from 'react';

const APIContext = createContext({
    isSelectedDotnetApi: true,
    SetIsSelectedDotnetApi :() => { }
});

export const useAPI = () => useContext(APIContext);

const ApiProvider = ({ children }) => {

    const [isSelectedDotnetApi, SetIsSelectedDotnetApi] = useState(true);
    useEffect(() => {

    },[])
    
    return (
        <APIContext.Provider value={{ isSelectedDotnetApi, SetIsSelectedDotnetApi }}>
            {children}
        </APIContext.Provider>
    );
};

export default ApiProvider;