// React
import React, { useEffect } from 'react';

// Metarial IU

import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import Tooltip from '@mui/material/Tooltip';
import Badge from '@mui/material/Badge';
import { Stack } from '@mui/system';
import { FormControlLabel, FormGroup, Grid } from '@mui/material';
import Link from '@mui/material/Link';
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

// Provider

import { useAuth } from '../../providers/AuthProvider'
import { useAPI } from '../../providers/ApiProvider'

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

const Search = styled('div')(({ theme }) => ({
  position: 'relative',
  borderRadius: theme.shape.borderRadius,
  backgroundColor: alpha(theme.palette.common.white, 0.15),
  '&:hover': {
    backgroundColor: alpha(theme.palette.common.white, 0.25),
  },
  marginRight: theme.spacing(2),
  marginLeft: 0,
  width: '100%',
  [theme.breakpoints.up('sm')]: {
    marginLeft: theme.spacing(3),
    width: 'auto',
  },
}));

const SearchIconWrapper = styled('div')(({ theme }) => ({
  padding: theme.spacing(0, 2),
  height: '100%',
  position: 'absolute',
  pointerEvents: 'none',
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
}));

function ToolBarButton() {
  const { setAuth, auth, basketItemsCount } = useAuth();

  useEffect(() => {
  })

  const Logout = () => {
    localStorage.clear()
    setAuth(false)
  }

  return (
    <React.Fragment>
      {auth === true ?
        <Stack direction="row" >
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
        </Stack >}
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
          {/* <Stack direction="row" alignItems="center" sx={{ m: 3 }}>
            <Typography variant="caption">Node.js</Typography>
            <Switch color="secondary" checked={isSelectedDotnetApi} onChange={handleChange} />
            <Typography variant="caption">.Net</Typography>
          </Stack> */}
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

          <Search>
            <SearchIconWrapper>
              <SearchIcon />
            </SearchIconWrapper>
            <StyledInputBase
              placeholder="Search…"
              inputProps={{ 'aria-label': 'search' }}
            />
          </Search>

          <Box sx={{ flexGrow: 0 }}>
            <ToolBarButton />
          </Box>

        </Toolbar>
      </Container>
    </AppBar >
  );
}

export default ResponsiveAppBar;