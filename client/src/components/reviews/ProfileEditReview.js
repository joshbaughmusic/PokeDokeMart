import { useState } from 'react';
import {
  Button,
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter,
  Form,
  FormGroup,
  Label,
  Input,
} from 'reactstrap';
import { PokeRating } from '../utilities/PokeRating.js';
import { fetchUpdateReview } from '../../managers/ReviewManager.js';

export const ProfileEditReview = ({ review, getAllReviewsByUser }) => {
  const [updatedReviewBody, setUpdatedReviewBody] = useState(review.body);
  const [rating, setRating] = useState(review.rating);

  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);

  const handleChange = (e) => {
    setUpdatedReviewBody(e.target.value);
  };

  const handleSubmit = () => {
    const newReviewObject = {
      id: review.id,
      rating: rating,
      body: updatedReviewBody,
      itemId: review.itemId,
      userProfileId: review.userProfileId,
      date: review.date,
    };
    fetchUpdateReview(newReviewObject).then(() => {
      getAllReviewsByUser();
      toggle();
    });
  };
  return (
    <>
      <Button
        onClick={toggle}
        className="rounded-0"
      >
        Edit
      </Button>
      <Modal
        isOpen={modal}
        toggle={toggle}
        backdrop="static"
      >
        <ModalHeader
          toggle={toggle}
          close={<span></span>}
        >
          Edit Review:
        </ModalHeader>
        <ModalBody>
          <Form>
            <FormGroup>
              <Label>Rating</Label>
              <PokeRating
                rating={rating}
                setRating={setRating}
              />
            </FormGroup>
            <FormGroup>
              <Label>Comment</Label>
              <Input
                type="textarea"
                rows="5"
                name="body"
                onChange={handleChange}
                value={updatedReviewBody}
              />
            </FormGroup>
          </Form>
        </ModalBody>
        <ModalFooter>
          <Button
            onClick={handleSubmit}
            className="rounded-0"
          >
            Submit
          </Button>
          <Button
            onClick={() => {
              toggle();
              setUpdatedReviewBody(review.body);
            }}
            className="rounded-0"
          >
            Cancel
          </Button>
        </ModalFooter>
      </Modal>
    </>
  );
};
