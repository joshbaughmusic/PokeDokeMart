import { useState } from 'react';
import { NavLink as RRNavLink } from 'react-router-dom';
import {
  Button,
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarToggler,
} from 'reactstrap';
import { logout } from '../../managers/authManager';
import "./NavBar.css"
import { Cart } from '../cart/Cart.js';
import Pokeball from '../../images/pokeball_review_icon.png';


export default function NavBar({ loggedInUser, setLoggedInUser }) {
  const [open, setOpen] = useState(false);

  const toggleNavbar = () => setOpen(!open);

  return (
    <div>
      <Navbar
        dark
        fixed="true"
        expand="lg"
        className="d-flex align-items-center nav-bar-all"
      >
        <NavbarBrand
          className="mr-auto fs-4"
          tag={RRNavLink}
          to="/"
        >
          <img
            className="pokeball-nav-icon"
            src={Pokeball}
            alt=""
          />
          PokeDokeMart
        </NavbarBrand>
        {loggedInUser ? (
          <>
            <NavbarToggler onClick={toggleNavbar} />
            <Collapse
              isOpen={open}
              navbar
            >
              <Nav
                navbar
                className="d-flex align-items-center justify-content-between w-100 text-center"
              >
                <div className="nav-left-section">
                  <NavItem>
                    <NavLink
                      tag={RRNavLink}
                      to="/items"
                    >
                      Items
                    </NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink
                      tag={RRNavLink}
                      to="/profile"
                    >
                      Profile
                    </NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink></NavLink>
                  </NavItem>
                </div>
                <div className="nav-right-section">
                  <Cart />
                  <Button
                    className="rounded-0"
                    onClick={(e) => {
                      e.preventDefault();
                      setOpen(false);
                      logout().then(() => {
                        setLoggedInUser(null);
                        setOpen(false);
                      });
                    }}
                  >
                    Logout
                  </Button>
                </div>
              </Nav>
            </Collapse>
          </>
        ) : (
          <Nav navbar>
            <NavItem>
              <NavLink
                tag={RRNavLink}
                to="/login"
              >
                <Button className="rounded-0">Login</Button>
              </NavLink>
            </NavItem>
          </Nav>
        )}
      </Navbar>
    </div>
  );
}
