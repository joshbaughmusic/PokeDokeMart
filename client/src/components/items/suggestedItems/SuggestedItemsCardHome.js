import { Card, CardBody, CardSubtitle, CardTitle } from 'reactstrap';
import { useNavigate } from 'react-router-dom';
import { ConvertRatingToIcons } from '../../utilities/CovertRatingToIcons.js';
import { calculateAverageReviewScore } from '../../utilities/averageReviewScore.js';
import './SuggestedItemsHome.css';

export const SuggestedItemsCardHome = ({ item }) => {
  const navigate = useNavigate();

  return (
    <>
      <Card
        onClick={() => navigate(`/items/${item.id}`)}
        color="dark"
        inverse
        className="rounded-0 suggestedItemsCardHome item-card"
        style={{
          width: '12em',
          marginTop: '40px',
          cursor: 'pointer',
          marginBottom: '50px',
        }}
      >
        <img
          alt="Sample"
          src={item.image}
        />
        <CardBody className="d-flex flex-column justify-content-between">
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
    </>
  );
};
