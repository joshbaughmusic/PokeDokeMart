import { useEffect, useState } from 'react';
import { fetchSuggestedItemsByUser } from '../../../managers/ItemsManager.js';
import { Container, Spinner } from 'reactstrap';
import { SuggestedItemsCardHome } from './SuggestedItemsCardHome.js';

export const SuggestedItemsHome = ({ loggedInUser }) => {
  const [suggestedItems, setSuggestedItems] = useState();

  const getSuggestedItemsByUser = () => {
    fetchSuggestedItemsByUser(loggedInUser.id, 14).then(setSuggestedItems);
  };

  useEffect(() => {
    getSuggestedItemsByUser();
  }, []);

  if (!suggestedItems) {
    return <Spinner />;
  }

  return (
    <>
      <Container>
        <div className="d-flex justify-content-center flex-wrap gap-3">
          {suggestedItems.length === 0 ? (
            <div>
              Add some pokemon to your profile to receive personalized item
              suggestions!
            </div>
          ) : (
            suggestedItems.map((i, index) => (
              <SuggestedItemsCardHome
                item={i}
                index={index}
              />
            ))
          )}
        </div>
      </Container>
    </>
  );
};
