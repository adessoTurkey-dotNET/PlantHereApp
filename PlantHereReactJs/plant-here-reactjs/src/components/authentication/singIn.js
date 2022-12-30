// React
import React, { useRef, useState } from 'react';
import { useNavigate } from "react-router-dom";

//Metarial UI

import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';

// Notification
import { NOTIFICATION_STATUS } from "../../models/enum/notificationStatus"
import Notification from '../../services/notificationService'

// For Request
import { METHOD_TYPE } from '../../models/enum/methodType';
import { API_TYPE } from '../../models/enum/apiType';

// Axios
import request from '../../services/requestService';


function Copyright(props) {
    return (
        <Typography variant="body2" color="text.secondary" align="center" {...props}>
            {'Plant© 2023'}
        </Typography>
    );
}

export default function SignInSide() {

    const [user, setUser] = useState({ email: "", password: "" })
    const notificationRef = useRef();
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();
        const response = await request('/Auth/CreateTokenByUser', user, METHOD_TYPE.POST, API_TYPE.AUTH_SERVER)
        switch (response.data.statusCode) {
            case 200:
                notificationRef.current.handleClick({ message: "Login Successful", status: NOTIFICATION_STATUS.SUCCESS })
                localStorage.setItem("token", JSON.stringify(response.data.data))
                setTimeout(() => {
                    navigate("/");
                    window.location.reload(false);
                }, 1500);
                break;
            case 400:
                notificationRef.current.handleClick({ message: response.data.error.errors[0], status: NOTIFICATION_STATUS.WARNING })
                break;
            case 404:
                notificationRef.current.handleClick({ message: response.data.error.errors[0], status: NOTIFICATION_STATUS.WARNING })
                break;
            case 500:
                notificationRef.current.handleClick({ message: "An Unexpected Error Occurred.", status: NOTIFICATION_STATUS.ERROR })
                break;
            default:
                break;
        };
    };

    return (
        <Grid container component="main" sx={{ height: '100vh' }}>
            <Notification ref={notificationRef}></Notification>
            <CssBaseline />
            <Grid
                item
                xs={false}
                sm={4}
                md={7}
                sx={{
                    backgroundImage: 'url(https://d2r55xnwy6nx47.cloudfront.net/uploads/2020/07/Photosynthesis_2880_Lede.jpg)',
                    backgroundRepeat: 'no-repeat',
                    backgroundColor: (t) =>
                        t.palette.mode === 'light' ? t.palette.grey[50] : t.palette.grey[900],
                    backgroundSize: 'cover',
                    backgroundPosition: 'center',
                }}
            />
            <Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
                <Box
                    sx={{
                        my: 8,
                        mx: 4,
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                    }}
                >
                    <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        Sign in
                    </Typography>
                    <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 1 }}>
                        <TextField onChange={e => setUser(prev => ({ ...prev, email: e.target.value }))}
                            margin="normal"
                            required
                            fullWidth
                            id="email"
                            label="Email Address"
                            name="email"
                            autoComplete="email"
                            autoFocus
                        />
                        <TextField onChange={e => setUser(prev => ({ ...prev, password: e.target.value }))}
                            margin="normal"
                            required
                            fullWidth
                            name="password"
                            label="Password"
                            type="password"
                            id="password"
                            autoComplete="current-password"
                        />
                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ mt: 3, mb: 2 }}
                        >
                            Sign In
                        </Button>
                        <Grid container>
                            <Grid item>
                                <Link href="Signup" variant="body2">
                                    {"Don't have an account? Sign Up"}
                                </Link>
                            </Grid>
                        </Grid>
                        <Copyright sx={{ mt: 5 }} />
                    </Box>
                </Box>
            </Grid>
        </Grid>
    );
}