import { useParams } from 'react-router-dom';
import { fetchSingleUserPokemon } from '../../managers/PokemonManager.js';
import { Alert, Button, ButtonGroup, Col, Container, Row, Spinner } from 'reactstrap';
import { useEffect, useState } from 'react';
import { SuggestedItemsPokeDetails } from '../items/suggestedItems/SuggestedItemsPokeDetails.js';
import "./PokemonDetails.css"
import PokeballLoading from '../../images/pokeball-loading.gif';

export const PokemonDetails = () => {
  const [userPokemon, setUserPokemon] = useState();
    const [error, setError] = useState();

  const { id } = useParams();

  const getSingleUserPokemon = () => {
    fetchSingleUserPokemon(id)
      .then((res) => {
        if (res.status === 404) {
          setError("That pokemon could not be found")
        }
        setUserPokemon(res);
      })
      .catch(() => {
        setError('You are not authorized to view this content');
      });
  };

  useEffect(() => {
    getSingleUserPokemon();
  }, []);

  if (error) {
    return (
      <>
        <div className="d-flex fs-5 justify-content-center h-75 align-items-center">
          <Alert
            className="rounded-0 m-0 p-3"
            color="danger"
          >
            {error}
          </Alert>
        </div>
      </>
    );
  }


  if (!userPokemon) {
 return (
   <>
     <div className="d-flex justify-content-center h-75 align-items-center">
       <img
         style={{
           width: '200px',
         }}
         src={PokeballLoading}
         alt=""
       />
     </div>
   </>
 );
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
          </Col>
          <Col className="d-flex flex-column justify-content-center">
            <div className="pokemon-details-info-container text-bg-dark p-4">
              <div className='mb-4'>

              <h1 className="display-5">{userPokemon.nickName}</h1>
                  <h5 className='pokemon-details-level'>Lvl. {userPokemon.level}</h5>
              </div>
              <h5>
                Species: {userPokemon.pokemon.name} #{userPokemon.pokemon.id}
              </h5>

              <div>
                <div className='d-flex gap-3'>
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
              </div>
            </div>
          </Col>
        </Row>
        <Row>
          <Col>
            <SuggestedItemsPokeDetails userPokemon={userPokemon} />
          </Col>
        </Row>
      </Container>
    </>
  );
};
