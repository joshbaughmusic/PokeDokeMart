import { useEffect, useState } from 'react';
import {
  Container,
  ListGroup,
  ListGroupItem,
  Spinner,
  Table,
} from 'reactstrap';
import {
  fetchAllPokemon,
  fetchMyPokemon,
} from '../../managers/PokemonManager.js';
import { useNavigate } from 'react-router-dom';
import './Pokemon.css';
import { AddPokemon } from './AddPokemon.js';
import { EditPokemon } from './EditPokemon.js';
import { DeletePokemon } from './DeletePokemon.js';
import PokeballLoading from '../../images/pokeball-loading.gif';


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
 return (
   <>
     <div className="d-flex justify-content-center h-100 align-items-center mb-5 mt-3">
       <Spinner />
     </div>
   </>
 );

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
        {myPokemon.length === 0 ? (
          <div className="mt-4">No pokemon in party currently!</div>
        ) : (
          <Table>
            <tbody>
              {myPokemon.map((userPokemon, index) => (
                <tr key={index}>
                  <td className="text-bg-dark">#{index + 1}</td>
                  <td className="text-bg-dark">
                    <img
                      src={userPokemon.pokemon.image}
                      alt=""
                      style={{
                        width: '30px',
                        height: '30px',
                      }}
                    />
                  </td>
                  <td className="text-bg-dark">
                    <div
                      role="button"
                      className="myPokemon_listItem"
                      onClick={() => navigate(`/mypokemon/${userPokemon.id}`)}
                    >
                      {userPokemon.nickName}
                    </div>
                  </td>
                  <td className="text-bg-dark">
                    <div>Lvl. {userPokemon.level}</div>
                  </td>
                  <td className="text-bg-dark">
                    <div className="d-flex gap-1">
                      <div>
                        <EditPokemon
                          userPokemon={userPokemon}
                          allPokemon={allPokemon}
                          getMyPokemon={getMyPokemon}
                        />
                      </div>
                      <div>
                        <DeletePokemon
                          getMyPokemon={getMyPokemon}
                          userPokemon={userPokemon}
                        />
                      </div>
                    </div>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        )}
      </Container>
    </>
  );
};
