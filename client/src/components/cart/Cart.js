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
  Button,
} from 'reactstrap';
import { useShoppingCart } from '../../context/ShoppingCartContext.js';
import { FiShoppingCart } from 'react-icons/fi';
import { AiOutlineClose } from 'react-icons/ai';
import './Cart.css';
import { useNavigate } from 'react-router-dom';

export const Cart = () => {
  const [isOpen, setIsOpen] = useState(false);
  const { getUniqueItemCount, cartItems, alterCartQuantity, removeFromCart } =
    useShoppingCart();
  const toggle = () => {
    setIsOpen(!isOpen);
  };
  const navigate = useNavigate();

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
        className="text-bg-dark"
      >
        <OffcanvasHeader toggle={toggle}>Your PokeCart</OffcanvasHeader>
        <OffcanvasBody className="d-flex flex-column justify-content-between">
          <ListGroup>
            {cartItems.length > 0 ? (
              cartItems.map((item, index) => {
                return (
                  <ListGroupItem
                    key={index}
                    className="text-bg-dark"
                  >
                    <img
                      src={item.image}
                      alt=""
                    />
                    <p>{item.name}</p>
                    <p>P{item.cost}</p>
                    <Input
                      type="number"
                      min={1}
                      value={item.quantity}
                      onChange={(e) =>
                        alterCartQuantity(item, parseInt(e.target.value))
                      }
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
          {cartItems.length > 0 ? (
            <div>
              <h5>
                Total: P
                {cartItems.reduce(
                  (totalPrice, item) => totalPrice + item.cost * item.quantity,
                  0
                )}
              </h5>
              <Button
                onClick={() => {
                  navigate('/checkout');
                  toggle()
                }}
              >
                Checkout
              </Button>
            </div>
          ) : null}
        </OffcanvasBody>
      </Offcanvas>
    </div>
  );
};
