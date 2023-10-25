import { useEffect, useState } from 'react';
import { Container, ListGroup, ListGroupItem, Spinner } from 'reactstrap';
import {
  fetchAllPokemon,
  fetchMyPokemon,
} from '../../managers/PokemonManager.js';
import { AiOutlineClose } from 'react-icons/ai';
import { useNavigate } from 'react-router-dom';
import './Pokemon.css';
import { AddPokemon } from './AddPokemon.js';
import { EditPokemon } from './EditPokemon.js';

export const MyPokemonList = () => {
  const [myPokemon, setMyPokemon] = useState();
  const [allPokemon, setAllPokemon] = useState();
  const navigate = useNavigate();

  const getMyPokemon = () => {
    fetchMyPokemon().then(setMyPokemon);
  };

  const getAllPokemon = () => {
    fetchAllPokemon().then(setAllPokemon);
  };

  useEffect(() => {
    getMyPokemon();
    getAllPokemon();
  }, []);

  if (!myPokemon || !allPokemon) {
    return <Spinner />;
  }
  return (
    <>
      <Container>
        <div className="d-flex justify-content-between align-items-baseline">
          <h4>My Pokemon</h4>
          <AddPokemon
            myPokemon={myPokemon}
            getMyPokemon={getMyPokemon}
            allPokemon={allPokemon}
          />
        </div>
        <ListGroup>
          {myPokemon.map((userPokemon, index) => (
            <ListGroupItem
              className="text-bg-dark rounded-0 d-flex justify-content-between align-items-center"
              key={index}
            >
              <img
                src={userPokemon.pokemon.image}
                alt=""
                style={{
                  width: '30px',
                  height: '30px',
                }}
              />
              <div
                role="button"
                className="myPokemon_listItem"
                onClick={() => navigate(`/mypokemon/${userPokemon.id}`)}
              >
                {userPokemon.nickName}
                {/* <div className="small">{userPokemon.pokemon.name}</div> */}
              </div>
              <div>Lvl. {userPokemon.level}</div>
              <div className="d-flex gap-1">
                <div>
                  <EditPokemon
                    userPokemon={userPokemon}
                    allPokemon={allPokemon}
                    getMyPokemon={getMyPokemon}
                  />
                </div>
                <div>
                  <AiOutlineClose />
                </div>
              </div>
            </ListGroupItem>
          ))}
        </ListGroup>
      </Container>
    </>
  );
};
