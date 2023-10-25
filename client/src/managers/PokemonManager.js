const _apiUrl = '/api/pokemon';

export const fetchAllPokemon = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const fetchMyPokemon = () => {
  return fetch(`${_apiUrl}/mypokemon`).then((res) => res.json());
};

export const fetchSingleUserPokemon = (id) => {
  return fetch(`${_apiUrl}/mypokemon/${id}`).then((res) => res.json());
};

export const fetchCreateNewUserPokemon = (userPokemon) => {
  return fetch(_apiUrl, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(userPokemon),
  }).then((res) => res.json());
};

export const fetchUpdateUserPokemon = (userPokemon) => {
  return fetch(_apiUrl, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(userPokemon),
  })
};
