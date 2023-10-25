import { useEffect, useState } from 'react';
import { Container, ListGroup, ListGroupItem, Spinner } from 'reactstrap';
import { fetchMyPokemon } from '../../managers/PokemonManager.js';
import { FiEdit } from 'react-icons/fi';
import { AiOutlineClose } from 'react-icons/ai';
import { useNavigate } from 'react-router-dom';
import './MyPokemonList.css';
import { AddPokemon } from './AddPokemon.js';

export const MyPokemonList = () => {
  const [myPokemon, setMyPokemon] = useState();
  const navigate = useNavigate();

  const getMyPokemon = () => {
    fetchMyPokemon().then(setMyPokemon);
  };

  useEffect(() => {
    getMyPokemon();
  }, []);

  if (!myPokemon) {
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
                  <FiEdit />
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