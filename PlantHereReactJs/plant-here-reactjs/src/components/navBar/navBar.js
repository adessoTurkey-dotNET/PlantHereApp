// React
import React, { useEffect, useState } from 'react';

// Metarial IU

import TextField from '@mui/material/TextField';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import Tooltip from '@mui/material/Tooltip';
import { Card, CardActions, CardContent } from '@mui/material';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from '@mui/material'
import Badge from '@mui/material/Badge';
import Link from '@mui/material/Link';
import Modal from '@mui/material/Modal';
import Grid from '@mui/material/Grid';
import Divider from '@mui/material/Divider';
import { Stack } from '@mui/system';
import { styled, alpha } from '@mui/material/styles';
import InputBase from '@mui/material/InputBase';
import ForestRoundedIcon from '@mui/icons-material/ForestRounded';
import Switch from '@mui/material/Switch';

// Icon 

import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import MeetingRoomIcon from '@mui/icons-material/MeetingRoom';
import NoMeetingRoomIcon from '@mui/icons-material/NoMeetingRoom';
import StoreIcon from '@mui/icons-material/Store';
import SearchIcon from '@mui/icons-material/Search';
import CloseIcon from '@mui/icons-material/Close';
import InfoIcon from '@mui/icons-material/Info';

// Provider

import { useAuth } from '../../providers/AuthProvider'
import { useAPI } from '../../providers/ApiProvider'

//Custom Hooks
import useFetch from '../../customHooks/useFetch';

const styleModel = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 700,
  boxShadow: 24,
  p: 2,
};


const StyledBadge = styled(Badge)(({ theme }) => ({
  '& .MuiBadge-badge': {
    right: -3,
    top: 13,
    border: `2px solid ${theme.palette.background.paper}`,
    padding: '0 4px',
  },
}));

const StyledInputBase = styled(InputBase)(({ theme }) => ({
  color: 'inherit',
  '& .MuiInputBase-input': {
    padding: theme.spacing(1, 1, 1, 0),
    // vertical padding + font size from searchIcon
    paddingLeft: `calc(1em + ${theme.spacing(4)})`,
    transition: theme.transitions.create('width'),
    width: '100%',
    [theme.breakpoints.up('sm')]: {
      width: '12ch',
      '&:focus': {
        width: '20ch',
      },
    },
  },
}));



