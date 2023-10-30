import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchSingleItem } from '../../../managers/ItemsManager.js';
import { Button, Col, Container, Row, Spinner } from 'reactstrap';
import { useShoppingCart } from '../../../context/ShoppingCartContext.js';
import { ItemDetailsAllReviews } from '../../reviews/ItemDetailsAllReviews.js';
import { AlsoConsiderSection } from '../alsoConsider/AlsoConsiderSection.js';
import "./ItemDetails.css"

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
    return (
      <>
        <div className="d-flex justify-content-center h-75 align-items-center">
          <Spinner />
        </div>
      </>
    );
  }

  return (
    <>
      <Container>
        <Row>
          <Col className="d-flex justify-content-center">
            <div className="d-flex flex-column align-items-center justify-content-center mt-5 text-center text-bg-dark w-75 gap-5 item-details-left-panel">
              <img
                src={item.image}
                alt=""
                className="item-details-img"
                style={{
                  width: '60%',
                }}
              />
              <div
                className="mt-4"
                style={{
                  width: '70%',
                }}
              >
                {item.move ? (
                  <>
                  <h5 className="mb-3">Move Description:</h5>
                    <h3 className="mb-3">{item.move.name}</h3>

                    <p>{item.description}</p>
                    <h5 className="mt-4 mb-3">Details:</h5>
                    <div className="d-flex gap-2 justify-content-center">
                      <p>
                        <b>Type:</b>
                      </p>
                      <p>{item.move.pokeType.name}</p>
                    </div>
                    <div className="d-flex gap-2 justify-content-center">
                      <p>
                        <b>D.Class:</b>
                      </p>
                      <p>{item.move.damageClass.name}</p>
                    </div>
                  </>
                ) : (
                  <>
                    <h5 className="mb-2">Item Description:</h5>
                    <p>{item.description}</p>
                  </>
                )}
              </div>
            </div>
          </Col>
          <Col className="d-flex flex-column align-items-center mt-5 text-center">
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
                className="mt-3 rounded-0"
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
