import api from './Api';

var authToken = ''; // Variável para armazenar o token JWT

const login = async (userName, password) => {
    const loginData = {
        userName,
        password
    };


    try {
        const response = await api.post(`/Users/Login`, loginData);

        authToken = response.data.token; // Atualiza o valor do token
        api.defaults.headers.common['Authorization'] = `Bearer ${authToken}`;


        return response;
    } catch (error) {
        throw error;
    }
};

export default {
    login
};

