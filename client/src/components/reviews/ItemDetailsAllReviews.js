import { useEffect, useState } from 'react';
import { fetchAllReviewsForItem } from '../../managers/ReviewManager.js';
import { Container, Spinner } from 'reactstrap';
import { calculateAverageReviewScore } from '../utilities/averageReviewScore.js';
import { ItemDetailsSingleReview } from './ItemDetailsSingleReview.js';
import { ConvertRatingToIcons } from '../utilities/CovertRatingToIcons.js';
import { NewReview } from './NewReview.js';
import { SortReviews } from './SortReviews.js';

export const ItemDetailsAllReviews = ({ itemId, loggedInUser }) => {
  const [allReviewsByItem, setAllReviewsByItem] = useState();

  const getAllReviewsByItem = () => {
    fetchAllReviewsForItem(itemId).then(setAllReviewsByItem);
  };

  useEffect(() => {
    getAllReviewsByItem();
  }, [itemId]);

  if (!allReviewsByItem) {
    return <Spinner />;
  }

  if (allReviewsByItem.length === 0) {
    return (
      <div className="d-flex justify-content-between align-items-center">
        <div>No reviews yet!</div>
        <NewReview
          loggedInUser={loggedInUser}
          allReviewsByItem={allReviewsByItem}
          itemId={itemId}
          getAllReviewsByItem={getAllReviewsByItem}
        />
      </div>
    );
  }

  return (
    <Container>
      <NewReview
        loggedInUser={loggedInUser}
        allReviewsByItem={allReviewsByItem}
        itemId={itemId}
      />

      <h5>Reviews:</h5>
      <div className="mt-3">
        <div className="d-flex justify-content-between">
          <div className="d-flex gap-1">
            <div>{`(${allReviewsByItem.length})`}</div>
            <ConvertRatingToIcons
              rating={calculateAverageReviewScore(allReviewsByItem)}
            />
          </div>
          <SortReviews
            allReviewsByItem={allReviewsByItem}
            setAllReviewsByItem={setAllReviewsByItem}
          />
        </div>
        {allReviewsByItem.map((review, index) => (
          <ItemDetailsSingleReview
            loggedInUser={loggedInUser}
            key={index}
            review={review}
            getAllReviewsByItem={getAllReviewsByItem}
          />
        ))}
      </div>
    </Container>
  );
};
