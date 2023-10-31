import {
  Spinner,
  ListGroup,
  ListGroupItem,
  Input,
  Container,
} from 'reactstrap';
import { useShoppingCart } from '../../context/ShoppingCartContext.js';
import { AiOutlineClose } from 'react-icons/ai';
import { CheckoutForm } from './CheckoutForm.js';

export const Checkout = ({loggedInUser}) => {
  const { cartItems, alterCartQuantity, removeFromCart } = useShoppingCart();

  if (!cartItems) {
    return <Spinner />;
  }

  return (
    <Container>
      <h2 className="mt-3">Checkout</h2>
      <ListGroup className="mt-4">
        {cartItems.length > 0 ? (
          cartItems.map((item, index) => {
            return (
              <ListGroupItem
                key={index}
                className="text-bg-dark d-flex justify-content-between rounded-0"
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
                  max={99}
                  value={item.quantity}
                  onChange={(e) =>
                    alterCartQuantity(item, parseInt(e.target.value))
                  }
                  className="rounded-0"
                  style={{ width: '20%' }}
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
      <div>
        {cartItems.length > 0 ? (
          <h5>
            Total: P
            {cartItems.reduce(
              (totalPrice, item) => totalPrice + item.cost * item.quantity,
              0
            )}
          </h5>
        ) : null}
        {cartItems.length > 0 ? (
          <CheckoutForm
            loggedInUser={loggedInUser}
            cartItems={cartItems}
          />
        ) : null}
      </div>
    </Container>
  );
};
