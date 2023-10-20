const _apiUrl = '/api/order';

export const fetchAllOrders = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const fetchSingleOrder = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const fetchOrdersByUserId = (id) => {
  return fetch(`${_apiUrl}/user/${id}`).then((res) => res.json());
};

export const fetchCreateNewOrder = (orderObj) => {
  return fetch(_apiUrl, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(orderObj),
  }).then((res) => res.json());
};
