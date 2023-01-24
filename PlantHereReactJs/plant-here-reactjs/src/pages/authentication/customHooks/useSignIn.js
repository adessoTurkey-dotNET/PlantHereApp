//React
import { useState} from "react";
import { useNavigate } from "react-router-dom";

// Redux
import { useDispatch } from 'react-redux';

// Redux Action
import { SetAuthStore, SetUserStore } from '../../../redux/actions/userActions'
import { FetchBasket } from '../../../redux/actions/basketActions';

// Axios Instance
import { useAxiosPrivateAuthServerWithNotification } from '../../../hooks/useAxiosPrivateAuthServer';
import { useAxiosPrivateDotNet } from '../../../hooks/useAxiosPrivatePlantHere';

// Local Storage Service
import { setToken } from '../../../services/localStorageService';

const useForm = (initialState = {}, notificationRef) => {
    
    // State
    const [user, setUser] = useState(initialState);
    
    //Axios Instance
    const axiosPrivateDotNet = useAxiosPrivateDotNet()
    const axiosPrivateAuthServer = useAxiosPrivateAuthServerWithNotification(notificationRef)

    // Hooks
    const dispatch = useDispatch();
    const navigate = useNavigate();

    // handle
    const handleInputChange = (e) => {
        setUser({ ...user, [e.target.name]: e.target.value })
    }

    const handleSubmit = async (e) => {

        e.preventDefault();
        
        // Request 
        const data = await axiosPrivateAuthServer.post('/Auth/CreateTokenByUser', user)

        // Set Token Local Storage 
        setToken(data)

        // Dispatch Auth
        dispatch(SetAuthStore(true))

        // Dispatch User
        dispatch(SetUserStore())

        // Navigate
        setTimeout(() => {
            // Dispatch Basket
            dispatch(FetchBasket(axiosPrivateDotNet))
            navigate("/");
        }, 1000);

    }
    
    return { handleInputChange, handleSubmit };
}


export default useForm