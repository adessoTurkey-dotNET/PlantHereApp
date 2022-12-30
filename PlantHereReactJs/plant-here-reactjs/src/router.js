// React
import {createBrowserRouter} from "react-router-dom";

// Componnet

import SignIn from './components/authentication/singIn'
import SignUp from './components/authentication/singUp'

import Products from './components/products/products'
import ProductDetail from './components/products/productDetail'

import Basket from './components/basket/basket/basket'
import BuyBasket from "./components/basket/buyBaket/buyBasket";

import Order from './components/order/order'

import NotFoundPage from './components/errorPage/notFoundPage';


const router = createBrowserRouter([
    {
        path: "/",
        element: <Products  />,
    },
    {
        path: "/details/:id",
        element: <ProductDetail/>,
    },
    {
        path: "/SignIn",
        element: <SignIn />,
    },
    {
        path: "/SignUp",
        element: <SignUp />,
    },
    {
        path: "/Basket",
        element: <Basket />,
    },
    {
        path: "/BuyBasket",
        element: <BuyBasket />,
    },
    {
        path: "/Order",
        element: <Order />,
    },
    {
        path: "*",
        element: <NotFoundPage />,
    } 
]);

export default router