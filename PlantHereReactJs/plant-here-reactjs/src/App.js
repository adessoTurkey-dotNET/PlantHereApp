// React
import React from 'react';
import { RouterProvider } from "react-router-dom";


// Provider
import AuthProvider from './providers/AuthProvider';
import ApiProvider from './providers/ApiProvider';

// Router
import router from './router';

// Components
import NavBar from './components/navBar/navBar'

function App() {
  return (
    <ApiProvider>
      <AuthProvider>
        <NavBar />
        <RouterProvider router={router} />
      </AuthProvider>
    </ApiProvider>
  );
}

export default App;
