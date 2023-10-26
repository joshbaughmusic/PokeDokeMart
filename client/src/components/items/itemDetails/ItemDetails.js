import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchSingleItem } from '../../../managers/ItemsManager.js';
import { Button, Col, Container, Row, Spinner } from 'reactstrap';
import { useShoppingCart } from '../../../context/ShoppingCartContext.js';
import { ItemDetailsAllReviews } from '../../reviews/ItemDetailsAllReviews.js';
import { AlsoConsiderSection } from '../alsoConsider/AlsoConsiderSection.js';

export const ItemDetails = ({ loggedInUser }) => {
  const [item, setItem] = useState();
  const [quantity, setQuantity] = useState(1);
  const { id } = useParams();
  const [successMessage, setSuccessMessage] = useState(false);
  const { addToCart } = useShoppingCart();

  const getSingleItem = () => {
    fetchSingleItem(id).then(setItem);
  };

  useEffect(() => {
    getSingleItem();
  }, [id]);

  const handleAddToCart = () => {
    const newItemObj = {
      id: item.id,
      name: item.name,
      cost: item.cost,
      description: item.description,
      image: item.image,
      quantity: quantity,
    };

    addToCart(newItemObj);
    setSuccessMessage(true);
    setTimeout(() => {
      setSuccessMessage(false);
    }, 3000);
  };

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
                // border: '2px solid white',
              }}
            />
            <div
              className="mt-4"
              style={{
                width: '50%',
              }}
            >
              {item.move ? (
                <>
                 
                    <h4 className='mb-4'>{item.move.name}</h4>
               
                  <h5 className="mb-2">Description:</h5>
                  <p>{item.description}</p>
                  <h5 className="mt-4 mb-3">Details:</h5>
                  <div className="d-flex gap-2">
                    <p>
                      <b>Type:</b>
                    </p>
                    <p>{item.move.pokeType.name}</p>
                  </div>
                  <div className="d-flex gap-2">
                    <p>
                      <b>D.Class:</b>
                    </p>
                    <p>{item.move.damageClass.name}</p>
                  </div>
                </>
              ) : (
                <>
                  <h5 className="mb-2">Description:</h5>
                  <p>{item.description}</p>
                </>
              )}
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
            {successMessage ? (
              <Button
                className="mt-5 rounded-0"
                disabled
                style={{ width: '40%' }}
              >
                Added to cart!
              </Button>
            ) : (
              <Button
                onClick={() => handleAddToCart()}
                className="mt-3 rounded-0"
                style={{ width: '40%' }}
              >
                Add to cart
              </Button>
            )}
            <AlsoConsiderSection item={item} />
          </Col>
        </Row>
        <Row>
          <Col className="mt-5">
            <ItemDetailsAllReviews
              itemId={id}
              loggedInUser={loggedInUser}
            />
          </Col>
        </Row>
      </Container>
    </>
  );
};
