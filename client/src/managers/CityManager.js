const _apiUrl = '/api/city';

export const fetchAllCities = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const fetchSingleCity = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const fetchCitiesByRegionId = (id) => {
  return fetch(`${_apiUrl}/region/${id}`).then((res) => res.json());
};
