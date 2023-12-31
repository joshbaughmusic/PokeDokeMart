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
import PokeballLoading from '../../images/pokeball-loading.gif';

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
       <div className="d-flex justify-content-center h-100 align-items-center mb-5 mt-3">
         <Spinner />
       </div>
     </>
   );

  }

  if (allReviewsByItem.length === 0) {
    return (
      <>
        <div className="mt-5 mb-5 item-details-all-reviews-container text-bg-dark p-4">
          <div className="d-flex justify-content-between">
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
        </div>
      </>
    );
  }

  return (
    <Container className="mt-5 mb-5 item-details-all-reviews-container text-bg-dark p-4">
      <div className="d-flex justify-content-between">
        <h4 className="review-heading">Reviews:</h4>
        <NewReview
          loggedInUser={loggedInUser}
          allReviewsByItem={allReviewsByItem}
          itemId={itemId}
          getAllReviewsByItem={getAllReviewsByItem}
        />
      </div>
      <div className="mt-3">
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
        <div className="w-100 d-flex justify-content-center mt-4">
          {isOpen ? (
            <Button
              onClick={toggle}
              className="rounded-0 w-100"
            >
              Hide All Reviews <AiOutlineUp />
            </Button>
          ) : (
            <Button
              onClick={toggle}
              className="rounded-0 w-100"
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
