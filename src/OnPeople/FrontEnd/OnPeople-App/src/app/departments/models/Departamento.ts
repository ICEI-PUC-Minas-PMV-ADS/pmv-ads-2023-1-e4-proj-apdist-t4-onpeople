import { Empresa } from "src/app/companies/models";

export interface Departamento {
  id: number;
  nomeDepartamento: string;
  sigla: string;
  diretorId: number;
  gerenteId: number;
  supervisorId: number;
  dataCriacao: string;
  dataEncerramento: string;
  ativo: Boolean;
  empresaId: number;
  empresa: Empresa;
  //cargos: Cargo[];
}
