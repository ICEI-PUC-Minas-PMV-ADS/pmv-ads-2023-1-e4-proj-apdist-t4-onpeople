import api from './Api';

class LoginService {
    async login(email, password) {
        try {
            const response = await api.post('/Login', {
                email,
                password,
            });

            // Verifica se a resposta da API é bem-sucedida
            if (response.status === 200) {
                return response.data;
            } else {
                throw new Error('Erro ao efetuar login');
            }
        } catch (error) {
            throw new Error('Erro ao efetuar login');
        }
    }
}

export default LoginService;
