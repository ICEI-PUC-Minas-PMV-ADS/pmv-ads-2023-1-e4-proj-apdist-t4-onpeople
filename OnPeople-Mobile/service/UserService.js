
import api from './Api';

const getUserProfile = async (userId) => {
    try {
        const response = await api.get(`Funcionarios?PageNumber=1&PageSize=1&userId=${userId}`);
        const { data } = response;
        console.info(response);

        if (data.length > 0) {
            const { nomeCompleto, cargo: { nomeCargo }, departamento: { nomeDepartamento }, empresa: { razaoSocial }, dataAdmissao } = data[0];

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
