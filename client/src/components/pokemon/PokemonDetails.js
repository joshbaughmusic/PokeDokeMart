import { useParams } from 'react-router-dom';
import { fetchSingleUserPokemon } from '../../managers/PokemonManager.js';
import { Button, ButtonGroup, Col, Container, Row, Spinner } from 'reactstrap';
import { useEffect, useState } from 'react';

export const PokemonDetails = () => {
  const [userPokemon, setUserPokemon] = useState();
  const { id } = useParams();

  const getSingleUserPokemon = () => {
    fetchSingleUserPokemon(id).then(setUserPokemon);
  };

  useEffect(() => {
    getSingleUserPokemon();
  }, []);

  if (!userPokemon) {
    return <Spinner />;
  }
  return (
    <>
      <Container>
        <Row>
          <Col className="d-flex flex-column">
            <img
              src={userPokemon.pokemon.image}
              alt=""
            />
            <ButtonGroup>
              <Button className="rounded-0">Edit</Button>
              <Button className="rounded-0">Delete</Button>
            </ButtonGroup>
          </Col>
          <Col className="d-flex flex-column justify-content-center py-5">
            <h1>{userPokemon.nickName}</h1>
            <h5>
              Species: {userPokemon.pokemon.name} #{userPokemon.pokemon.id}
            </h5>

            <div className="d-flex gap-5">
              <div>
                <h5>Type:</h5>
                {userPokemon.pokemon.pokemonTypes.length === 2 ? (
                  <p>
                    {userPokemon.pokemon.pokemonTypes[0].pokeType.name}/
                    {userPokemon.pokemon.pokemonTypes[1].pokeType.name}
                  </p>
                ) : (
                  <p>{userPokemon.pokemon.pokemonTypes[0].pokeType.name} </p>
                )}
              </div>
              <h5>Lvl. {userPokemon.level}</h5>
            </div>
          </Col>
        </Row>
        <Row>
          <Col className="text-center mt-5 border p-5">
            suggested items by pokemon placeholder
          </Col>
        </Row>
      </Container>
    </>
  );
};