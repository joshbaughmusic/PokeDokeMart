import {
  Card,
  CardBody,
  CardSubtitle,
  CardTitle,
} from 'reactstrap';
import { useNavigate } from 'react-router-dom';


export const AllItemCard = ({ item, index }) => {
  const navigate = useNavigate()

  return (
    <>
      <Card
        onClick={() => navigate(`${item.id}`)}
        color="dark"
        key={index}
        inverse
        className="rounded-0"
        style={{
          width: '12rem',
          marginTop: '15px',
          cursor: 'pointer',
        }}
      >
        <img
          alt="Sample"
          src={item.image}
        />
        <CardBody>
          <CardTitle tag="h5">
            <span>{item.name}</span>
            {
              item.move ?
              <div className='small' >{item.move.name}</div>
              :
              ''
            }
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
