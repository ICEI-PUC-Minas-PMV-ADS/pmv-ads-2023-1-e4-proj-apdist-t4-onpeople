import api from './Api';

const login = async (userName, password) => {

    const loginData = {
        userName,
        password
    };

    try {
        const response = await api.post(`/Users/Login`, loginData);
        return response;
    } catch (error) {
        throw error;
    }
};

export default {
    login
};


