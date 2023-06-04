import { Empresa } from "src/app/companies/models";
import { Departamento } from "src/app/departments/models";
import { Cargo } from "src/app/jobRoles/models";
import { Users } from "src/app/users/models";
import { DadoPessoal } from "./DadoPessoal";
import { Endereco } from "./Endereco";
import { FuncionarioMeta } from "./FuncionarioMeta";

export interface Funcionario {
  id: number;
  nomeCompleto: string;
  dataAdmissao: string;
  dataDemissao: string;
  ativo: Boolean;
  userId: number;
  user: Users;
  departamentoId: number;
  departamento: Departamento;
  cargoId: number;
  cargo: Cargo;
  empresaId: number;
  empresa: Empresa;
  funcao: string;
  dadosPessoais: DadoPessoal[];
  enderecos: Endereco[];
  funcionariosmetas: FuncionarioMeta[];
}
