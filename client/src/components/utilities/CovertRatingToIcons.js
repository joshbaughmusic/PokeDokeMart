import Pokeball from '../../images/pokeball_review_icon.png';

export const ConvertRatingToIcons = ({ rating }) => {
  return (
    <>
      <div>
        {Array(rating)
          .fill(0)
          .map((obj, index) => (
            <img key={index}
              className="pokeballRatingIcon"
              src={Pokeball} style={{ width: "22px"}}
            />
          ))}
      </div>
    </>
  );
};
