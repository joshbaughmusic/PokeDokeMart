import { useEffect, useState } from 'react';
import { fetchAllReviewsByUser } from '../../managers/ReviewManager.js';
import { Container, Spinner } from 'reactstrap';
import { ProfileSingleReview } from './ProfileSingleReview.js';

export const ProfileAllReviews = ({ loggedInUser }) => {
  const [allReviewsByUser, setAllReviewsByUser] = useState();

  const getAllReviewsByUser = () => {
    fetchAllReviewsByUser(loggedInUser.id).then(setAllReviewsByUser);
  };

  useEffect(() => {
    getAllReviewsByUser();
  }, []);

  if (!allReviewsByUser) {
      return (
        <>
          <div className="d-flex justify-content-center h-100 align-items-center mb-5 mt-3">
            <Spinner />
          </div>
        </>
      );
  }

  if (allReviewsByUser.length === 0) {
    return (
      <div className="d-flex justify-content-between align-items-center">
        <div>No reviews yet!</div>
      </div>
    );
  }

  return (
    <Container className='mt-4'>
      <h4>My Reviews:</h4>
      <div className="mt-3">
        
        {allReviewsByUser.map((review, index) => (
          <ProfileSingleReview
            loggedInUser={loggedInUser}
            key={index}
            review={review}
            getAllReviewsByUser={getAllReviewsByUser}
          />
        ))}
      </div>
    </Container>
  );
};
