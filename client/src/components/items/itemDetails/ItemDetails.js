import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchSingleItem } from '../../../managers/ItemsManager.js';
import { Button, Col, Container, Row, Spinner } from 'reactstrap';

export const ItemDetails = () => {
  const [item, setItem] = useState();
  const [quantity, setQuantity] = useState(1);
  const { id } = useParams();

  const getSingleItem = () => {
    fetchSingleItem(id).then(setItem);
  };

  useEffect(() => {
    getSingleItem();
  }, []);

  if (!item) {
    return <Spinner />;
  }

  return (
    <>
      <Container>
        <p>Breadcrumbs Placeholder</p>
        <Row>
          <Col className="d-flex flex-column align-items-center mt-5">
            <img
              src={item.image}
              alt=""
              style={{
                width: '50%',
                border: '2px solid white',
              }}
            />
            <div
              className="mt-4"
              style={{
                width: '50%',
              }}
            >
              <p className="mb-1">
                <b>Item Description:</b>
              </p>
              <p>{item.description}</p>
            </div>
          </Col>
          <Col className="d-flex flex-column align-content-center mt-5">
            <div className="item-heading">
              <h1>{item.name}</h1>
              <p className="fs-4">P{item.cost}</p>
            </div>
            <div>
              <p>Quantity:</p>
              <div className="d-flex">
                <Button
                  className="rounded-0"
                  onClick={() =>
                    quantity > 1 ? setQuantity(quantity - 1) : null
                  }
                >
                  -
                </Button>
                <div className="fs-3 mx-3">{quantity}</div>
                <Button
                  className="rounded-0"
                  onClick={() => setQuantity(quantity + 1)}
                >
                  +
                </Button>
              </div>
            </div>
            <Button
              className="mt-5"
              style={{ width: '40%' }}
            >
              Add to cart
            </Button>
            <div className='mt-5'>
                Also consider section placeholder
            </div>
          </Col>
        </Row>
        <Row>
            <Col className='d-flex justify-content-center mt-5'>
            <div>Review section placeholder</div>
            </Col>
        </Row>
      </Container>
    </>
  );
};
