import {
  Button,
  Container,
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter,
} from 'reactstrap';
import { dateFormatter } from '../utilities/dateFormatter.js';
import { ConvertRatingToIcons } from '../utilities/CovertRatingToIcons.js';
import { fetchDeleteReview } from '../../managers/ReviewManager.js';
import { useEffect, useState } from 'react';
import { ProfileEditReview } from './ProfileEditReview.js';
import { fetchSingleItem } from '../../managers/ItemsManager.js';
import { useNavigate } from 'react-router-dom';
import "./ProfileSingleReview.css"

export const ProfileSingleReview = ({
  review,
  loggedInUser,
  getAllReviewsByUser,
}) => {
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);
  const navigate = useNavigate()
  const [item, setItem] = useState();

  const getSingleItem = () => {
    fetchSingleItem(review.itemId).then(setItem);
  };

  useEffect(() => {
    getSingleItem();
  }, []);

  const handleDelete = () => {
    fetchDeleteReview(review.id).then(() => {
      getAllReviewsByUser();
      toggle();
    });
  };

  if(!item) {
    return null
  }

  return (
    <>
      <Modal
        isOpen={modal}
        toggle={toggle}
        backdrop="static"
      >
        <ModalHeader
          toggle={toggle}
          close={<span></span>}
        >
          Confirm Deletion
        </ModalHeader>
        <ModalBody>
          <div>Are you sure you want to delete this review?</div>
        </ModalBody>
        <ModalFooter>
          <Button
            onClick={handleDelete}
            className="rounded-0"
          >
            Delete
          </Button>
          <Button
            onClick={() => {
              toggle();
            }}
            className="rounded-0"
          >
            Cancel
          </Button>
        </ModalFooter>
      </Modal>

      <Container className="mt-4 border">
        <div className='d-flex align-items-center gap-1 my-3'>
          <h5 className='profile_review_name_link' onClick={() => navigate(`/items/${item.id}`)}>{item.name}</h5>
          <img
            src={item.image}
            alt=""
          />
        </div>
        <div className="d-flex justify-content-between align-items-center">
          <div className="d-flex gap-1 align-items-center">
            Rating: <ConvertRatingToIcons rating={review.rating} />
          </div>
          <div className="d-flex gap-3 align-items-center">
            <div>{dateFormatter(review.date)}</div>
          </div>
        </div>
        <div className="my-3">{`"${review.body}"`}</div>
        {review.userProfileId === loggedInUser.id ? (
          <>
            <ProfileEditReview
              review={review}
              getAllReviewsByUser={getAllReviewsByUser}
            />
            <Button
              className="rounded-0"
              onClick={() => toggle()}
            >
              Delete
            </Button>
          </>
        ) : (
          ''
        )}
      </Container>
    </>
  );
};
