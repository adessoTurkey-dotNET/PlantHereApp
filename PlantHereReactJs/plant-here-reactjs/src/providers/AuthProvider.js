import { createContext, useContext, useEffect, useState } from 'react';

// For Request

import request from '../services/requestService';

import { METHOD_TYPE } from '../models/enum/methodType';
import { API_TYPE } from '../models/enum/apiType';

import { useAPI } from '../providers/ApiProvider'

const AuthContext = createContext({
    auth: null,
    setAuth: () => { },
    user: null,
    basket: null,
});

export const useAuth = () => useContext(AuthContext);

const AuthProvider = ({ children }) => {

    const [auth, setAuth] = useState(false);
    const [user, setUser] = useState(null);
    const [basket, setBasket] = useState(null);
    const [basketItemsCount, setBasketItemCount] = useState(0);
    
    const { isSelectedDotnetApi } = useAPI();

    const basketItem = async () => {
        try {
            const response = await request('/basket', null, METHOD_TYPE.GET, API_TYPE.PLANT_HERE_DOTNET,isSelectedDotnetApi)
            setBasket(response.data.data);
            setBasketItemCount(response.data.data.basketItems.reduce((acc, o) => acc + o.count, 0))
        } catch (error) {
            setBasket(null);
            setBasketItemCount(0)
        };
    }

    useEffect(() => {
        const isAuth = async () => {
            try {
                if (localStorage.getItem('token')) {
                    const response = await request('/user', null, METHOD_TYPE.GET, API_TYPE.AUTH_SERVER)
                    if (response.data) {
                        setUser(response.data);
                        setAuth(true)
                        basketItem();
                    }
                }
            } catch (error) {
                setUser(null);
                setAuth(false)
            };
        };

        isAuth();
    }, []);

    return (
        <AuthContext.Provider value={{ auth, setAuth, user, basket, basketItemsCount, basketItem }}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthProvider;