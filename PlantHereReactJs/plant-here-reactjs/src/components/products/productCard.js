//React 
import React, { useRef } from 'react';
import { useNavigate } from "react-router-dom";

// Metarial IU

import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Link from '@mui/material/Link'

// Icon

import LocalGroceryStoreIcon from '@mui/icons-material/LocalGroceryStore';
import AddIcon from '@mui/icons-material/Add';

// Notification
import Notification from '../../services/notificationService'
import { NOTIFICATION_STATUS } from "../../models/enum/notificationStatus"

// For Request
import { METHOD_TYPE } from '../../models/enum/methodType';
import { API_TYPE } from '../../models/enum/apiType';

// Axios
import request from '../../services/requestService';

// Provider
import { useAuth } from '../../providers/AuthProvider'
import { useAPI } from '../../providers/ApiProvider'

export default function ProductCard(props) {

  //Hooks
  const navigate = useNavigate();
  const notificationRef = useRef();
  const { auth, basketItem } = useAuth();
  const { isSelectedDotnetApi } = useAPI();

  //#region Button Event
  const addBasket = async () => {
    if (!auth) {
      navigate('/SignIn')
    }

    const body = {
      productId: props.uniqueId,
      productName: `${props.name}(${props.description})`,
      price: props.price,
      discountedPrice: props.discountedPrice
    }

    const response = await request('/BasketItem', body, METHOD_TYPE.POST, API_TYPE.PLANT_HERE_DOTNET, isSelectedDotnetApi)
    if (response.status === 204 || response.status === 200 || response.status === 201) {
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

  //#endregion

  return (
    <React.Fragment>  <Notification ref={notificationRef}></Notification>
      <Card sx={{ maxWidth: 400, margin: 1 }} >
        <CardMedia
          component="img"
          alt={props.name}
          height="190"
          image={props.image}
        />
        <CardContent sx={{ width: 300, height: 120 }}>
          <Typography gutterBottom variant="h5" component="div">
            {props.name}
          </Typography>
          <Typography mb={2} variant="body2" color="text.secondary">
            {props.description}
          </Typography>

          {props.price !== props.discountedPrice ? <React.Fragment>
            <Typography variant="body2" color="red" sx={{ textDecoration: "line-through" }}>
              {props.price} $
            </Typography>
            <Typography variant="body2" color="text.secondary">
              {props.discountedPrice} $
            </Typography>
          </React.Fragment>
            :
            <Typography variant="body2" color="text.secondary">
              {props.price} $
            </Typography>
          }

        </CardContent>
        <CardActions  >
          <Button size="small" onClick={addBasket} ><AddIcon fontSize="small"></AddIcon> Add To Basket</Button>
          <Button size="small" onClick={gotoBasket} ><LocalGroceryStoreIcon fontSize="small"></LocalGroceryStoreIcon>Basket</Button>
          <Link sx={{ ml: 5 }} target="_blank" href={`/details/${props.uniqueId}`} rel="noopener"><Button size="small">Detail</Button></Link>
        </CardActions>
      </Card>
    </React.Fragment>
  );
}