function ToolBarButton() {
  const [open, setOpen] = useState(false);
  const [keyword,setKeyword] = useState();
  const [products] = useFetch( `/Product/GetProductES/${keyword}`)

  const { setAuth, auth, basketItemsCount } = useAuth();

  useEffect(() => {

  })

  const handleOpen = () => setOpen(true);
  const handleClose = () => {
    setOpen(false);
  }

  const Logout = () => {
    localStorage.clear()
    setAuth(false)
  }

  const handleChange = (event) => {
    if(event.target.value!== "")
    {
      setKeyword(event.target.value);
    }
    else
    {
      setKeyword(null)
    }

  };

  const BasicTable = () => {
    return (
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Unique Id</TableCell>
              <TableCell>Name</TableCell>
              <TableCell>Description</TableCell>
              <TableCell>Info</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {products.map((row) => (
              <TableRow
                key={row.name}
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {row.uniqueId}
                </TableCell>
                <TableCell >{row.name}</TableCell>
                <TableCell >{row.description}</TableCell>
                <TableCell align="left">
                  <Tooltip title="Detail">
                    <Link sx={{ ml: 5 }} target="_blank" href={`/details/${row.uniqueId}`} rel="noopener">
                      <IconButton size="medium" color="primary" variant="filledTonal" >
                        <InfoIcon></InfoIcon>
                      </IconButton>
                    </Link>
                  </Tooltip>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    );
  }

  return (
    <React.Fragment>

      <Modal direction="row"
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"   >
        <Card sx={styleModel}>
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
            <Grid container
              justifyContent="center"
              alignItems="center" >
              <SearchIcon sx={{ p: 2, mt: 2.2, }}></SearchIcon>
              <TextField
                id="search"
                label="Search..."
                type="search"
                variant="standard"
                onChange={handleChange}
              />
            </Grid>
          </CardContent>
          <Divider />
          <CardContent>
            <Grid>
              <BasicTable></BasicTable>
            </Grid>
          </CardContent>
          <Divider />
        </Card>
      </Modal>

      {auth === true ?
        <Stack direction="row" >
          <Tooltip title="Search">
            <IconButton
              onClick={
                handleOpen
              }>
              <SearchIcon></SearchIcon>
            </IconButton>
          </Tooltip>
          <Tooltip title="Basket">
            <IconButton aria-label="cart" href="\Basket">
              <StyledBadge badgeContent={basketItemsCount} color="secondary">
                <ShoppingCartIcon />
              </StyledBadge>
            </IconButton>
          </Tooltip>
          <Tooltip title="Order">
            <IconButton href='\Order'>
              <StyledBadge color="secondary">
                <StoreIcon></StoreIcon>
              </StyledBadge>
            </IconButton>
          </Tooltip>
          <Tooltip title="Logout">
            <Link href="\SignIn" key="SignIn" sx={{ textDecoration: 'none' }}>
              <IconButton onClick={Logout} >
                <StyledBadge color="secondary">
                  <NoMeetingRoomIcon></NoMeetingRoomIcon>
                </StyledBadge>
              </IconButton>
            </Link>
          </Tooltip>
        </Stack > :
        <Stack direction="row" >
          <Tooltip title="Login">
            <Link href="\SignIn" key="SignIn" sx={{ textDecoration: 'none' }}>
              <IconButton  >
                <StyledBadge color="secondary">
                  <MeetingRoomIcon></MeetingRoomIcon>
                </StyledBadge>
              </IconButton>
            </Link>
          </Tooltip>
          <Tooltip title="Login">
            <Link href="\SignIn" key="SignIn" sx={{ textDecoration: 'none' }}>
              <IconButton  >
                <StyledBadge color="secondary">
                  <MeetingRoomIcon></MeetingRoomIcon>
                </StyledBadge>
              </IconButton>
            </Link>
          </Tooltip>
        </Stack >
      }
    </React.Fragment>
  )
}

function ResponsiveAppBar() {

  const { isSelectedDotnetApi, SetIsSelectedDotnetApi } = useAPI();

  const handleChange = (event) => {
    SetIsSelectedDotnetApi(!isSelectedDotnetApi)
  };

  return (
    <AppBar fixed='top'>
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <Stack direction="row" alignItems="center" sx={{ m: 3 }}>
            <Typography variant="caption">Node.js</Typography>
            <Switch color="secondary" checked={isSelectedDotnetApi} onChange={handleChange} />
            <Typography variant="caption">.Net</Typography>
          </Stack>
          <ForestRoundedIcon sx={{ display: { xs: 'none', md: 'flex' }, mr: 1 }} />
          <Typography
            href="/"
            component={Link}
            to="/"
            variant="h6"
            noWrap
            sx={{
              mr: 2,
              display: { xs: 'none', md: 'flex' },
              fontFamily: 'monospace',
              fontWeight: 800,
              letterSpacing: '.2rem',
              color: 'inherit',
              textDecoration: 'none',
            }}
          >
            Plant Here
          </Typography>
          <Typography
            variant="h5"
            noWrap
            component="a"
            href="/"
            sx={{
              mr: 2,
              display: { xs: 'flex', md: 'none' },
              flexGrow: 1,
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none',
            }}
          >
            Plant Here
          </Typography>

          <Typography
            variant="h6"
            noWrap
            component="div"
            sx={{ flexGrow: 1, display: { xs: 'none', sm: 'block' } }}
          >
          </Typography>


          <Box sx={{ flexGrow: 0 }}>
            <ToolBarButton />
          </Box>

        </Toolbar>
      </Container>
    </AppBar >
  );
}

export default ResponsiveAppBar;