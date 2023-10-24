import { useEffect, useState } from 'react';
import { fetchAllReviewsForItem } from '../../managers/ReviewManager.js';
import { Container, Spinner } from 'reactstrap';
import { calculateAverageReviewScore } from '../utilities/averageReviewScore.js';
import { ItemDetailsSingleReview } from './ItemDetailsSingleReview.js';
import { ConvertRatingToIcons } from '../utilities/CovertRatingToIcons.js';

export const ItemDetailsAllReviews = ({ itemId }) => {
  const [allReviewsByItem, setAllReviewsByItem] = useState();

  const getAllReviewsByItem = () => {
    fetchAllReviewsForItem(itemId).then(setAllReviewsByItem);
  };

  useEffect(() => {
    getAllReviewsByItem();
  }, []);

  if (!allReviewsByItem) {
    return <Spinner />;
  }

  if (allReviewsByItem.length === 0) {
    return (
        <>
        <div>No reviews yet!</div>
        </>
    )
  }

  return (
    <Container>
      <h5>Reviews:</h5>
      <div className="mt-3">
        <div className="d-flex gap-1">
          <div>{`(${allReviewsByItem.length})`}</div>
          {/* <div>Avg Review: {ConvertRatingToIcons(calculateAverageReviewScore(allReviewsByItem))}</div> */}
          <ConvertRatingToIcons rating={calculateAverageReviewScore(allReviewsByItem)} />
        </div>
        {allReviewsByItem.map((review, index) => (
          <ItemDetailsSingleReview
            key={index}
            review={review}
          />
        ))}
      </div>
    </Container>
  );
};
