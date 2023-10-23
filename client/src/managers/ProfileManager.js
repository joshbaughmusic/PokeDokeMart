const _apiUrl = '/api/userprofile';

export const fetchCurrentUserProfile = () => {
  return fetch(`${_apiUrl}/me`).then(res => res.json());
};
