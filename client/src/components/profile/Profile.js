import { useEffect, useState } from 'react';
import { fetchCurrentUserProfile } from '../../managers/ProfileManager.js';
import { Col, Container, Row, Spinner } from 'reactstrap';
import { MyOrders } from './MyOrders.js';
import { EditUserDetails } from './EditUserDetails.js';
import { ProfileAllReviews } from '../reviews/ProfileAllReviews.js';
import { MyPokemonList } from '../pokemon/MyPokemonList.js';

export const Profile = ({ loggedInUser }) => {
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
      <Container className="text-bg-dark my-5 p-4">
        <h1 className="mb-3">
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
                <EditUserDetails
                  profile={profile}
                  getCurrentUserProfile={getCurrentUserProfile}
                />
              </div>
              <Container className="border border-light p-3 ">
                <p>{profile.email}</p>
                <p>{profile.address}</p>
                <p>
                  {profile.city.name}, {profile.region.name}
                </p>
              </Container>
            </div>
          </Col>
          <Col>
            <MyPokemonList />
          </Col>
        </Row>
        <Row>
          <Col>
            <MyOrders orders={profile.orders} />
          </Col>
        </Row>
        <Row>
          <Col>
            <ProfileAllReviews loggedInUser={loggedInUser} />
          </Col>
        </Row>
      </Container>
    </>
  );
};
