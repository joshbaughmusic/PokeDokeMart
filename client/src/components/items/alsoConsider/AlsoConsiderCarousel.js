import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import {
  Card,
  CardBody,
  CardSubtitle,
  CardTitle,
  Carousel,
  CarouselControl,
  CarouselIndicators,
  CarouselItem,
} from 'reactstrap';
import { calculateAverageReviewScore } from '../../utilities/averageReviewScore.js';
import { ConvertRatingToIcons } from '../../utilities/CovertRatingToIcons.js';
import './AlsoConsiderCarousel.css';

export const AlsoConsiderCarousel = ({ relatedItems, setQuantity }) => {
  const [activeIndex, setActiveIndex] = useState(0);
  const [animating, setAnimating] = useState(false);
  const navigate = useNavigate();

  const next = () => {
    if (animating) return;
    const nextIndex =
      activeIndex === relatedItems.length - 1 ? 0 : activeIndex + 1;
    setActiveIndex(nextIndex);
  };

  const previous = () => {
    if (animating) return;
    const nextIndex =
      activeIndex === 0 ? relatedItems.length - 1 : activeIndex - 1;
    setActiveIndex(nextIndex);
  };

  const goToIndex = (newIndex) => {
    if (animating) return;
    setActiveIndex(newIndex);
  };

  const slides = relatedItems.map((item, index) => {
    return (
      <CarouselItem
        onExiting={() => setAnimating(true)}
        onExited={() => setAnimating(false)}
        key={index}
        style={{
          width: '15em',
        }}
        className="also-consider-carousel"
      >
        <Card
          onClick={() => {
            navigate(`/items/${item.id}`);
            setQuantity(1)
          }}
          color="dark"
          key={index}
          inverse
          className="rounded-0"
          role="button"
          style={{
            width: '15em',
            // height: '100%',
          }}
        >
          <img
            alt="Sample"
            src={item.image}
            className="w-75 align-self-center"
          />
          <CardBody className="d-flex flex-column justify-content-between text-center card-body pb-5">
            <div>
              <CardTitle tag="h5">
                <span className="card-item-name">{item.name}</span>
                {item.move ? (
                  <div className="card-move-name">{item.move.name}</div>
                ) : (
                  ''
                )}
              </CardTitle>
            </div>
            <div>
              <CardSubtitle
                className="mb-2"
                style={{}}
              >
                P{item.cost}
              </CardSubtitle>
              {item.reviews.length > 0 ? (
                <div className="d-flex gap-1 align-items-center justify-content-center">
                  <div>{`(${item.reviews.length})`}</div>
                  <ConvertRatingToIcons
                    rating={calculateAverageReviewScore(item.reviews)}
                  />
                </div>
              ) : (
                <div>No Reviews</div>
              )}
            </div>
          </CardBody>
        </Card>
      </CarouselItem>
    );
  });

  if (relatedItems.length === 0) {
    return (
      <>
        <div>No related items currently available!</div>
      </>
    );
  }
  return (
    <>
      <Carousel
        activeIndex={activeIndex}
        next={next}
        previous={previous}
        style={{
          width: '15em',
        }}
        className="also-consider-carousel"
      >
        <CarouselIndicators
          items={relatedItems}
          activeIndex={activeIndex}
          onClickHandler={goToIndex}
          className="px-3 "
        />
        {slides}
        <CarouselControl
          direction="prev"
          directionText="Previous"
          onClickHandler={previous}
          className="mb-4"
        />
        <CarouselControl
          direction="next"
          directionText="Next"
          onClickHandler={next}
          className="mb-4"
        />
      </Carousel>
    </>
  );
};
