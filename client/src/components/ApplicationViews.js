import { Route, Routes } from 'react-router-dom';

import { AuthorizedRoute } from './auth/AuthorizedRoute';
import Login from './auth/Login';
import Register from './auth/Register';
import { Home } from './home/Home.js';
import { AllItems } from './items/allItems/AllItems.js';
import { ItemDetails } from './items/itemDetails/ItemDetails.js';
import { Checkout } from './checkout/Checkout.js';
import { OrderDetails } from './orders/OrderDetails.js';
import { Profile } from './profile/Profile.js';
import { PokemonDetails } from './pokemon/PokemonDetails.js';

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Home loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route path="items">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <AllItems />
              </AuthorizedRoute>
            }
          />
          <Route
            path=":id"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <ItemDetails loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route
          path="checkout"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Checkout />
            </AuthorizedRoute>
          }
        />
        <Route
          path="order/:id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <OrderDetails />
            </AuthorizedRoute>
          }
        />
        <Route
          path="profile"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Profile loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="myPokemon/:id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <PokemonDetails loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route
        path="*"
        element={<p>Whoops, nothing here...</p>}
      />
    </Routes>
  );
}
