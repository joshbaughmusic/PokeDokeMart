import { Container, Table, Collapse, Button } from 'reactstrap';
import { dateFormatter } from '../utilities/dateFormatter.js';
import { Link, useNavigate } from 'react-router-dom';
import { useState } from 'react';
import { AiOutlineDown, AiOutlineUp } from 'react-icons/ai';

export const MyOrders = ({ orders }) => {
  const [isOpen, setIsOpen] = useState(false);
  const toggle = () => setIsOpen(!isOpen);
  const navigate = useNavigate();

  if (orders.length === 0) {
    return (
      <div className="d-flex justify-content-center align-items-center mt-3">
        <h5>No orders yet!</h5>
      </div>
    );
  }
  return (
    <>
      <Container className="mt-4">
        <div className='d-flex justify-content-center'>
          {isOpen ? (
            <Button
              className="rounded-0 w-100 mb-3"
              onClick={toggle}
            >
              Hide All My Orders <AiOutlineUp />
            </Button>
          ) : (
            <Button
              className="rounded-0 w-100 mb-3"
              onClick={toggle}
            >
              View All My Orders <AiOutlineDown />
            </Button>
          )}
        </div>
        <Collapse isOpen={isOpen}>
          <h4 className="mb-3">My Orders:</h4>
          <Table>
            <thead>
              <th>Order Number</th>
              <th>Date</th>
              <th>Total</th>
              <th></th>
            </thead>
            <tbody>
              {orders.map((o, index) => (
                <tr key={index}>
                  <td className="text-bg-dark">#{o.id}</td>
                  <td className="text-bg-dark">{dateFormatter(o.date)}</td>
                  <td className="text-bg-dark">P{o.total}</td>
                  <td className="text-bg-dark">
                    <div
                      className="order-details-button"
                      onClick={() => navigate(`/order/${o.id}`)}
                    >
                      Details
                    </div>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Collapse>
      </Container>
    </>
  );
};
