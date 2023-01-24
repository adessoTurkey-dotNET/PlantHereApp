// React
import React, { useEffect, useRef, useState } from 'react';
import { useNavigate } from "react-router-dom";

// Redux
import { useDispatch, useSelector } from 'react-redux';

// Redux Action
import { SetAuthStore, SetUserStore } from '../../redux/actions/userActions'
import { FetchBasket } from '../../redux/actions/basketActions';

// Axios Instance
import { useAxiosPrivateAuthServerWithNotification } from '../../hooks/useAxiosPrivateAuthServer';
import { GetSelectedAxios } from '../../hooks/useAxiosPrivatePlantHere';

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

//Copyright
import Copyright from './copyright';

// Notification
import Notification from '../../services/notificationService'

// Local Storage Service
import { setToken } from '../../services/localStorageService';

// Hooks

import useForm from './customHooks/useSignIn';

export default function SignInSide() {

    const notificationRef = useRef();

    const { handleInputChange, handleSubmit } = useForm({ email:"",password :""}

        password: "",
    }
        ,
        notificationRef
    );


    return (
        <Grid container component="main" sx={{ mt: 10, height: '100vh' }}>
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
                    }} >
                    <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        Sign in
                    </Typography>
                    <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 1 }}>
                        <TextField onChange={handleInputChange}
                            margin="normal"
                            required
                            fullWidth
                            id="email"
                            label="Email Address"
                            name="email"
                            autoComplete="email"
                            autoFocus
                        />
                        <TextField onChange={handleInputChange}
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