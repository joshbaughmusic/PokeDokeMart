import { useEffect, useState } from 'react';
import { fetchRelatedItems } from '../../../managers/ItemsManager.js';
import { Spinner } from 'reactstrap';
import { AlsoConsiderCarousel } from './AlsoConsiderCarousel.js';

export const AlsoConsiderSection = ({ item }) => {
  const [relatedItems, setRelatedItems] = useState();

  const getRelatedItems = () => {
    //add an int as a second param to control how many items are returned. If left with no second param, will default to 3 items.
    fetchRelatedItems(item.id, 5).then(setRelatedItems);
  };

  useEffect(() => {
    getRelatedItems();
  }, [item]);

  if (!relatedItems) {
    return (
      <>
        <div className="d-flex justify-content-center h-75 align-items-center">
          <Spinner />
        </div>
      </>
    );
  }
  return (
    <>
      <div className='mt-5'>
        <h5 className='mb-3'>Also Consider:</h5>
          <AlsoConsiderCarousel relatedItems={relatedItems} />
      </div>
    </>
  );
};
