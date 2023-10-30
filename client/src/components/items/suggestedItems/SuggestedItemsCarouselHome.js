import { SuggestedItemsCardHome } from './SuggestedItemsCardHome.js';
import 'react-responsive-carousel/lib/styles/carousel.min.css';
import { Carousel } from 'react-responsive-carousel';


export const SuggestedItemsCarouselHome = ({ items }) => {
  return (
    <>
      <Carousel
        showThumbs={false}
        className="suggested-items-carousel"
      >
        <div>
          <div className="d-flex justify-content-center gap-3">
            {items.slice(0, 4).map((item, index) => {
              return (
                <SuggestedItemsCardHome
                  item={item}
                  key={index}
                />
              );
            })}
          </div>
        </div>
        <div>
          <div className="d-flex justify-content-center gap-3">
            {items.slice(4, 8).map((item, index) => {
              return (
                <SuggestedItemsCardHome
                  item={item}
                  key={index}
                />
              );
            })}
          </div>
        </div>
        <div>
          <div className="d-flex justify-content-center gap-3">
            {items.slice(8, 12).map((item, index) => {
              return (
                <SuggestedItemsCardHome
                  item={item}
                  key={index}
                />
              );
            })}
          </div>
        </div>
      </Carousel>
    </>
  );
};
