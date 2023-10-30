import { useEffect, useState } from 'react';
import {
  Button,
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter,
  Form,
  FormGroup,
  Label,
  Input,
  Spinner,
  Alert,
} from 'reactstrap';
import { fetchAllRegions } from '../../managers/RegionManager.js';
import { fetchCitiesByRegionId } from '../../managers/CityManager.js';
import { fetchUpdateUserProfile } from '../../managers/ProfileManager.js';

export const EditUserDetails = ({ profile, getCurrentUserProfile }) => {
  const [updatedUserProfile, setUpdatedUserProfile] = useState({
    id: profile.id,
    email: profile.email,
    firstName: profile.firstName,
    lastName: profile.lastName,
    address: profile.address,
    cityId: profile.cityId,
    regionId: profile.regionId,
    profilePictureUrl: profile.profilePictureUrl
  });
  const [cities, setCities] = useState();
  const [regions, setRegions] = useState();
  const [visibleError, setVisibleError] = useState(false);
  const [visibleSuccess, setVisibleSuccess] = useState(false);
  const [disabled, setDisabled] = useState(false);
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);
  const onDismissError = () => setVisibleError(false);

  const getAllRegions = () => {
    fetchAllRegions().then(setRegions);
  };

  const getCitiesByRegionId = (id) => {
    fetchCitiesByRegionId(id).then(setCities);
  };

  useEffect(() => {
    getAllRegions();
  }, []);

  useEffect(() => {
    if (updatedUserProfile.regionId && updatedUserProfile.regionId !== null) {
      getCitiesByRegionId(updatedUserProfile.regionId);
    }
  }, [updatedUserProfile.regionId]);

  const handleChange = (e) => {
    setUpdatedUserProfile({
      ...updatedUserProfile,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = () => {
    if (
      updatedUserProfile.firstName &&
      updatedUserProfile.lastName &&
      updatedUserProfile.email &&
      updatedUserProfile.address &&
      updatedUserProfile.regionId &&
      updatedUserProfile.cityId
    ) {
      fetchUpdateUserProfile(updatedUserProfile).then(() => {
        getCurrentUserProfile();
        setDisabled(true)
        setVisibleSuccess(true);
        setTimeout(() => {
          toggle();
          setDisabled(false)
        }, 2000);
      });
    } else {
      setVisibleError(true);
    }
  };

  if (!regions || !cities) {
    return <Spinner />;
  }

  return (
    <>
      <Button
        onClick={toggle}
        className="rounded-0"
      >
        Edit
      </Button>
      <Modal
        isOpen={modal}
        toggle={toggle}
        className="rounded-0"
        onClosed={() => {
          setVisibleSuccess(false);
          setVisibleError(false);
        }}
        backdrop="static"
        centered={true}
      >
        <ModalHeader
          toggle={toggle}
          close={<span></span>}
        >
          Edit Your Details:
        </ModalHeader>
        <ModalBody>
          <Form>
            <FormGroup>
              <Label>Email</Label>
              <Input
                name="email"
                value={updatedUserProfile.email}
                onChange={handleChange}
                className="rounded-0"
              />
            </FormGroup>
            <FormGroup>
              <Label>First Name</Label>
              <Input
                name="firstName"
                value={updatedUserProfile.firstName}
                onChange={handleChange}
                className="rounded-0"
              />
            </FormGroup>
            <FormGroup>
              <Label>Last Name</Label>
              <Input
                name="lastName"
                value={updatedUserProfile.lastName}
                onChange={handleChange}
                className="rounded-0"
              />
            </FormGroup>
            <FormGroup>
              <Label>Address</Label>
              <Input
                name="address"
                value={updatedUserProfile.address}
                onChange={handleChange}
                className="rounded-0"
              />
            </FormGroup>
            <FormGroup>
              <>
                <Label>Region</Label>
                <Input
                  name="regionId"
                  value={updatedUserProfile.regionId}
                  onChange={handleChange}
                  type="select"
                  className="rounded-0"
                >
                  <option
                    value={null}
                    disabled={updatedUserProfile.regionId !== null}
                  >
                    Region
                  </option>
                  {regions.map((r, index) => (
                    <option
                      key={index}
                      value={r.id}
                    >
                      {r.name}
                    </option>
                  ))}
                </Input>
              </>
            </FormGroup>
            <FormGroup>
              <>
                <Label>City</Label>
                <Input
                  name="cityId"
                  type="select"
                  value={updatedUserProfile.cityId}
                  onChange={handleChange}
                  className="rounded-0"
                >
                  <option
                    value={null}
                    disabled={updatedUserProfile.cityId !== null}
                  >
                    City
                  </option>
                  {cities.map((c, index) => (
                    <option
                      key={index}
                      value={c.id}
                    >
                      {c.name}
                    </option>
                  ))}
                </Input>
              </>
            </FormGroup>
            <FormGroup>
              <Label>Profile Picture Url</Label>
              <Input
                name="profilePictureUrl"
                value={updatedUserProfile.profilePictureUrl}
                onChange={handleChange}
                className="rounded-0"
              />
            </FormGroup>
          </Form>
          <Alert
            color="danger"
            isOpen={visibleError}
            toggle={onDismissError}
            className="rounded-0 mt-3"
          >
            Please fill out all user details!
          </Alert>
          <Alert
            color="success"
            isOpen={visibleSuccess}
            className="rounded-0 mt-3"
          >
            Details changed!
          </Alert>
        </ModalBody>
        <ModalFooter>
          {disabled ? (
            <Button
              disabled
              onClick={handleSubmit}
              className="rounded-0"
            >
              Submit
            </Button>
          ) : (
            <Button
              onClick={handleSubmit}
              className="rounded-0"
            >
              Submit
            </Button>
          )}
          {disabled ? (
            <Button
              disabled
              onClick={() => {
                toggle();
                setUpdatedUserProfile({
                  email: profile.email,
                  firstName: profile.firstName,
                  lastName: profile.lastName,
                  address: profile.address,
                  cityId: profile.cityId,
                  regionId: profile.regionId,
                });
              }}
              className="rounded-0"
            >
              Cancel
            </Button>
          ) : (
            <Button
              onClick={() => {
                toggle();
                setUpdatedUserProfile({
                  email: profile.email,
                  firstName: profile.firstName,
                  lastName: profile.lastName,
                  address: profile.address,
                  cityId: profile.cityId,
                  regionId: profile.regionId,
                });
              }}
              className="rounded-0"
            >
              Cancel
            </Button>
          )}
        </ModalFooter>
      </Modal>
    </>
  );
};
