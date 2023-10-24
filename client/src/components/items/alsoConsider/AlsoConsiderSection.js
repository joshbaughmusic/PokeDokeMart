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
    return <Spinner />;
  }
  return (
    <>
      <div className='mt-5'>
        <h5>Also Consider:</h5>
        {/* <ListGroup className='w-50'> */}
          {/* {relatedItems.map((i, index) => (
            <AlsoConsiderCard
              item={i}
              key={index}
            />
          ))} */}
          <AlsoConsiderCarousel relatedItems={relatedItems} />
        {/* </ListGroup> */}
      </div>
    </>
  );
};
