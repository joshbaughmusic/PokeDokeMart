const _apiUrl = '/api/review';

export const fetchAllReviews = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const fetchAllReviewsByUser = (userId) => {
  return fetch(`${_apiUrl}?userId=${userId}`).then((res) => res.json());
};

export const fetchAllReviewsForItem = (itemId) => {
  return fetch(`${_apiUrl}/item/${itemId}`).then((res) => res.json());
};

export const fetchSingleReview = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const fetchCreateNewReview = (ReviewObj) => {
  return fetch(_apiUrl, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(ReviewObj),
  }).then((res) => res.json());
};
