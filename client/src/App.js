import { useEffect, useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { tryGetLoggedInUser } from './managers/authManager';
import { Spinner } from 'reactstrap';
import NavBar from './components/navbar/NavBar';
import ApplicationViews from './components/ApplicationViews';
import { ShoppingCartProvider } from './context/ShoppingCartContext.js';

function App() {
  const [loggedInUser, setLoggedInUser] = useState();

  useEffect(() => {
    // user will be null if not authenticated
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  // wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return <Spinner />;
  }

  return (
    <>
      <ShoppingCartProvider>
        <NavBar
          loggedInUser={loggedInUser}
          setLoggedInUser={setLoggedInUser}
        />
        <ApplicationViews
          loggedInUser={loggedInUser}
          setLoggedInUser={setLoggedInUser}
        />
      </ShoppingCartProvider>
    </>
  );
}

export default App;
