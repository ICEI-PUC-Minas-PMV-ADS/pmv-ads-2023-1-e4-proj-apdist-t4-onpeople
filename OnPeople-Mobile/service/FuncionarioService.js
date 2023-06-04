import api from './Api';

class FuncionarioService {
    async getFuncionarios() {
        try {
            const response = await api.fetch('/Funcionarios');
            const data = await response.json();
            return data;
        } catch (error) {
            throw new Error('Erro ao obter a lista de funcionários');
        }
    }
}

export default FuncionarioService;


// import FuncionarioService from './FuncionarioService';
// logica Dashboardfuncionario:
// const DashboardFuncionario = () => {
//     const [funcionarios, setFuncionarios] = useState([]);
//     const funcionarioService = new FuncionarioService();
  
//     useEffect(() => {
//       // alllistfuncionários
//       const fetchFuncionarios = async () => {
//         try {
//           const data = await funcionarioService.getFuncionarios();
//           setFuncionarios(data);
//         } catch (error) {
//           console.error('Erro ao obter a lista de funcionários:', error);
//         }
//       };
  
//       // alllist while component ok
//       fetchFuncionarios();
//     }, []);