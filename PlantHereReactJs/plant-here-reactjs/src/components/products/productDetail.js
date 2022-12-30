// React 
import React, { useEffect, useState, useRef } from 'react';
import { useParams, useNavigate } from 'react-router';

//Merarial IU
import Grid from '@mui/material/Grid';
import ImageList from '@mui/material/ImageList';
import ImageListItem from '@mui/material/ImageListItem';
import Container from '@mui/material/Container';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Card from '@mui/material/Card';

//Icon
import LocalGroceryStoreIcon from '@mui/icons-material/LocalGroceryStore';
import AddIcon from '@mui/icons-material/Add';

// Request 
import request, { requestAllowAnonymous } from "../../services/requestService";
import { METHOD_TYPE } from "../../models/enum/methodType";
import { API_TYPE } from "../../models/enum/apiType";

// Notification
import Notification from '../../services/notificationService'
import { NOTIFICATION_STATUS } from "../../models/enum/notificationStatus"

// Auth
import { useAuth } from '../../providers/AuthProvider'
import { useAPI } from '../../providers/ApiProvider'

const ProductDetail = () => {
    const params = useParams();
    const [product, setProduct] = useState({
        images: []
    })

    const notificationRef = useRef();
    const { auth, basketItem } = useAuth();
    const { isSelectedDotnetApi } = useAPI();
    const navigate = useNavigate();


    useEffect(() => {
        const fetchDataProduct = async () => {
            const response = await requestAllowAnonymous(`/Product/${params.id}`, null, METHOD_TYPE.GET, API_TYPE.PLANT_HERE_DOTNET,isSelectedDotnetApi)
            return response.data.data
        }
        fetchDataProduct().then(data => {
            setProduct(data)
        }).catch(console.error)
    }, [])

    const addBasket = async () => {
        if (!auth) {
            navigate('/SignIn')
        }
        const body = {
            productId: product.uniqueId,
            productName: `${product.name}(${product.description})`,
            price: product.price,
            discountedPrice: product.discountedPrice
        }
        const response = await request('/BasketItem', body, METHOD_TYPE.POST, API_TYPE.PLANT_HERE_DOTNET,isSelectedDotnetApi)

        if (response.status === 204  || response.status === 200) {
            basketItem()
            notificationRef.current.handleClick({ message: "The Product Has Been Successfully Added", status: NOTIFICATION_STATUS.SUCCESS })
        }
        else {
            notificationRef.current.handleClick({ message: response.error.errors[0], status: NOTIFICATION_STATUS.WARNING })
        }
    }

    const gotoBasket = () => {
        if (!auth) {
            navigate('/SignIn')
        }
        else {
            navigate('/Basket')
        }
    }

    return (
        <Container fixed  sx={{ mt: 10}} >
            <Notification ref={notificationRef}></Notification>
            <Grid  >
                <Card  >
                    <CardContent >
                        <ImageList sx={{ height: 300 }} cols={4} >
                            {product.images.map((item) => (
                                <ImageListItem key={item.url}>
                                    <img
                                        src={`${item.url}?w=250&h=250&fit=crop&auto=format`}
                                        srcSet={`${item.url}?w=250&h=250&fit=crop&auto=format&dpr=2 2x`}
                                        loading="lazy"
                                    />
                                </ImageListItem>
                            ))}
                        </ImageList>
                    </CardContent>
                </Card>
            </Grid>

            <Grid item sx={{ mt: 2 }} >
                <Card>
                    <CardContent>
                        <Typography sx={{ fontSize: 25 }} color="text.secondary" gutterBottom>
                            {product.name}
                        </Typography>
                        <Typography variant="h5" component="div">
                        </Typography>
                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                            {product.description}
                        </Typography>
                        <Typography variant="body2">
                            {product.care}
                        </Typography>
                        {product.price !== product.discountedPrice ? <React.Fragment >
                            <Typography  variant="body2" color="red" sx={{ textDecoration: "line-through" , mt:2}}>
                                {product.price} $
                            </Typography>
                            <Typography variant="body2" color="text.secondary" sx={{ mt :2}} >
                                {product.discountedPrice} $
                            </Typography>
                        </React.Fragment>
                            :
                            <Typography variant="body2" color="text.secondary" sx={{ mt :2}}>
                                {product.price} $
                            </Typography>
                        }

                    </CardContent>
                    <CardActions>
                        <Button size="small" onClick={addBasket} ><AddIcon fontSize="small"></AddIcon> Add To Basket</Button>
                        <Button size="small" onClick={gotoBasket}><LocalGroceryStoreIcon fontSize="small" ></LocalGroceryStoreIcon> BASKET</Button>
                    </CardActions>
                </Card>
            </Grid>
        </Container>
    )
}

export default ProductDetail;