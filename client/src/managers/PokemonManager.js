const _apiUrl = '/api/pokemon';

export const fetchMyPokemon = () => {
  return fetch(`${_apiUrl}/mypokemon`).then((res) => res.json());
};
