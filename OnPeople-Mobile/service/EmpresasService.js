import api from './Api';

const getEmpresas = async () => {
    try {
        const response = await api.get(`/Empresas/${0}/Dashboard`);
        const { data } = response;

        if (response.status == 200) {
            const { countEmpresas,
                countEmpresasAtivas,
                countFiliais,
                countFiliaisAtivas } = data;

            return {
                countEmpresas,
                countEmpresasAtivas,
                countFiliais,
                countFiliaisAtivas
            };
        }

        if (response.status !== 200) {
            throw new Error('Erro ao obter as filiais');
        }
    } catch (error) {
        throw error;
    }
};


export { getEmpresas };
