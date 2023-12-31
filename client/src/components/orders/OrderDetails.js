import { useEffect, useState } from 'react';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { fetchSingleOrder } from '../../managers/OrderManager.js';
import { Alert, Container, Table } from 'reactstrap';
import { dateFormatter } from '../utilities/dateFormatter.js';
import './OrderDetails.css';
import PokeballLoading from '../../images/pokeball-loading.gif';

export const OrderDetails = () => {
  const { id } = useParams();
  const [order, setOrder] = useState();
  const [error, setError] = useState();
  const navigate = useNavigate();

  const getSingleOrder = () => {
    fetchSingleOrder(id)
      .then((res) => {
         if (res.status === 404) {
           setError('That order could not be found');
         }
        setOrder(res);
      })
      .catch(() => {
        setError("You are not authorized to view this content");
      });
  };

  useEffect(() => {
    getSingleOrder();
  }, []);

  if (error) {
    return (
      <>
        <div className="d-flex fs-5 justify-content-center h-75 align-items-center">
          <Alert
            className="rounded-0 m-0 p-3"
            color="danger"
          >
            {error}
          </Alert>
        </div>
      </>
    );
  }

  if (!order) {
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
    <>
      <Container className="text-bg-dark my-5 p-5 order-details-container">
        <div className="d-flex justify-content-between align-items-baseline">
          <h2 className="mb-4 order-details-heading">Order Details</h2>
          <h5>{dateFormatter(order.date)}</h5>
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
                    <div className="d-flex gap-1">
                      <img
                        src={oi.item.image}
                        alt=""
                      />
                      <div
                        className="order-details-item-link"
                        onClick={() => navigate(`/items/${oi.item.id}`)}
                      >
                        {oi.item.name}
                      </div>
                    </div>
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
        <div className="d-flex justify-content-between mt-5">
          <div className="p-3 order-details-billing-container">
            <h4 className="mb-3">Billing Info:</h4>
            {order.middleInitial ? (
              <p>
                Name: {order.firstName} {order.middleInital} {order.lastName}
              </p>
            ) : (
              <p>
                Name: {order.firstName} {order.lastName}
              </p>
            )}
            <p>Street: {order.address}</p>
            <p>
              C/R: {order.city.name}, {order.region.name}
            </p>
          </div>
          <div className="d-flex flex-column">
            <h4>Total:</h4>
            <h5>P{order.total}</h5>
          </div>
        </div>
        <div></div>
      </Container>
    </>
  );
};
