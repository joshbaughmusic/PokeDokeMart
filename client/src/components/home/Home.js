import { Container } from 'reactstrap';
import './Home.css';
import { SuggestedItemsHome } from '../items/suggestedItems/SuggestedItemsHome.js';

export const Home = ({loggedInUser}) => {
  return (
    <>
      <Container>
        <div className="d-flex flex-column mt-5 align-items-center">
          <h1 className="display-1 text-center">Welcome to PokeDokeMart!</h1>
          <SuggestedItemsHome loggedInUser={loggedInUser} />
        </div>
      </Container>
    </>
  );
};
