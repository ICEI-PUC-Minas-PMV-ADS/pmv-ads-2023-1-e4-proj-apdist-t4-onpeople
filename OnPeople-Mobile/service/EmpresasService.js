import api from './Api';

const getEmpresas = async () => {
    try {
        const response = await api.get('/Empresas?PageNumber=1&PageSize=50');
        return response.data;
    } catch (error) {
        throw error;
    }
};

const getNumeroEmpresasAtivas = async () => {
    try {
        const empresas = await getEmpresas();
        const empresasAtivas = empresas.filter((empresa) => empresa.ativa);

        return empresasAtivas.length;
    } catch (error) {
        console.error('Erro ao obter o número de empresas ativas:', error);
        throw error;
    }
};

const getFiliais = async () => {
    try {
        const response = await api.get('/Empresas/0/Dashboard');
        if (!response.ok) {
            throw new Error('Erro ao obter as filiais');
        }
        const data = await response.json();
        const { countFiliais } = data;
        return countFiliais;
    } catch (error) {
        throw error;
    }
};


export { getEmpresas, getNumeroEmpresasAtivas, getFiliais };
