const _apiUrl = "/api/item"

export const fetchAllItems = () => {
    return fetch(_apiUrl).then(res => res.json())
}

export const fetchItemsByCategoryId = (cateogryId) => {
    return fetch(`${_apiUrl}?categoryId=${cateogryId}`).then(res => res.json())
}

export const fetchSingleItem = (itemId) => {
    return fetch(`${_apiUrl}/${itemId}`).then(res => res.json())
}

export const fetchRelatedItems = (itemId, amount = null) => {
  let apiUrl = `${_apiUrl}/${itemId}/related`;

  // Check if the "amount" parameter is provided and add it to the URL if it's not null
  if (amount !== null) {
    apiUrl += `?amount=${amount}`;
  }

  return fetch(apiUrl).then((res) => res.json());
};

