// React
import React, { useRef, useState } from 'react';
import { useNavigate } from "react-router-dom";

// Material IU
import Button from '@mui/material/Button';
import Avatar from '@mui/material/Avatar';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';

// Notification
import Notification from '../../services/notificationService'
import { NOTIFICATION_STATUS } from "../../models/enum/notificationStatus"

// For Request
import { METHOD_TYPE } from '../../models/enum/methodType';
import { API_TYPE } from '../../models/enum/apiType';

// Axios
import request from '../../services/requestService';

const Copyright = (props) => {
  return (
    <Typography variant="body2" color="text.secondary" align="center" {...props}>
      {'Plant© 2023'}
    </Typography>
  );
}


const SignUp = () => {

  const [user, setUser] = useState({ userName: "", email: "", password: "" });
  const navigate = useNavigate();
  const notificationRef = useRef();

  const handleSubmit = async (event) => {

    event.preventDefault();

    const response = await request('/User', user, METHOD_TYPE.POST, API_TYPE.AUTH_SERVER)

    switch (response.data.statusCode) {
      case 200 || 201 || 204:
        notificationRef.current.handleClick({ message: "The Requested Operation Was Successful.Please wait, you will be prompted to login.", status: NOTIFICATION_STATUS.SUCCESS })
        setTimeout(() => {
          navigate("/Signin");
        }, 4000);
        break;
      case 400 || 404:
        notificationRef.current.handleClick({ message: response.data.error.errors[0], status: NOTIFICATION_STATUS.WARNING })
        break;
      case 500:
        notificationRef.current.handleClick({ message: "An Unexpected Error Occurred.", status: NOTIFICATION_STATUS.ERROR })
        break;
      default:
        break;
    };

  }
  return (
    <Container component="main" maxWidth="xs">
      <Notification ref={notificationRef}></Notification>
      <Box
        sx={{
          marginTop: 8,
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
        }}
      >
        <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Sign up
        </Typography>
        <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 3 }}>
          <Grid container spacing={2}>
            <Grid item xs={12}>
              <TextField onChange={e => setUser(prev => ({ ...prev, userName: e.target.value }))}
                required
                name="name"
                fullWidth
                id="name"
                label="Name"
              />
            </Grid>
            <Grid item xs={12}>
              <TextField onChange={e => setUser(prev => ({ ...prev, email: e.target.value }))}
                required
                fullWidth
                id="email"
                label="Email Address"
                name="email"
                autoComplete="email"
              />
            </Grid>
            <Grid item xs={12}>
              <TextField onChange={e => setUser(prev => ({ ...prev, password: e.target.value }))}
                required
                fullWidth
                name="password"
                label="Password"
                type="password"
                id="password"
                autoComplete="new-password"
              />
            </Grid>
          </Grid>
          <Button type="submit" fullWidth variant="contained" sx={{ mt: 3, mb: 2 }}>
            Sign Up
          </Button>
          <Grid container justifyContent="flex-end">
            <Grid item>
              <Link href="Signin" variant="body2">
                Already have an account? Sign in
              </Link>
            </Grid>
          </Grid>
        </Box >
      </Box>
      <Copyright sx={{ mt: 5 }} />
    </Container>
  );
}


export default SignUp