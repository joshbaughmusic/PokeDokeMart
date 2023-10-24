import { useState } from 'react';
import Pokeball from '../../images/pokeball_review_icon.png';
import PokeballOutline from '../../images/pokeball_review_icon_outline.png';
import './PokeRating.css';

export const PokeRating = ({rating, setRating}) => {
  const [hover, setHover] = useState(0);
  return (
    <div className="pokeball-rating">
      {[...Array(5)].map((pokeball, index) => {
        index += 1;
        return (
          <button
            type="button"
            key={index}
            className={
              index <= (hover || rating)
                ? 'on pokeRatingButton'
                : 'off pokeRatingButton'
            }
            onClick={() => setRating(index)}
            onMouseEnter={() => setHover(index)}
            onMouseLeave={() => setHover(rating)}
          >
            <span className="pokeball">
              <img
                src={index <= (hover || rating) ? Pokeball : PokeballOutline}
                alt=""
                style={{ width: '30px' }}
              />
            </span>
          </button>
        );
      })}
    </div>
  );
};
