import { Departamento } from "../departamentos/Departamento";
import { EmpresaConta } from "./EmpresaConta";


export interface Empresa {
  id: number;
  nomeEmpresa: string;
  nomeFantasia: string;
  sigla: string;
  ativa: Boolean;
  dataCadastro: Date;
  dataDesativacao?: Date;
  filial: Boolean;
  padraoEmail: string;
  logotipo: string;
  matrizId?: number
  empresasContas: EmpresaConta[];
  departamentos: Departamento[];
}
