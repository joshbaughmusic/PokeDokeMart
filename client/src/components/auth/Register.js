import { useEffect, useState } from 'react';
import { register } from '../../managers/authManager';
import { Link, useNavigate } from 'react-router-dom';
import {
  Button,
  FormFeedback,
  FormGroup,
  Input,
  Label,
  Spinner,
} from 'reactstrap';
import { fetchAllCities, fetchCitiesByRegionId } from '../../managers/CityManager.js';
import { fetchAllRegions } from '../../managers/RegionManager.js';

export default function Register({ setLoggedInUser }) {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [userName, setUserName] = useState('');
  const [email, setEmail] = useState('');
  const [address, setAddress] = useState('');
  const [cityId, setCityId] = useState(null);
  const [regionId, setRegionId] = useState(null);
  const [cities, setCities] = useState(null);
  const [regions, setRegions] = useState(null);
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [errors, setErrors] = useState({});

  const [passwordMismatch, setPasswordMismatch] = useState();

  const navigate = useNavigate();

  useEffect(() => {
    fetchAllRegions().then(setRegions);
    fetchAllCities().then(setCities);
  }, []);

  const getCitiesByRegionId = (id) => {
    fetchCitiesByRegionId(id).then(setCities);
  };

    useEffect(() => {
      if (regionId && regionId !== null) {
        getCitiesByRegionId(regionId);
      }
    }, [regionId]);

  const handleSubmit = (e) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      setPasswordMismatch(true);
    } else {
      const newUser = {
        firstName,
        lastName,
        userName,
        email,
        address,
        password,
        cityId,
        regionId,
      };
      register(newUser).then((res) => {
        if (res.errors) {
          setErrors(res.errors);
        } else {
          setLoggedInUser(res);
          navigate('/');
        }
      });
    }
  };

  if (!regions || !cities) {
    return <Spinner />;
  }

  return (
    <div
      className="container"
      style={{ maxWidth: '500px' }}
    >
      <div style={{ color: 'red' }}>
        {Object.keys(errors).map((key) => (
          <p key={key}>
            {key}: {errors[key].join(',')}
          </p>
        ))}
      </div>
      <h3>Sign Up</h3>
      <FormGroup>
        <Label>First Name</Label>
        <Input
          className="rounded-0"
          type="text"
          value={firstName}
          onChange={(e) => {
            setFirstName(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Last Name</Label>
        <Input
          className="rounded-0"
          type="text"
          value={lastName}
          onChange={(e) => {
            setLastName(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Email</Label>
        <Input
          className="rounded-0"
          type="email"
          value={email}
          onChange={(e) => {
            setEmail(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>User Name</Label>
        <Input
          className="rounded-0"
          type="text"
          value={userName}
          onChange={(e) => {
            setUserName(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Address</Label>
        <Input
          className="rounded-0"
          type="text"
          value={address}
          onChange={(e) => {
            setAddress(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Region</Label>
        <Input
          value={regionId}
          onChange={(e) => {
            setRegionId(e.target.value);
          }}
          type="select"
          placeholder="Region"
          className="rounded-0"
        >
          <option
            value={null}
            disabled={regionId !== null}
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
      </FormGroup>
      <FormGroup>
        <Label>City</Label>

        {regionId && cities ? (
          <Input
            type="select"
            value={cityId}
            onChange={(e) => {
              setCityId(e.target.value);
            }}
            placeholder="City"
            className="rounded-0"
          >
            <option
              value={null}
              disabled={cityId !== ''}
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
        ) : (
          <Input
            type="select"
            value={cityId}
            onChange={(e) => {
              setCityId(e.target.value);
            }}
            placeholder="City"
            className="rounded-0"
            disabled
          >
            <option value={null}>City</option>
          </Input>
        )}
      </FormGroup>
      <FormGroup>
        <Label>Password</Label>
        <Input
          className="rounded-0"
          invalid={passwordMismatch}
          type="password"
          value={password}
          onChange={(e) => {
            setPasswordMismatch(false);
            setPassword(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label> Confirm Password</Label>
        <Input
          className="rounded-0"
          invalid={passwordMismatch}
          type="password"
          value={confirmPassword}
          onChange={(e) => {
            setPasswordMismatch(false);
            setConfirmPassword(e.target.value);
          }}
        />
        <FormFeedback>Passwords do not match!</FormFeedback>
      </FormGroup>
      <Button
        className="rounded-0"
        onClick={handleSubmit}
        disabled={passwordMismatch}
      >
        Register
      </Button>
      <p>
        Already signed up? Log in <Link to="/login">here</Link>
      </p>
    </div>
  );
}
