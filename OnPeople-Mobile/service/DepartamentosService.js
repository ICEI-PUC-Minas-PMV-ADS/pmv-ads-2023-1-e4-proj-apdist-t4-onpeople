import api from "./Api";

const getDepartamentos = async (userId) => {
    try {
        const response = await api.get(`/Departamentos/${0}/Dashboard`);
        const { data } = response;

        if (response.status == 200) {
            const { countDepartamentos,
                countDepartamentosAtivos } = data;

            return {
                countDepartamentos,
                countDepartamentosAtivos
            };
        }

        if (response.status !== 200) {
            throw new Error('Erro ao obter as filiais');
        }
    } catch (error) {
        throw error;
    }
};


export { getDepartamentos };
