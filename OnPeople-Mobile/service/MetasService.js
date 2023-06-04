import api from "./Api"

class MetasService {
    async getMetasByFuncionario(id) {
        try {
            const response = await api.get('/Funcionarios/{id}/Metas')

            if (response.status === 200) {
                return response.data;
            }
            else {
                throw new Error('Erro ao obter as metas do funcionário');
            }
        } catch (error) {
            throw new Error('Erro ao obter as metas do funcionário');
        }
    }
}

export default new MetasService();