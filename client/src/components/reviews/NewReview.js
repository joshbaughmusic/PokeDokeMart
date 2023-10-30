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
import { fetchCreateNewReview } from '../../managers/ReviewManager.js';

export const NewReview = ({
  loggedInUser,
  allReviewsByItem,
  itemId,
  getAllReviewsByItem,
}) => {
  const [reviewBody, setReviewBody] = useState();
  const [rating, setRating] = useState(0);

  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);

  const handleChange = (e) => {
    setReviewBody(e.target.value);
  };

  const handleSubmit = () => {
    const newReviewObject = {
      rating: rating,
      body: reviewBody,
      itemId: itemId,
    };
    fetchCreateNewReview(newReviewObject).then(() => {
      getAllReviewsByItem();
      toggle();
    });
  };

  return (
    <>
      <div className="d-flex justify-content-end">
        {allReviewsByItem.some((r) => r.userProfileId === loggedInUser.id) ? (
          <p>Thanks for leaving a review!</p>
        ) : (
          <Button
            onClick={toggle}
            className="rounded-0"
          >
            Leave a Review
          </Button>
        )}
        <Modal
          isOpen={modal}
          toggle={toggle}
          className="rounded-0"
          onClosed={() => {
            setRating(0);
            setReviewBody({ body: '' });
          }}
        >
          <ModalHeader toggle={toggle}>New Review:</ModalHeader>
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
                  name="reviewBody"
                  onChange={handleChange}
                />
              </FormGroup>
            </Form>
          </ModalBody>
          <ModalFooter>
            <Button onClick={handleSubmit}>Submit</Button>
          </ModalFooter>
        </Modal>
      </div>
    </>
  );
};
