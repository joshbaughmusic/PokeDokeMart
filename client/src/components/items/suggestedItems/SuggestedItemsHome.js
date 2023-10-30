import { useEffect, useState } from 'react';
import { fetchSuggestedItemsByUser } from '../../../managers/ItemsManager.js';
import { Spinner } from 'reactstrap';
import { SuggestedItemsCarouselHome } from './SuggestedItemsCarouselHome.js';

export const SuggestedItemsHome = ({ loggedInUser }) => {
  const [suggestedItems, setSuggestedItems] = useState();

  const getSuggestedItemsByUser = () => {
    fetchSuggestedItemsByUser(loggedInUser.id, 12).then(setSuggestedItems);
  };

  useEffect(() => {
    getSuggestedItemsByUser();
  }, []);

  if (!suggestedItems) {
    return <Spinner />;
  }

  return (
    <>
      <h3 className="suggested-items-heading text-center">Suggested items for you:</h3>
      {suggestedItems.length === 0 ? (
        <div className='text-center mt-5'>
          Add some pokemon to your profile to receive personalized item
          suggestions!
        </div>
      ) : (
        <SuggestedItemsCarouselHome items={suggestedItems} />
      )}
    </>
  );
};
