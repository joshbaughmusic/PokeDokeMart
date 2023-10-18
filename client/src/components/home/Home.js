import PDMWelcome from '../../images/PDMWelcome.png';
import './Home.css';

export const Home = () => {
  return (
    <>
      <div className="container">
        <div className="d-flex mt-5 justify-content-center">
          <img
            className="w-75"
            src={PDMWelcome}
            alt="Welcome to PokeDokeMart!"
          />
        </div>
      </div>
    </>
  );
};
