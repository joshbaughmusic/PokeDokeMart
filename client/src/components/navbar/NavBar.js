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
import PDMNav from '../../images/PDMNav.png';


export default function NavBar({ loggedInUser, setLoggedInUser }) {
  const [open, setOpen] = useState(false);

  const toggleNavbar = () => setOpen(!open);

  return (
    <div>
      <Navbar
        color="dark"
        dark
        fixed="true"
        expand="lg"
      >
        <NavbarBrand
          className="mr-auto"
          tag={RRNavLink}
          to="/"
        >
          <img
            className="w-50 m-2"
            src={PDMNav}
            alt=""
          />
        </NavbarBrand>
        {loggedInUser ? (
          <>
            <NavbarToggler onClick={toggleNavbar} />
            <Collapse
              isOpen={open}
              navbar
            >
              <Nav navbar>
                <NavItem>
                  <NavLink
                    tag={RRNavLink}
                    to="/items"
                  >
                    Items
                  </NavLink>
                </NavItem>
              </Nav>
            </Collapse>
            <Button
              color="primary"
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
          </>
        ) : (
          <Nav navbar>
            <NavItem>
              <NavLink
                tag={RRNavLink}
                to="/login"
              >
                <Button color="primary">Login</Button>
              </NavLink>
            </NavItem>
          </Nav>
        )}
      </Navbar>
    </div>
  );
}
