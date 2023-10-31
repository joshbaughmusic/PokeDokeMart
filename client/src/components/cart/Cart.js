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
import PokeballLoading from '../../images/pokeball-loading.gif';

export const Cart = () => {
  const [isOpen, setIsOpen] = useState(false);
  const { getUniqueItemCount, cartItems, alterCartQuantity, removeFromCart } =
    useShoppingCart();
  const toggle = () => {
    setIsOpen(!isOpen);
  };
  const navigate = useNavigate();

  if (!cartItems) {
    return (
      <>
        <div className="d-flex justify-content-center h-75 align-items-center">
          <img
            style={{
              width: '200px',
            }}
            src={PokeballLoading}
            alt=""
          />
        </div>
      </>
    );

  }

  return (
    <div>
      <NavItem
        onClick={toggle}
        role="button"
        className="d-flex gap-1 position-relative cart-nav"
      >
        <FiShoppingCart
          style={{
            fontSize: '25px',
          }}
          className="cart-icon"
        />
        <div className="position-absolute d-flex justify-content-center align-items-center cart-count">
          <div>{getUniqueItemCount()}</div>
        </div>
      </NavItem>
      <Offcanvas
        isOpen={isOpen}
        direction="end"
        scrollable
        toggle={toggle}
        className="text-bg-dark"
      >
        <OffcanvasHeader
          toggle={toggle}
          className="cart-heading"
        >
          
            <div className="cart-heading-text">Your PokeCart</div>
            <AiOutlineClose
              className="cart-delete-button"
              style={{
                fontSize: '25px',
              }}
              onClick={() => toggle()}
            />
          
        </OffcanvasHeader>
        <OffcanvasBody className="d-flex flex-column justify-content-between">
          <ListGroup>
            {cartItems.length > 0 ? (
              cartItems.map((item, index) => {
                return (
                  <ListGroupItem
                    key={index}
                    className="cart-list-item p-3 rounded-0"
                  >
                    <div className="d-flex justify-content-between">
                      <div className="d-flex align-items-center gap-1">
                        <img
                          src={item.image}
                          alt=""
                        />
                        <div
                          className="cart-item-name-link"
                          onClick={() => {
                            navigate(`/items/${item.id}`);
                            toggle();
                          }}
                        >
                          {item.name}
                        </div>
                      </div>
                      <Input
                        type="number"
                        min={1}
                        max={99}
                        value={item.quantity}
                        className="rounded-0 cart-quantity-input"
                        onChange={(e) =>
                          alterCartQuantity(item, parseInt(e.target.value))
                        }
                      />
                      <AiOutlineClose
                        className="cart-delete-button"
                        style={{
                          fontSize: '25px',
                        }}
                        onClick={() => removeFromCart(item.id)}
                      />
                    </div>
                    <div>P{item.cost}</div>
                  </ListGroupItem>
                );
              })
            ) : (
              <p>Your PokeCart is empty!</p>
            )}
          </ListGroup>
          {cartItems.length > 0 ? (
            <div className='d-flex justify-content-between align-items-center'>
              <h5 className="cart-total mb-1">
                Total: P
                {cartItems.reduce(
                  (totalPrice, item) => totalPrice + item.cost * item.quantity,
                  0
                )}
              </h5>
              <Button
                className="rounded-0"
                onClick={() => {
                  navigate('/checkout');
                  toggle();
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
