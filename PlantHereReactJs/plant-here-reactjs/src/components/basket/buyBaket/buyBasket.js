//React 
import React, { useState, useRef } from 'react';

// Metarial UI
import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import Paper from '@mui/material/Paper';
import Stepper from '@mui/material/Stepper';
import Step from '@mui/material/Step';
import StepLabel from '@mui/material/StepLabel';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Tooltip from '@mui/material/Tooltip';
import Badge from '@mui/material/Badge';
import IconButton from '@mui/material/IconButton';
import StoreIcon from '@mui/icons-material/Store';
import { styled } from '@mui/material/styles';
import { Stack } from '@mui/system';
import { Grid } from '@mui/material';

// Child Component
import AddressForm from './addressForm';
import PaymentForm from './paymentForm';
import Review from './review';

// Notification
import Notification from '../../../services/notificationService'
import { NOTIFICATION_STATUS } from "../../../models/enum/notificationStatus"

// For Request
import { METHOD_TYPE } from '../../../models/enum/methodType';
import { API_TYPE } from '../../../models/enum/apiType';

// Axios
import request from '../../../services/requestService';

// Provider 
import { useAPI } from '../../../providers/ApiProvider'

const StyledBadge = styled(Badge)(({ theme }) => ({
    '& .MuiBadge-badge': {
        right: -3,
        top: 13,
        border: `2px solid ${theme.palette.background.paper}`,
        padding: '0 4px',
    },
}));

const steps = ['Shipping address', 'Payment details', 'Review your order'];

export default function BuyBasket() {
    const [activeStep, setActiveStep] = useState(0);
    const [valueAddressChild, setvalueAddressChild] = useState({});
    const [valuePaymentChild, setvaluePaymentChild] = useState({});

    const { isSelectedDotnetApi } = useAPI();
    const notificationRef = useRef();

    const buyBasket = async () => {
        const body = {
            address: valueAddressChild,
            payment: valuePaymentChild,
        }
        const response = await request('/Basket/BuyBasket', body, METHOD_TYPE.POST, API_TYPE.PLANT_HERE_DOTNET,isSelectedDotnetApi)

        if (response.status === 200 || response.status === 204) {
            notificationRef.current.handleClick({ message: "The Requested Operation Was Successful.Please wait, you will be prompted to login.", status: NOTIFICATION_STATUS.SUCCESS })
            return true
        }
        else if (response.status === 400 || response.status === 404) {
            notificationRef.current.handleClick({ message: "Bad Request", status: NOTIFICATION_STATUS.WARNING })
            return false
        }
        else {
            notificationRef.current.handleClick({ message: "An unexpected error occurred", status: NOTIFICATION_STATUS.WARNING })
            return false
        }
    };


    function getStepContent(step) {
        switch (step) {
            case 0:
                return <Grid>
                    <AddressForm setvalueAddressChild={setvalueAddressChild} />
                </Grid>
            case 1:
                return <Grid>
                    <PaymentForm setvaluePaymentChild={setvaluePaymentChild} />
                </Grid>
            case 2:
                return <Review address={valueAddressChild} payment={valuePaymentChild} />;
            default:
                throw new Error('Unknown step');
        }
    }

    const handleNext = () => {
        switch (activeStep) {
            case 0:
                if (valueAddressChild === {} ||
                    valueAddressChild.province === undefined ||
                    valueAddressChild.district === undefined ||
                    valueAddressChild.street === undefined ||
                    valueAddressChild.line === undefined) {
                    notificationRef.current.handleClick({ message: "Please check the shipping address form.", status: NOTIFICATION_STATUS.WARNING })
                }
                else {
                    setActiveStep(activeStep + 1);
                }
                break;
            case 1:
                if (valuePaymentChild === {} ||
                    valuePaymentChild.cardTypeId === undefined ||
                    valuePaymentChild.cardNumber === undefined ||
                    valuePaymentChild.cardSecurityNumber === undefined ||
                    valuePaymentChild.cardHolderName === undefined) {
                    notificationRef.current.handleClick({ message: "Please check the shipping payment method form.", status: NOTIFICATION_STATUS.WARNING })
                }
                else {
                    setActiveStep(activeStep + 1);
                }
                break;
            case 2:
                buyBasket().then(result => {
                    if (result === true) {
                        setActiveStep(activeStep + 1);
                    }
                })
                break;
            default:
                break;
        }
    };

    const handleBack = () => {
        setvalueAddressChild({})
        setvaluePaymentChild({})
        setActiveStep(activeStep - 1);
    };


    return (
        <Container component="main" maxWidth="sm" sx={{ mt: 12 }}>
            <Notification ref={notificationRef}></Notification>
            <Paper variant="outlined" sx={{ my: { xs: 3, md: 6 }, p: { xs: 2, md: 3 } }}>
                <Typography component="h1" variant="h4" align="center">
                    Buy Basket
                </Typography>
                <Stepper activeStep={activeStep} sx={{ pt: 3, pb: 5 }}>
                    {steps.map((label) => (
                        <Step key={label}>
                            <StepLabel>{label}</StepLabel>
                        </Step>
                    ))}
                </Stepper>
                {activeStep === steps.length ? (
                    <React.Fragment>
                        <Typography variant="h5" gutterBottom>
                            Thank you for your order.
                        </Typography>
                        <Stack direction="row" >
                            <Typography variant="subtitle1">
                                You can track your order with the order button.
                            </Typography>
                            <Tooltip title="Order" sx={{ ml: 1, p: 0 }}>
                                <IconButton href='\Order'>
                                    <StyledBadge color="secondary">
                                        <StoreIcon></StoreIcon>
                                    </StyledBadge>
                                </IconButton>
                            </Tooltip>
                        </Stack>
                    </React.Fragment>
                ) : (
                    <React.Fragment>
                        {getStepContent(activeStep)}
                        <Box sx={{ display: 'flex', justifyContent: 'flex-end' }}>
                            {activeStep !== 0 && (
                                <Button onClick={handleBack} sx={{ mt: 3, ml: 1 }}>
                                    Back
                                </Button>
                            )}

                            <Button
                                variant="contained"
                                onClick={handleNext}
                                sx={{ mt: 3, ml: 1 }}
                            >
                                {activeStep === steps.length - 1 ? 'Place order' : 'Next'}
                            </Button>
                        </Box>
                    </React.Fragment>
                )}
            </Paper>
        </Container >
    );
}