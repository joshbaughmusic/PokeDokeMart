import { useEffect, useState } from 'react';
import {
  Button,
  Form,
  FormGroup,
  Input,
  Spinner,
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter,
} from 'reactstrap';
import { fetchAllRegions } from '../../managers/RegionManager.js';
import { fetchCitiesByRegionId } from '../../managers/CityManager.js';
import { fetchCreateNewOrder } from '../../managers/OrderManager.js';
import { useNavigate } from 'react-router-dom';

export const CheckoutForm = ({ cartItems }) => {
  const [regions, setRegions] = useState();
  const [cities, setCities] = useState();
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);
  const [newOrderUrl, setNewOrderUrl] = useState()
  const navigate = useNavigate()
  const [info, setInfo] = useState({
    firstName: '',
    middleInitial: '',
    lastName: '',
    address: '',
    regionId: '',
    cityId: '',
    cardNumber: '',
    cardMonth: '',
    cardYear: '',
    cardCVC: '',
  });

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
    if (info.regionId && info.regionId !== null) {
      getCitiesByRegionId(info.regionId);
    }
  }, [info.regionId]);

  const handleChange = (e) => {
    setInfo({
      ...info,
      [e.target.name]: e.target.value,
    });
  };

  const handleCompleteOrder = () => {
    const newOrderItems = cartItems.map((i) => {
      return {
        itemId: i.id,
        quantity: i.quantity,
        item: i
      };
    });
    const orderObject = {
      ...info,
      orderItems: newOrderItems,
    };
    fetchCreateNewOrder(orderObject).then(res => {
        toggle();
        setNewOrderUrl(`/order/${res.id}`);
    });
  };

  if (!regions) {
    return <Spinner />;
  }
  return (
    <>
      <div>
        <Modal
          isOpen={modal}
          toggle={toggle}
          onClosed={() => navigate(newOrderUrl)}
          className="rounded-0"
        >
          <ModalHeader toggle={toggle}>Success!</ModalHeader>
          <ModalBody>Order placed successfully!</ModalBody>
        </Modal>
      </div>
      <div>
        <Form>
          <p> Info:</p>
          <FormGroup className="d-flex gap-2">
            <Input
              name="firstName"
              value={info.firstName}
              onChange={handleChange}
              placeholder="First Name"
              className="rounded-0"
            />
            <Input
              name="middleInitial"
              value={info.middleInitial}
              onChange={handleChange}
              placeholder="MI (optional)"
              maxLength="1"
              className="rounded-0"
            />
            <Input
              name="lastName"
              value={info.lastName}
              onChange={handleChange}
              placeholder="Last Name"
              className="rounded-0"
            />
          </FormGroup>
          <FormGroup>
            <Input
              name="address"
              value={info.Addres}
              onChange={handleChange}
              placeholder="Address"
              className="rounded-0"
            />
          </FormGroup>
          <FormGroup className="d-flex gap-2">
            <Input
              name="regionId"
              value={info.regionId}
              onChange={handleChange}
              type="select"
              placeholder="Region"
              className="rounded-0"
            >
              <option
                value={null}
                disabled={info.regionId !== ''}
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
            {info.regionId && cities ? (
              <Input
                name="cityId"
                type="select"
                value={info.cityId}
                onChange={handleChange}
                placeholder="City"
                className="rounded-0"
              >
                <option
                  value={null}
                  disabled={info.cityId !== ''}
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
                name="cityId"
                type="select"
                value={info.cityId}
                onChange={handleChange}
                placeholder="City"
                className="rounded-0"
                disabled
              >
                <option value={null}>City</option>
              </Input>
            )}
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
              className="rounded-0"
              maxLength="16"
            />
          </FormGroup>
          <FormGroup className="d-flex gap-2">
            <Input
              name="cardMonth"
              value={info.cardMonth}
              onChange={handleChange}
              placeholder="MM"
              className="rounded-0"
              maxLength="2"
            />
            <Input
              name="cardYear"
              value={info.cardYear}
              onChange={handleChange}
              placeholder="YY"
              className="rounded-0"
              maxLength="2"
            />
            <Input
              name="cardCVC"
              value={info.cardCVC}
              onChange={handleChange}
              placeholder="CVC"
              className="rounded-0"
              maxLength="3"
            />
          </FormGroup>
        </Form>
      </div>
      <Button
        className="rounded-0"
        onClick={handleCompleteOrder}
      >
        Complete Purchase
      </Button>
    </>
  );
};
