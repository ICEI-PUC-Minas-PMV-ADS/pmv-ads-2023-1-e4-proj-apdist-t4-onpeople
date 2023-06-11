import { Empresa } from "src/app/models/company";
import { Funcionario } from "../employee";
import { Departamento } from "../department";



export interface Cargo {
  id: number;
  nomeCargo: string;
  ativo: Boolean;
  dataCriacao: string;
  dataEncerramento: string;
  departamentoId: number;
  departamento: Departamento;
  empresaId: number;
  empresa: Empresa;
  funcionarios: Funcionario[];
}
