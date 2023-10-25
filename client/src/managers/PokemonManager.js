const _apiUrl = '/api/pokemon';

export const fetchMyPokemon = () => {
  return fetch(`${_apiUrl}/mypokemon`).then((res) => res.json());
};

export const fetchSingleUserPokemon = (id) => {
  return fetch(`${_apiUrl}/mypokemon/${id}`).then((res) => res.json());
};
