import api from './Api';

const getUserProfile = async (userId) => {
    try {
        const response = await api.get(`Funcionarios/${userId}`);
        const { data } = response;

        if (response.status == 200) {
            const { nomeCompleto, cargo: { nomeCargo }, departamento: { nomeDepartamento }, empresa: { razaoSocial },
                dataAdmissao } = data;

            return {
                nomeCompleto,
                nomeCargo,
                nomeDepartamento,
                razaoSocial,
                dataAdmissao,
            };
        } else {
            throw new Error('Usuário não encontrado');
        }
    } catch (error) {
        throw error;

    }
};

export { getUserProfile };
