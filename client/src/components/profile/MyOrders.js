import { Container, Table } from 'reactstrap';
import { dateFormatter } from '../utilities/dateFormatter.js';
import { Link } from 'react-router-dom';

export const MyOrders = ({ orders }) => {
  return (
    <>
      <Container className="mt-5">
        <h4 className='mb-3'>My Orders:</h4>
        <Table>
          <thead>
            <th>Order ID</th>
            <th>Date</th>
            <th>Total</th>
            <th></th>
          </thead>
          <tbody>
            {orders.map((o, index) => (
              <tr key={index}>
                <td className="text-bg-dark">{o.id}</td>
                <td className="text-bg-dark">{dateFormatter(o.date)}</td>
                <td className="text-bg-dark">P{o.total}</td>
                <td className="text-bg-dark">
                  <Link to={`/order/${o.id}`}>Details</Link>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </Container>
    </>
  );
};
