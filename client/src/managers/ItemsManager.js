const _apiUrl = "/api/item"

export const fetchAllItems = () => {
    return fetch(_apiUrl).then(res => res.json())
}

export const fetchItemsByCategoryId = (cateogryId) => {
    return fetch(`${_apiUrl}?categoryId=${cateogryId}`).then(res => res.json())
}

export const fetchSingleItem = (id) => {
    return fetch(`${_apiUrl}/${id}`).then(res => res.json())
}