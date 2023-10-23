const _apiUrl = '/api/userprofile';

export const fetchCurrentUserProfile = () => {
  return fetch(`${_apiUrl}/me`).then(res => res.json());
};

export const fetchUpdateUserProfile = (updatedUserProfile) => {
    return fetch(`${_apiUrl}/update`, {
        method: "PUT",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(updatedUserProfile)
    });
}