import { useEffect, useState } from 'react';
import { fetchSuggestedItemsBySingleUserPokemon } from '../../../managers/ItemsManager.js';
import { Container, Spinner } from 'reactstrap';
import { SuggestedItemsCardPokeDetails } from './SuggestedItemCardPokeDetails.js';

export const SuggestedItemsPokeDetails = ({ userPokemon }) => {
  const [suggestedItems, setSuggestedItems] = useState();

  const getSuggestedItemsBySingleUserPokemon = () => {
    fetchSuggestedItemsBySingleUserPokemon(userPokemon.id, 6).then(
      setSuggestedItems
    );
  };

  useEffect(() => {
    getSuggestedItemsBySingleUserPokemon();
  }, []);

  if (!suggestedItems) {
    return <Spinner />;
  }

  return (
    <>
      <Container>
        <h3 className="text-center mt-3">
          Suggested items for {userPokemon.nickName}:
        </h3>
        <div className="d-flex justify-content-center flex-wrap gap-3">
          {suggestedItems.map((i, index) => (
            <SuggestedItemsCardPokeDetails
              item={i}
              index={index}
            />
          ))}
        </div>
      </Container>
    </>
  );
};
