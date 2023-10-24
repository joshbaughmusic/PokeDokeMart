import { useEffect, useState } from 'react';
import { Container } from 'reactstrap';
import { dateFormatter } from '../utilities/dateFormatter.js';
import { ConvertRatingToIcons } from '../utilities/CovertRatingToIcons.js';
import { EditReview } from './EditReview.js';

export const ItemDetailsSingleReview = ({ review, loggedInUser,         getAllReviewsByItem
 }) => {
  return (
    <>
      <Container className="mt-4 border">
        <div className="d-flex justify-content-between align-items-center">
          <div className="d-flex gap-1 align-items-center">
            Rating: <ConvertRatingToIcons rating={review.rating} />
          </div>
          <div className="d-flex gap-3 align-items-center">
            <div>{dateFormatter(review.date)}</div>
            <div>{`${review.userProfile.firstName} ${review.userProfile.lastName}`}</div>
            <img
              src={review.userProfile.profilePictureUrl}
              alt=""
              style={{
                width: '30px',
                height: '30px',
                objectFit: 'cover',
              }}
              className="my-3"
            />
          </div>
        </div>
        <div className="my-3">{`"${review.body}"`}</div>
        {review.userProfileId === loggedInUser.id ? (
          <EditReview
            review={review}
            getAllReviewsByItem={getAllReviewsByItem}
          />
        ) : (
          ''
        )}
      </Container>
    </>
  );
};
