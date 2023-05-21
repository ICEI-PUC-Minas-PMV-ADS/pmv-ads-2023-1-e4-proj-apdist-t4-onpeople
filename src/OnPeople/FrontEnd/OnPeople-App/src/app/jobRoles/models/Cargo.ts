import { Empresa } from "src/app/companies/models";
import { Departamento } from "src/app/department/models";

export class Cargo {
  id: number;
  nomeCargo: string;
  ativo: Boolean;
  dataCriacao: string;
  dataEncerramento: string;
  departamentoId: number;
  departamento: Departamento;
  empresaId: number;
  empresa: Empresa;
//  funcionarios: Funcionario[];
}
