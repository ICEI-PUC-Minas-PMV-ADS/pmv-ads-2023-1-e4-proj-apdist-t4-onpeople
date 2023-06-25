import api from './Api';

const getCargos = async () => {
    try {
        const response = await api.get(`/Cargos/${0}/Dashboard`);
        const { data } = response;

        if (response.status == 200) {
            const { countCargos,
                countCargosAtivos } = data;

            return {
                countCargos,
                countCargosAtivos
            };
        }

        if (response.status !== 200) {
            throw new Error('Erro ao obter as filiais');
        }
    } catch (error) {
        throw error;
    }
};


export { getCargos };
