import { useEffect, useState } from 'react';
import { fetchAllReviewsByUser } from '../../managers/ReviewManager.js';
import { Button, Collapse, Container, Spinner } from 'reactstrap';
import { ProfileSingleReview } from './ProfileSingleReview.js';
import { AiOutlineDown, AiOutlineUp } from 'react-icons/ai';


export const ProfileAllReviews = ({ loggedInUser }) => {
  const [allReviewsByUser, setAllReviewsByUser] = useState();
  const [isOpen, setIsOpen] = useState(false);
  const toggle = () => setIsOpen(!isOpen);

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
    <Container className="mt-4">
      <div className="d-flex justify-content-center">
        {isOpen ? (
          <Button
            className="rounded-0 w-100 mb-3"
            onClick={toggle}
          >
            Hide All My Reviews <AiOutlineUp />
          </Button>
        ) : (
          <Button
            className="rounded-0 w-100 mb-3"
            onClick={toggle}
          >
            View All My Reviews <AiOutlineDown />
          </Button>
        )}
      </div>
      <Collapse isOpen={isOpen}>
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
      </Collapse>
    </Container>
  );
};
