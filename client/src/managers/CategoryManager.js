const _apiUrl = '/api/category';

export const fetchAllCategories = () => {
  return fetch(_apiUrl).then((res) => res.json());
};