import { useEffect, useState } from 'react';
import { fetchCurrentUserProfile } from '../../managers/ProfileManager.js';
import { Button, Col, Container, Row, Spinner } from 'reactstrap';
import { MyOrders } from './MyOrders.js';

export const Profile = () => {
  const [profile, setProfile] = useState();

  const getCurrentUserProfile = () => [
    fetchCurrentUserProfile().then(setProfile),
  ];

  useEffect(() => {
    getCurrentUserProfile();
  }, []);

  if (!profile) {
    return <Spinner />;
  }
  return (
    <>
      <Container className="text-bg-dark">
        <h1 className="mt-5 mb-3">
          {profile.firstName} {profile.lastName}
        </h1>
        <Row>
          <Col className="d-flex gap-5">
            <div>
              <img
                src={profile.profilePictureUrl}
                alt=""
                style={{
                  width: '200px',
                  height: '200px',
                  objectFit: 'cover',
                }}
              />
            </div>
            <div>
              <div className="d-flex justify-content-between align-items-baseline">
                <h5>Details:</h5>
                <Button>Edit</Button>
              </div>
              <div className="border border-light">
                <p>{profile.email}</p>
                <p>{profile.address}</p>
                <p>{profile.city.name}</p>
                <p>{profile.region.name}</p>
              </div>
            </div>
          </Col>
          <Col>
            <div className="border border-light">My pokemon placeholder</div>
          </Col>
        </Row>
        <Row>
          <Col>
            <MyOrders orders={profile.orders} />
          </Col>
        </Row>
        <Row>
          <Col>
            <div className="mt-5 border border-light">
              My Reviews placeholder
            </div>
          </Col>
        </Row>
      </Container>
    </>
  );
};
