//React
import React, { useState, useRef, useEffect } from 'react';
import { useNavigate } from "react-router-dom";

// Metarial IU
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import { DataGrid } from '@mui/x-data-grid';
import Grid from '@mui/material/Grid';
import Container from '@mui/material/Container';
import { Card, CardActions, CardContent } from '@mui/material';
import Tooltip from '@mui/material/Tooltip';
import IconButton from '@mui/material/IconButton';
import Modal from '@mui/material/Modal';
import Typography from '@mui/material/Typography';
import Stack from '@mui/material/Stack';

//Icon
import DeleteIcon from '@mui/icons-material/Delete';
import CurrencyExchangeIcon from '@mui/icons-material/CurrencyExchange';
import InfoIcon from '@mui/icons-material/Info';
import ThumbDownAltIcon from '@mui/icons-material/ThumbDownAlt';
import ThumbUpAltIcon from '@mui/icons-material/ThumbUpAlt';
import CloseIcon from '@mui/icons-material/Close';

// Axios
import request from '../../../services/requestService';

import { METHOD_TYPE } from '../../../models/enum/methodType';
import { API_TYPE } from '../../../models/enum/apiType';

// Notification

import Notification from '../../../services/notificationService'
import { NOTIFICATION_STATUS } from "../../../models/enum/notificationStatus"

// Provider
import { useAuth } from '../../../providers/AuthProvider'
import { useAPI } from '../../../providers/ApiProvider'


