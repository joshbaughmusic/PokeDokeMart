import PDMWelcome from '../../images/PDMWelcome.png';
import './Home.css';
import { HomeFeatureProductsCarousel } from './HomeFeaturedProductsCarousel.js';

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
        {/* <HomeFeatureProductsCarousel /> */}

      </div>
    </>
  );
};
