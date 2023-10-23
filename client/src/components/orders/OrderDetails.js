import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchSingleOrder } from '../../managers/OrderManager.js';
import {
  Container,
  Input,
  ListGroup,
  ListGroupItem,
  Spinner,
  Table,
} from 'reactstrap';
import { dateFormatter } from '../utilities/dateFormatter.js';

export const OrderDetails = () => {
  const { id } = useParams();
  const [order, setOrder] = useState();

  const getSingleOrder = () => {
    fetchSingleOrder(id).then(setOrder);
  };

  useEffect(() => {
    getSingleOrder();
  }, []);

  if (!order) {
    return <Spinner />;
  }
  return (
    <>
      <Container>
        <div className="d-flex justify-content-between align-items-baseline">
          <h2 className="mt-3">Order Details</h2>
          <h5 className="mt-3">{dateFormatter(order.date)}</h5>
        </div>
        <Table>
          <thead>
            <th>Item</th>
            <th>Cost</th>
            <th>Quantity</th>
            <th>Subtotal</th>
          </thead>
          <tbody>
            {order.orderItems.map((oi, index) => {
              return (
                <tr key={index}>
                  <td className="text-bg-dark">
                    <img
                      src={oi.item.image}
                      alt=""
                    />
                    {oi.item.name}{' '}
                  </td>
                  <td className="text-bg-dark">P{oi.item.cost}</td>
                  <td className="text-bg-dark">{oi.quantity}</td>
                  <td className="text-bg-dark">
                    P{oi.quantity * oi.item.cost}
                  </td>
                </tr>
              );
            })}
          </tbody>
        </Table>
        <div className="d-flex flex-column align-items-end">
          <h4>Total:</h4>
          <h5>P{order.total}</h5>
        </div>
        <div>
            <h4>Billing Info</h4>
            {
                order.middleInitial ? 
                <p>{order.firstName} {order.middleInital} {order.lastName}</p>
                :
                <p>{order.firstName} {order.lastName}</p>
            }
            <p>{order.address}</p>
            <p>{order.city.name}, {order.region.name}</p>
        </div>
      </Container>
    </>
  );
};
