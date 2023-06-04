import api from "./Api"

class DepartamentosService {
    async getDepartamentos() {
        try {
            const response = await api.get('/Departamentos');
            const data = await response.json();

            return data.departamentos;
        } catch (error) {
            throw new Error('Erro ao obter os departamentos: ' + error.message);
        }
    }
}
export default DepartamentosService;