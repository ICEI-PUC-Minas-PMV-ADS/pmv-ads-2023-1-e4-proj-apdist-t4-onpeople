import api from './Api';

const getEmpresas = async () => {
    try {
        const response = await api.get('/Empresas');
        return response.data;
    } catch (error) {
        throw error;
    }
};

const getNumeroEmpresasAtivas = async () => {
    try {
        const empresas = await getEmpresas(); // Reutiliza a função getEmpresas para obter os dados
        const empresasAtivas = empresas.filter((empresa) => empresa.ativa);

        return empresasAtivas.length;
    } catch (error) {
        console.error('Erro ao obter o número de empresas ativas:', error);
        throw error;
    }
};

export { getEmpresas, getNumeroEmpresasAtivas };