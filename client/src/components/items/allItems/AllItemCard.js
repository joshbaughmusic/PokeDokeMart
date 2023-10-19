import {
  Card,
  CardBody,
  CardSubtitle,
  CardTitle,
} from 'reactstrap';
import { Link } from 'react-router-dom';


export const AllItemCard = ({ item, index }) => {
  return (
    <>
      <Card
        color="dark"
        key={index}
        inverse
        style={{
          width: '12rem',
          marginTop: '15px',
        }}
      >
        <img
          alt="Sample"
          src={item.image}
        />
        <CardBody>
          <CardTitle tag="h5">
            <Link to={`${item.id}`}>{item.name}</Link>
          </CardTitle>
          <CardSubtitle
            className="mb-2"
            style={{}}
          >
            P{item.cost}
          </CardSubtitle>
        </CardBody>
      </Card>
    </>
  );
};
