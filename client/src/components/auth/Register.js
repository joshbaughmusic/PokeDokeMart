import { useState } from 'react';
import { register } from '../../managers/authManager';
import { Link, useNavigate } from 'react-router-dom';
import { Button, FormFeedback, FormGroup, Input, Label } from 'reactstrap';

export default function Register({ setLoggedInUser }) {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [userName, setUserName] = useState('');
  const [email, setEmail] = useState('');
  const [address, setAddress] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [errors, setErrors] = useState({});

  const [passwordMismatch, setPasswordMismatch] = useState();

  const navigate = useNavigate();

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
      };
      register(newUser).then((res) => {
        if (res.errors) {
          setErrors(res.errors)
        } else {
          setLoggedInUser(res);
          navigate('/');
        }
      });
    }
  };

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
