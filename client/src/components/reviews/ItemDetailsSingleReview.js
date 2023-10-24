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
import { EditReview } from './EditReview.js';
import { fetchDeleteReview } from '../../managers/ReviewManager.js';
import { useState } from 'react';

export const ItemDetailsSingleReview = ({
  review,
  loggedInUser,
  getAllReviewsByItem,
}) => {
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);

  const handleDelete = () => {
    fetchDeleteReview(review.id).then(() => {
      getAllReviewsByItem();
    });
  };

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
        <ModalBody><div>Are you sure you want to delete this review?</div></ModalBody>
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
          <>
            <EditReview
              review={review}
              getAllReviewsByItem={getAllReviewsByItem}
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
