import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Card, CardBody, CardSubtitle, CardTitle, Carousel, CarouselControl, CarouselIndicators, CarouselItem } from "reactstrap";

export const AlsoConsiderCarousel = ({ relatedItems }) => {
  const [activeIndex, setActiveIndex] = useState(0);
  const [animating, setAnimating] = useState(false);
  const navigate = useNavigate()

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
      >
        <Card
          onClick={() => navigate(`/items/${item.id}`)}
          color="dark"
          key={index}
          inverse
          className="rounded-0 w-100 mt-2"
          role='button'
        >
          <img
            alt="Sample"
            src={item.image}
            className="w-75 align-self-center"
          />
          <CardBody className="d-flex flex-column align-items-center">
            <CardTitle tag="h6">
              <span>{item.name}</span>
              {item.move ? <div className="small">{item.move.name}</div> : ''}
            </CardTitle>
            <CardSubtitle
              className="mb-4"
              style={{fontSize: "15px"}}
            >
              P{item.cost}
            </CardSubtitle>
          </CardBody>
        </Card>
      </CarouselItem>
    );
  });
  return (
    <>
      <Carousel
        activeIndex={activeIndex}
        next={next}
        previous={previous}
        style={{
            width: "40%"
        }}
        
      >
        <CarouselIndicators
          items={relatedItems}
          activeIndex={activeIndex}
          onClickHandler={goToIndex}
        />
        {slides}
        <CarouselControl
          direction="prev"
          directionText="Previous"
          onClickHandler={previous}
        />
        <CarouselControl
          direction="next"
          directionText="Next"
          onClickHandler={next}
        />
      </Carousel>
    </>
  );
};