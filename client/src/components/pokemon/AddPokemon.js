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
  Alert,
} from 'reactstrap';
import { fetchCreateNewUserPokemon } from '../../managers/PokemonManager.js';

export const AddPokemon = ({ allPokemon, myPokemon, getMyPokemon }) => {
  const [newUserPokemon, setNewUserPokemon] = useState({
    nickName: '',
    pokemonId: null,
    level: null,
  });
  const [visibleError, setVisibleError] = useState(false);
  const [visibleSuccess, setVisibleSuccess] = useState(false);
  const [disabled, setDisabled] = useState(false);
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);
  const onDismissError = () => setVisibleError(false);

  const handleChange = (e) => {
    setNewUserPokemon({
      ...newUserPokemon,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = () => {
    if (
      newUserPokemon.nickName &&
      newUserPokemon.pokemonId &&
      parseInt(newUserPokemon.level) > 0 &&
      parseInt(newUserPokemon.level) <= 100
    ) {
      fetchCreateNewUserPokemon(newUserPokemon).then(() => {
        getMyPokemon();
        setDisabled(true)
        setVisibleSuccess(true);
        setTimeout(() => {
            toggle();
            setDisabled(false)
        }, 2000);
      });
    } else {
      setVisibleError(true);
    }
  };

  return (
    <>
      {myPokemon.length === 6 ? (
        <div>Your party is full!</div>
      ) : (
        <Button
          onClick={toggle}
          className="rounded-0 mb-2"
        >
          Add Pokemon
        </Button>
      )}
      <Modal
        isOpen={modal}
        toggle={toggle}
        className="rounded-0"
        onClosed={() => {
          setVisibleSuccess(false);
          setVisibleError(false);
        }}
        backdrop="static"
        centered={true}
      >
        <ModalHeader
          toggle={toggle}
          close={<span></span>}
        >
          Add a pokemon to your party:
        </ModalHeader>
        <ModalBody>
          <Form>
            <FormGroup>
              <Label>Nickname</Label>
              <Input
                name="nickName"
                maxLength="20"
                onChange={handleChange}
              />
            </FormGroup>
            <FormGroup>
              <Label>Species</Label>
              <Input
                type="select"
                name="pokemonId"
                onChange={handleChange}
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
            Pokemon added successfully!
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
                setNewUserPokemon({
                  nickName: '',
                  pokemonId: null,
                  level: null,
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
                setNewUserPokemon({
                  nickName: '',
                  pokemonId: null,
                  level: null,
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
