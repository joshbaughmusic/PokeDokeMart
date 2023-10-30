import { useEffect, useState } from 'react';
import { fetchCurrentUserProfile } from '../../managers/ProfileManager.js';
import { Col, Container, Row, Spinner } from 'reactstrap';
import { MyOrders } from './MyOrders.js';
import { EditUserDetails } from './EditUserDetails.js';
import { ProfileAllReviews } from '../reviews/ProfileAllReviews.js';
import { MyPokemonList } from '../pokemon/MyPokemonList.js';
import PersonSprite from '../../images/personsprite.png';
import './Profile.css';

export const Profile = ({ loggedInUser }) => {
  const [profile, setProfile] = useState();

  const getCurrentUserProfile = () => [
    fetchCurrentUserProfile().then(setProfile),
  ];

  useEffect(() => {
    getCurrentUserProfile();
  }, []);

  if (!profile) {
    return (
      <>
        <div className="d-flex justify-content-center h-75 align-items-center">
          <Spinner />
        </div>
      </>
    );
  }
  return (
    <>
      <Container className="text-bg-dark my-5 p-5 profile-container">
        <Row className='mb-4'>
          <Col className="d-flex gap-4 align-items-center h-100">
            <div className="profile-details p-4">
              <h1 className="profile-heading">
                {profile.firstName} {profile.lastName}
              </h1>
              <div className="d-flex align-items-center gap-4">
                <div>
                  {profile.profilePictureUrl ? (
                    <img
                      className="profile-image"
                      src={profile.profilePictureUrl}
                      alt=""
                      style={{
                        width: '210px',
                        height: '210px',
                        objectFit: 'cover',
                      }}
                    />
                  ) : (
                    <img
                      className="profile-image"
                      src={PersonSprite}
                      alt=""
                      style={{
                        width: '200px',
                        height: '200px',
                        objectFit: 'cover',
                      }}
                    />
                  )}
                </div>
                <div>
                  <div className="d-flex justify-content-between align-items-baseline">
                    <h5>Details:</h5>
                    <EditUserDetails
                      profile={profile}
                      getCurrentUserProfile={getCurrentUserProfile}
                    />
                  </div>
                  <div className="pt-3">
                    <p>Email: {profile.email}</p>
                    <p>Street: {profile.address}</p>
                    <p>
                      C/R: {profile.city.name}, {profile.region.name}
                    </p>
                  </div>
                </div>
              </div>
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

//code for initials if blank pic instead

// <div className='d-flex justify-content-center align-items-center'
//   alt=""
//   style={{
//     width: '200px',
//     height: '200px',
//     objectFit: 'cover',
//     border: 'solid lightgrey 3px',
//   }}
// >
//   <h1 className='display-3'>
//     {profile.firstName.slice(0, 1)}.
//     {profile.lastName.slice(0, 1)}.
//   </h1>
// </div>
