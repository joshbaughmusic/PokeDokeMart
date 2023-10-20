const _apiUrl = '/api/region';

export const fetchAllRegions = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const fetchSingleRegion = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};
