import api from "./Api";

const getMetasByFuncionario = async (userId) => {

    try {
        let response = {};
        if (userId !== undefined) {
            response = await api.get(`/FuncionariosMetas/${userId}/dashboard`);

        } else {
            console.log(`O userId é ${userId}`);
        }

        if (response?.status === 200) {
            const { data } = response;
            const { countMetasAssociadas, countMetasCumpridas } = data;

            return {
                countMetasAssociadas,
                countMetasCumpridas
            };
        }
        else {

            throw new Error('Erro ao obter as metas do funcionário');
        }
    } catch (error) {
        throw new Error('Erro ao obter as metas do funcionário');
    }
}

// export default getMetasByFuncionario;

export { getMetasByFuncionario };