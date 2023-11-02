import { Container } from 'reactstrap';
import './Home.css';
import { SuggestedItemsHome } from '../items/suggestedItems/SuggestedItemsHome.js';
import Pokeball from '../../images/pokeball_review_icon.png';
import { useEffect, useState } from 'react';

export const Home = ({ loggedInUser }) => {
  const text = 'Welcome to PokeDokeMart!';
  const [displayedText, setDisplayedText] = useState('');
  const [index, setIndex] = useState(0);

  useEffect(() => {
    const interval = setInterval(() => {
      if (index <= text.length) {
        setDisplayedText(text.slice(0, index));
        setIndex((prevIndex) => prevIndex + 1);
      }
      if (index > text.length) {
        clearInterval(interval);
      }
    }, 80);

    return () => {
      clearInterval(interval);
    };
  }, [index, text]);

  console.log(text.length);
  console.log(index);

  return (
    <>
      <Container>
        {localStorage.getItem('seenAnimation') ? (
          <div className="d-flex flex-column align-items-center justify-content-between">
            <h1 className="display-1 text-center home-heading">
              Welcome to PokeDokeMart!
            </h1>

            <SuggestedItemsHome loggedInUser={loggedInUser} />
          </div>
        ) : (
          <div className="d-flex flex-column align-items-center justify-content-between">
            <h1 className="display-1 text-center home-heading">
              {displayedText}
            </h1>
            {index - 1 === text.length ? (
              <SuggestedItemsHome loggedInUser={loggedInUser} />
            ) : (
              ''
            )}
          </div>
        )}
      </Container>
    </>
  );
};
