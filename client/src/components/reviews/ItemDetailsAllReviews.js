import { useEffect, useState } from 'react';
import { fetchAllReviewsForItem } from '../../managers/ReviewManager.js';
import {
  Button,
  ButtonToolbar,
  Collapse,
  Container,
  Spinner,
} from 'reactstrap';
import { calculateAverageReviewScore } from '../utilities/averageReviewScore.js';
import { ItemDetailsSingleReview } from './ItemDetailsSingleReview.js';
import { ConvertRatingToIcons } from '../utilities/CovertRatingToIcons.js';
import { NewReview } from './NewReview.js';
import { SortReviews } from './SortReviews.js';
import './ItemDetailsAllReview.css';
import { AiOutlineDown, AiOutlineUp } from 'react-icons/ai';

export const ItemDetailsAllReviews = ({ itemId, loggedInUser }) => {
  const [allReviewsByItem, setAllReviewsByItem] = useState();

  const [isOpen, setIsOpen] = useState(false);

  const toggle = () => setIsOpen(!isOpen);

  const getAllReviewsByItem = () => {
    fetchAllReviewsForItem(itemId).then(setAllReviewsByItem);
  };

  useEffect(() => {
    getAllReviewsByItem();
  }, [itemId]);

  if (!allReviewsByItem) {
    return (
      <>
        <div className="d-flex justify-content-center h-75 align-items-center">
          <Spinner />
        </div>
      </>
    );
  }

  if (allReviewsByItem.length === 0) {
    return (
      <>
        <div className="mt-5 d-flex justify-content-between">
          <h4 className="review-heading">Reviews:</h4>

          <NewReview
            loggedInUser={loggedInUser}
            allReviewsByItem={allReviewsByItem}
            itemId={itemId}
            getAllReviewsByItem={getAllReviewsByItem}
          />
        </div>
        <div className="d-flex justify-content-center mt-5">
          <p className="fs-3">No reviews yet!</p>
        </div>
      </>
    );
  }

  return (
    <Container className="mt-5">
      <div className="d-flex justify-content-between">
        <h4 className="review-heading">Reviews:</h4>
        <NewReview
          loggedInUser={loggedInUser}
          allReviewsByItem={allReviewsByItem}
          itemId={itemId}
          getAllReviewsByItem={getAllReviewsByItem}
        />
      </div>
      <div className="mt-3 mb-4">
        <div className="d-flex justify-content-between align-items-end">
          <div className="d-flex gap-1 align-items-center">
            <div>Avg: {`(${allReviewsByItem.length})`}</div>
            <ConvertRatingToIcons
              rating={calculateAverageReviewScore(allReviewsByItem)}
            />
          </div>
          <SortReviews
            allReviewsByItem={allReviewsByItem}
            setAllReviewsByItem={setAllReviewsByItem}
          />
        </div>
        <div className="w-100 d-flex justify-content-center mt-5">
          {isOpen ? (
            <Button
              onClick={toggle}
              className="rounded-0 w-75"
            >
              Hide Reviews <AiOutlineUp />
            </Button>
          ) : (
            <Button
              onClick={toggle}
              className="rounded-0 w-75"
            >
              View All Reviews <AiOutlineDown />
            </Button>
          )}
        </div>

        <Collapse isOpen={isOpen}>
          {allReviewsByItem.map((review, index) => (
            <ItemDetailsSingleReview
              loggedInUser={loggedInUser}
              key={index}
              review={review}
              getAllReviewsByItem={getAllReviewsByItem}
            />
          ))}
        </Collapse>
      </div>
    </Container>
  );
};
