import axios from "axios";

const baseURL = 'https://localhost:7222/graphql'

const instance = axios.create()

const getResource = async (data: string) => {
    try {
        const response = await instance(baseURL, {
            method: 'post',
            url: baseURL,
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data : data
        })
        return response.data
    } catch (error) {
        console.log(error);
    }
}

export default getResource;

