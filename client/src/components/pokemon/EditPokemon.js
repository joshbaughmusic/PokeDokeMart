import { useState } from 'react';
import { FiEdit } from 'react-icons/fi';
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
  Alert,
} from 'reactstrap';
import { fetchUpdateUserPokemon } from '../../managers/PokemonManager.js';

export const EditPokemon = ({ getMyPokemon, allPokemon, userPokemon }) => {
  const [updatedUserPokemon, setUpdatedUserPokemon] = useState({
    id: userPokemon.id,
    userProfileId: userPokemon.userProfileId,
    nickName: userPokemon.nickName,
    pokemonId: userPokemon.pokemonId,
    level: userPokemon.level,
  });
  const [visibleError, setVisibleError] = useState(false);
  const [visibleSuccess, setVisibleSuccess] = useState(false);
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);
  const [disabled, setDisabled] = useState(false);
  const onDismissError = () => setVisibleError(false);

  const handleChange = (e) => {
    setUpdatedUserPokemon({
      ...updatedUserPokemon,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = () => {
    if (
      updatedUserPokemon.nickName &&
      updatedUserPokemon.pokemonId &&
      parseInt(updatedUserPokemon.level) > 0 &&
      parseInt(updatedUserPokemon.level) <= 100
    ) {
      fetchUpdateUserPokemon(updatedUserPokemon).then(() => {
        getMyPokemon();
        setVisibleSuccess(true);
        setDisabled(true);
        setTimeout(() => {
          toggle();
          setDisabled(false);
        }, 2000);
      });
    } else {
      setVisibleError(true);
    }
  };

  return (
    <>
      <div>
        <FiEdit
          className="pokemon-list-icon"
          onClick={toggle}
        />
      </div>
      <Modal
        isOpen={modal}
        toggle={toggle}
        className="rounded-0"
        backdrop="static"
        onClosed={() => {
          setVisibleSuccess(false);
          setVisibleError(false);
        }}
      >
        <ModalHeader
          toggle={toggle}
          close={<span></span>}
        >
          Edit Pokemon
        </ModalHeader>
        <ModalBody>
          <Form>
            <FormGroup>
              <Label>Nickname</Label>
              <Input
                name="nickName"
                onChange={handleChange}
                value={updatedUserPokemon.nickName}
                maxLength="20"
              />
            </FormGroup>
            <FormGroup>
              <Label>Species</Label>
              <Input
                type="select"
                name="pokemonId"
                onChange={handleChange}
                value={updatedUserPokemon.pokemonId}
              >
                <option value="null">-species-</option>
                {allPokemon.map((p, index) => (
                  <option
                    value={p.id}
                    key={index}
                  >
                    #{p.id} {p.name}
                  </option>
                ))}
              </Input>
            </FormGroup>
            <FormGroup>
              <Label>Level 1-100</Label>
              <Input
                type="number"
                max="100"
                min="1"
                name="level"
                onChange={handleChange}
                value={updatedUserPokemon.level}
              />
            </FormGroup>
          </Form>
          <Alert
            color="danger"
            isOpen={visibleError}
            toggle={onDismissError}
            className="rounded-0 mt-3"
          >
            Please fill out all pokemon details correctly!
          </Alert>
          <Alert
            color="success"
            isOpen={visibleSuccess}
            className="rounded-0 mt-3"
          >
            Pokemon edited successfully!
          </Alert>
        </ModalBody>
        <ModalFooter>
          {disabled ? (
            <Button
              disabled
              onClick={handleSubmit}
              className="rounded-0"
            >
              Submit
            </Button>
          ) : (
            <Button
              onClick={handleSubmit}
              className="rounded-0"
            >
              Submit
            </Button>
          )}
          {disabled ? (
            <Button
              disabled
              onClick={() => {
                toggle();
                setUpdatedUserPokemon({
                  id: userPokemon.id,
                  nickName: userPokemon.nickName,
                  userProfileId: userPokemon.userProfileId,
                  pokemonId: userPokemon.pokemonId,
                  level: userPokemon.level,
                });
              }}
              className="rounded-0"
            >
              Cancel
            </Button>
          ) : (
            <Button
              onClick={() => {
                toggle();
                setUpdatedUserPokemon({
                  id: userPokemon.id,
                  nickName: userPokemon.nickName,
                  userProfileId: userPokemon.userProfileId,
                  pokemonId: userPokemon.pokemonId,
                  level: userPokemon.level,
                });
              }}
              className="rounded-0"
            >
              Cancel
            </Button>
          )}
        </ModalFooter>
      </Modal>
    </>
  );
};
