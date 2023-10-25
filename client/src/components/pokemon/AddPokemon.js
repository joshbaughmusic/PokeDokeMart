import { useEffect, useState } from 'react';
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
  Spinner,
  Alert,
} from 'reactstrap';
import {
  fetchAllPokemon,
  fetchCreateNewUserPokemon,
} from '../../managers/PokemonManager.js';

export const AddPokemon = ({ myPokemon, getMyPokemon }) => {
  const [newUserPokemon, setNewUserPokemon] = useState({
    nickName: '',
    pokemonId: null,
    level: null,
  });
  const [allPokemon, setAllPokemon] = useState();
  const [visibleError, setVisibleError] = useState(false);
  const [visibleSuccess, setVisibleSuccess] = useState(false);
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);
  const onDismissError = () => setVisibleError(false);

  const getAllPokemon = () => {
    fetchAllPokemon().then(setAllPokemon);
  };

  useEffect(() => {
    getAllPokemon();
  }, []);

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
        setVisibleSuccess(true);
        setTimeout(() => {
          toggle();
        }, 2000);
      });
    } else {
      setVisibleError(true);
    }
  };

  if (!allPokemon) {
    return <Spinner />;
  }

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
          <Button
            onClick={handleSubmit}
            className="rounded-0"
          >
            Submit
          </Button>
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
        </ModalFooter>
      </Modal>
    </>
  );
};
