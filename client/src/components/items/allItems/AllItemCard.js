import { Card, CardBody, CardSubtitle, CardTitle } from 'reactstrap';
import { useNavigate } from 'react-router-dom';
import { calculateAverageReviewScore } from '../../utilities/averageReviewScore.js';
import { ConvertRatingToIcons } from '../../utilities/CovertRatingToIcons.js';

export const AllItemCard = ({ item }) => {
  const navigate = useNavigate();

  return (
    <>
      <Card
        onClick={() => navigate(`${item.id}`)}
        color="dark"
        inverse
        className="rounded-0"
        style={{
          width: '12rem',
          marginTop: '15px',
          cursor: 'pointer',
        }}
      >
        <img
          alt="Sample"
          src={item.image}
        />
        <CardBody>
          <CardTitle tag="h5">
            <span>{item.name}</span>
            {item.move ? <div className="small">{item.move.name}</div> : ''}
          </CardTitle>
          <CardSubtitle
            className="mb-2"
            style={{}}
          >
            P{item.cost}
          </CardSubtitle>
          {item.reviews.length > 0 ? (
            <div className="d-flex gap-1">
              <div>{`(${item.reviews.length})`}</div>
              <ConvertRatingToIcons
                rating={calculateAverageReviewScore(item.reviews)}
              />
            </div>
          ) : (
            <div>No Reviews</div>
          )}
        </CardBody>
      </Card>
    </>
  );
};
