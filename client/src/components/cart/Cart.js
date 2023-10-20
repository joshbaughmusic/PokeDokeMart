import { useState } from 'react';
import {
  Offcanvas,
  OffcanvasHeader,
  OffcanvasBody,
  NavItem,
  Spinner,
  ListGroup,
  ListGroupItem,
  Input,
} from 'reactstrap';
import { useShoppingCart } from '../../context/ShoppingCartContext.js';
import { FiShoppingCart } from 'react-icons/fi';
import { AiOutlineClose } from 'react-icons/ai';
import './Cart.css';

export const Cart = () => {
  const [isOpen, setIsOpen] = useState(false);
  const { getUniqueItemCount, cartItems, alterCartQuantity, removeFromCart } =
    useShoppingCart();
  const toggle = () => {
    setIsOpen(!isOpen);
  };

  if (!cartItems) {
    return <Spinner />;
  }

  return (
    <div>
      <NavItem onClick={toggle}>
        <FiShoppingCart
          style={{
            fontSize: '25px',
          }}
          className="cart-icon"
        />{' '}
        {getUniqueItemCount()}
      </NavItem>
      <Offcanvas
        isOpen={isOpen}
        direction="end"
        scrollable
        toggle={toggle}
        className="offcanvas-below-navbar"
      >
        <OffcanvasHeader toggle={toggle}>Your PokeCart</OffcanvasHeader>
        <OffcanvasBody>
          <ListGroup>
            {cartItems.length > 0 ? (
              cartItems.map((item, index) => {
                return (
                  <ListGroupItem key={index}>
                    <img
                      src={item.image}
                      alt=""
                    />
                    <p>{item.name}</p>
                    <Input
                      type="number"
                      min={1}
                      value={item.quantity}
                      onChange={(e) => alterCartQuantity(item, e.target.value)}
                    />
                    <AiOutlineClose
                      style={{
                        fontSize: '25px',
                      }}
                      onClick={() => removeFromCart(item.id)}
                    />
                  </ListGroupItem>
                );
              })
            ) : (
              <p>Your PokeCart is empty!</p>
            )}
          </ListGroup>
        </OffcanvasBody>
      </Offcanvas>
    </div>
  );
};