export default function Basket() {

    const notificationRef = useRef();
    const navigate = useNavigate();

    const [open, setOpen] = useState(false);
    const [productId, setProductId] = useState(null);
    const [basketItems, setBasketItems] = useState([{ id: 0 }])


    const { basket, basketItem } = useAuth();
    const { isSelectedDotnetApi } = useAPI();

    const handleOpen = () => setOpen(true);
    const handleClose = () => {
        setOpen(false);
        setProductId(null);
    }

    useEffect(() => {
        if (basket) {
            setBasketItems(basket.basketItems)
        }
    }, [basket])

    const columns = [
        {
            field: 'productName',
            headerName: 'Product Name',
            width: 400,
        },
        {
            field: 'price',
            headerName: 'Price $',
            width: 150,
            editable: false,
        },
        {
            field: 'discountedPrice',
            headerName: 'Discounted Price $',
            type: 'number',
            width: 150,
            editable: false,
        },
        {
            field: 'count',
            headerName: 'Count',
            type: 'number',
            description: 'This column has a value getter and is not sortable.',
            editable: true,
            width: 150,
        },
        {
            field: " ",
            width: 100,
            sortable: false,
            editable: false,
            renderCell: (cellValues) => {
                return (
                    <React.Fragment>
                        <Tooltip title="Detail">
                            <IconButton size="medium" color="primary" variant="filledTonal"
                                onClick={(event) => {
                                    handleClickDetail(event, cellValues);
                                }}>
                                <InfoIcon></InfoIcon>
                            </IconButton>
                        </Tooltip>
                        <Tooltip title="Delete">
                            <IconButton size="medium" color="error" variant="filledTonal"
                                onClick={(event) => {
                                    handleClickRemove(event, cellValues);
                                }}>
                                <DeleteIcon></DeleteIcon>
                            </IconButton>
                        </Tooltip>
                    </React.Fragment>
                );
            }
        }
    ];

    const handleClickDetail = (event, cellValues) => {
        const { row } = cellValues
        navigate(`/details/${row.productId}`)
    }

    const handleClickRemove = (event, cellValues) => {
        const { row } = cellValues
        setProductId(row.productId)
        handleOpen()
    }

    const deleteProductItem = async () => {
        try {
            const response = await request('/BasketItem', { productId }, METHOD_TYPE.DELETE, API_TYPE.PLANT_HERE_DOTNET,isSelectedDotnetApi)
            console.log(response)
            if (response.status === 204 || response.status === 200) {
                basketItem()
                notificationRef.current.handleClick({ message: "The Product Deletion Successful", status: NOTIFICATION_STATUS.SUCCESS })
            }
            else {
                notificationRef.current.handleClick({ message: response.error.errors[0], status: NOTIFICATION_STATUS.WARNING })
            }

            basketItem()
            handleClose()
        } catch (error) {
        };
    }

    const style = {
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: 400,
        boxShadow: 24,
        p: 2,
    };

    return (<React.Fragment>
        <Notification ref={notificationRef}></Notification>
        <Modal direction="row"
            open={open}
            onClose={handleClose}
            aria-labelledby="modal-modal-title"
            aria-describedby="modal-modal-description"   >
            <Card sx={style}>
                <CardActions sx={{ mt: 0, p: 0 }}>
                    <Grid maxHeight={1} item container direction="row"
                        justifyContent="right"
                        alignItems="right" >
                        <IconButton onClick={handleClose} aria-label="settings">
                            <CloseIcon />
                        </IconButton>
                    </Grid>
                </CardActions>

                <CardContent>
                    <Typography id="modal-modal-description" sx={{ mb: 2 }}>
                        Are you sure you want to delete the product ?
                    </Typography>
                </CardContent>
                <CardActions >
                    <Grid item container direction="row"
                        justifyContent="center"
                        alignItems="center" >
                        <Button sx={{ mr: 2, width: 100 }} onClick={deleteProductItem} variant="outlined" size="small" color="success" startIcon={<ThumbUpAltIcon />}> Yes</Button>
                        <Button sx={{ mr: 2, width: 100 }} onClick={handleClose} variant="outlined" size="small" color="error" startIcon={<ThumbDownAltIcon />}> No</Button>
                    </Grid>
                </CardActions>
            </Card>
        </Modal>

        <Container sx={{ mt: 12 , p: 1 }} direction="row">
            <Card>
                <CardContent>
                    <Grid>
                        <Box sx={{ height: ' calc(100vh - 20rem);', width: '100%' }}>
                            <DataGrid
                                rows={basketItems}
                                columns={columns}
                                pageSize={9}
                                rowsPerPageOptions={[basketItems.length]}
                                experimentalFeatures={{ newEditingApi: true }}
                            />
                        </Box>
                    </Grid>
                </CardContent>
                <CardContent>
                    {(basket !== null) && <Grid item sx={{ p: 1 }} container direction="row"
                        justifyContent="left"
                        alignItems="left" >
                        {basket.totalPrice !== basket.discountedTotalPrice ? <Stack>
                            <Stack direction="row" sx={{ mb: 2 }}>
                                <Typography variant="button" color="text.secondary">
                                    Total Price :&nbsp;
                                </Typography>
                                <Typography variant="button" color="red" sx={{ textDecoration: "line-through" }}>
                                    {basket.totalPrice} $
                                </Typography>
                            </Stack>
                            <Typography variant="button" color="text.secondary">
                                Total Discounted Price : {basket.discountedTotalPrice} $
                            </Typography>
                        </Stack>
                            :
                            <Typography variant="button" color="text.secondary">
                                Total Price : {basket.totalPrice} $
                            </Typography>
                        }  </Grid>}

                </CardContent>
                <CardActions>
                    <Grid item sx={{ p: 1 }} container direction="row"
                        justifyContent="right"
                        alignItems="right" >
                        {basketItems.length === 0 ?
                            <Button variant="contained" size="medium" href='BuyBasket' disabled startIcon={<CurrencyExchangeIcon />}> BUY BASKET</Button>
                            :
                            <Button variant="contained" size="medium" href='BuyBasket' startIcon={<CurrencyExchangeIcon />}> BUY BASKET</Button>}
                    </Grid>
                </CardActions>
            </Card>
        </Container>
    </React.Fragment>
    );
}