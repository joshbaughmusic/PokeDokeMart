import { useEffect, useState } from 'react';
import { fetchSuggestedItemsByUser } from '../../../managers/ItemsManager.js';
import { Spinner } from 'reactstrap';
import { SuggestedItemsCarouselHome } from './SuggestedItemsCarouselHome.js';
import PokeballLoading from '../../../images/pokeball-loading.gif';
import { useNavigate } from 'react-router-dom';

export const SuggestedItemsHome = ({ loggedInUser }) => {
  const [suggestedItems, setSuggestedItems] = useState();
  const navigate = useNavigate()

  const getSuggestedItemsByUser = () => {
    fetchSuggestedItemsByUser(loggedInUser.id, 12).then(setSuggestedItems);
  };

  useEffect(() => {
    getSuggestedItemsByUser();
  }, []);

  if (!suggestedItems) {
    return (
      <>
        <div className="d-flex justify-content-center h-75 align-items-center">
          <img
            style={{
              width: '200px',
              marginTop: "80px"
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
      <h3 className="suggested-items-heading text-center">
        Suggested items for you:
      </h3>
      {suggestedItems.length === 0 ? (
        <div className="text-center mt-5">
          Add some pokemon to your <span role="button" className='suggested-items-profile-link' onClick={() => navigate("/profile")}>profile</span> to receive personalized
          item suggestions!
        </div>
      ) : (
        <SuggestedItemsCarouselHome items={suggestedItems} />
      )}
    </>
  );
};
