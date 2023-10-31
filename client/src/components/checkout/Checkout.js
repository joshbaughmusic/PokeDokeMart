import {
  Spinner,
  Input,
  Container,
  Table,
} from 'reactstrap';
import { useShoppingCart } from '../../context/ShoppingCartContext.js';
import { AiOutlineClose } from 'react-icons/ai';
import { CheckoutForm } from './CheckoutForm.js';
import './Checkout.css';
import PokeballLoading from '../../images/pokeball-loading.gif';


export const Checkout = ({ loggedInUser }) => {
  const { cartItems, alterCartQuantity, removeFromCart } = useShoppingCart();

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
    <Container className="text-bg-dark mt-5 p-5 checkout-container">
      <h2 className="checkout-heading mb-4">Checkout</h2>
      {cartItems.length > 0 ? (
        <>
          <Table>
            <thead>
              <tr>
                <th className="text-bg-dark">Item</th>
                <th className="text-bg-dark">Price</th>
                <th className="text-bg-dark">Quantity</th>
                <th className="text-bg-dark"></th>
              </tr>
            </thead>
            <tbody>
              {cartItems.map((item, index) => (
                <tr key={index}>
                  <td className="text-bg-dark">
                    <div className="d-flex align-items-center gap-1">
                      <img
                        src={item.image}
                        alt=""
                      />
                      <div>{item.name}</div>
                    </div>
                  </td>
                  <td className="text-bg-dark">
                    <div className="checkout-cost">P{item.cost}</div>
                  </td>
                  <td className="text-bg-dark">
                    <div>
                      <Input
                        type="number"
                        min={1}
                        max={99}
                        value={item.quantity}
                        onChange={(e) =>
                          alterCartQuantity(item, parseInt(e.target.value))
                        }
                        className="rounded-0"
                        style={{ width: '21%', height: '33px' }}
                      />
                    </div>
                  </td>
                  <td className="text-bg-dark ">
                    <div>
                      <AiOutlineClose
                        className="checkout-delete-button"
                        style={{
                          fontSize: '25px',
                        }}
                        onClick={() => removeFromCart(item.id)}
                      />
                    </div>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
          <h5>
            Total: P
            {cartItems.reduce(
              (totalPrice, item) => totalPrice + item.cost * item.quantity,
              0
            )}
          </h5>
          <CheckoutForm
            loggedInUser={loggedInUser}
            cartItems={cartItems}
          />
        </>
      ) : (
        <p className="fs-4 text-center mt-3">Your PokeCart is empty!</p>
      )}
    </Container>
  );
};
