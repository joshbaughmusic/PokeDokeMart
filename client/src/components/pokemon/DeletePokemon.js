import { useState } from 'react';
import { AiOutlineClose } from 'react-icons/ai';
import {
  Button,
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter,
} from 'reactstrap';
import { fetchDeleteUserPokemon } from '../../managers/PokemonManager.js';

export const DeletePokemon = ({ getMyPokemon, userPokemon }) => {
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);

  const handleDelete = () => {
    fetchDeleteUserPokemon(userPokemon.id).then(() => {
        getMyPokemon()
        toggle()
    })
  };

  return (
    <>
      <div>
        <AiOutlineClose
          className="pokemon-list-icon"
          onClick={toggle}
        />
      </div>
      <Modal
        isOpen={modal}
        toggle={toggle}
        className="rounded-0"
        backdrop="static"
        centered={true}
      >
        <ModalHeader
          toggle={toggle}
          close={<span></span>}
        >
          Confirm Removal
        </ModalHeader>
        <ModalBody>
          <div>
            Are you sure you want to remove this pokemon from your party?
          </div>
        </ModalBody>
        <ModalFooter>
          <Button
            onClick={handleDelete}
            className="rounded-0"
          >
            Confirm
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
    </>
  );
};
