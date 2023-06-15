import { Empresa } from "src/app/models/company";
import { Users } from "src/app/models/user";
import { DadoPessoal } from "./DadoPessoal";
import { Endereco } from "./Endereco";
import { FuncionarioMeta } from "./FuncionarioMeta";
import { Cargo } from "../jobRole";
import { Departamento } from "../department";
import { Meta } from "../goal";

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
  metas: Meta[];
}
