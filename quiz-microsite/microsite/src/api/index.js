import axios from 'axios'

export const BASE_URL = process.env.REACT_APP_Quiz_service

console.log("BASE_URL",BASE_URL);

export const ENDPOINTS = {
    participant: 'participants',
    question:'questions',
    getAnswers : 'questions/getanswers',
    getServiceSystemInfo : 'systeminfo'
}

export const createAPIEndpoint = endpoint => {

    let url = BASE_URL + 'api/' + endpoint + '/';
    return {
        fetch: () => axios.get(url),
        fetchById: id => axios.get(url + id),
        post: newRecord => axios.post(url, newRecord),
        put: (id, updatedRecord) => axios.put(url + id, updatedRecord),
        delete: id => axios.delete(url + id),
    }
}