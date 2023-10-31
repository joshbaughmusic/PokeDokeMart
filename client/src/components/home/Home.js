import { Container } from 'reactstrap';
import './Home.css';
import { SuggestedItemsHome } from '../items/suggestedItems/SuggestedItemsHome.js';
import Pokeball from '../../images/pokeball_review_icon.png';

export const Home = ({loggedInUser}) => {
  return (
    <>
      <Container>
        <div className="d-flex flex-column align-items-center justify-content-between">
          <h1 className="display-1 text-center home-heading">Welcome to PokeDokeMart!</h1>
          
            <SuggestedItemsHome loggedInUser={loggedInUser} />
      
        </div>
      </Container>
    </>
  );
};
