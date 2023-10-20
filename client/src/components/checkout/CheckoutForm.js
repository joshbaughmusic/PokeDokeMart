import { useState } from 'react';
import { Button, Form, FormGroup, Input } from 'reactstrap';

export const CheckoutForm = ({ cartItems }) => {
  const [info, setInfo] = useState({
    billingFirstName: '',
    billingMiddleInitial: '',
    billingLastName: '',
    billingAddress: '',
    billingCity: '',
    billingState: '',
    billingZip: '',
    cardNumber: '',
    cardMonth: '',
    cardYear: '',
    cardCVC: '',
  });
  const stateCodes = [
    'AL',
    'AK',
    'AS',
    'AZ',
    'AR',
    'CA',
    'CO',
    'CT',
    'DE',
    'DC',
    'FM',
    'FL',
    'GA',
    'GU',
    'HI',
    'ID',
    'IL',
    'IN',
    'IA',
    'KS',
    'KY',
    'LA',
    'ME',
    'MH',
    'MD',
    'MA',
    'MI',
    'MN',
    'MS',
    'MO',
    'MT',
    'NE',
    'NV',
    'NH',
    'NJ',
    'NM',
    'NY',
    'NC',
    'ND',
    'MP',
    'OH',
    'OK',
    'OR',
    'PW',
    'PA',
    'PR',
    'RI',
    'SC',
    'SD',
    'TN',
    'TX',
    'UT',
    'VT',
    'VI',
    'VA',
    'WA',
    'WV',
    'WI',
    'WY',
  ];

  const handleChange = (e) => {
    setInfo({
      ...info,
      [e.target.name]: e.target.value,
    });
  };

  const handleCompleteOrder = () => {
    const orderObject = {
        ...info,
        orderItems: [...cartItems]
    }
    
  }

  return (
    <>
      <div>
        <Form>
          <p>Billing Info:</p>
          <FormGroup className="d-flex gap-2">
            <Input
              name="billingFirstName"
              value={info.billingFirstName}
              onChange={handleChange}
              placeholder="First Name"
            />
            <Input
              name="billingMiddleInitial"
              value={info.billingMiddleInitial}
              onChange={handleChange}
              placeholder="MI (optional)"
            />
            <Input
              name="billingLastName"
              value={info.billingLastName}
              onChange={handleChange}
              placeholder="Last Name"
            />
          </FormGroup>
          <FormGroup>
            <Input
              name="billingAddres"
              value={info.billingAddres}
              onChange={handleChange}
              placeholder="Billing Address"
            />
          </FormGroup>
          <FormGroup className="d-flex gap-2">
            <Input
              name="billingCity"
              value={info.billingCity}
              onChange={handleChange}
              placeholder="City"
            />
            <Input
              name="billingState"
              value={info.billingState}
              onChange={handleChange}
              type="select"
              placeholder="State"
            >
              <option value={null}>State</option>
              {stateCodes.map((s, index) => (
                <option
                  key={index}
                  value={s}
                >
                  {s}
                </option>
              ))}
            </Input>
            <Input
              name="billingZip"
              value={info.billingZip}
              onChange={handleChange}
              placeholder="Zip Code"
            />
          </FormGroup>
        </Form>
      </div>
      <div>
        <Form>
          <p>Card Info:</p>
          <FormGroup>
            <Input
              name="cardNumber"
              value={info.careNumber}
              onChange={handleChange}
              placeholder="Card Number"
              maxLength="16"
            />
          </FormGroup>
          <FormGroup className="d-flex gap-2">
            <Input
              name="cardMonth"
              value={info.cardMonth}
              onChange={handleChange}
              placeholder="MM"
              maxLength="2"
            />
            <Input
              name="cardYear"
              value={info.cardYear}
              onChange={handleChange}
              placeholder="YY"
              maxLength="2"
            />
            <Input
              name="cardCVC"
              value={info.cardCVC}
              onChange={handleChange}
              placeholder="CVC"
              maxLength="3"
            />
          </FormGroup>
        </Form>
      </div>
      <Button onClick={handleCompleteOrder}>Complete Purchase</Button>
    </>
  );
};
