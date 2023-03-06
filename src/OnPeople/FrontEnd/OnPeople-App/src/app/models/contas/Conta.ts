import { Empresa } from "../empresas/Empresa";
import { ContaFuncao } from "./ContaFuncao";


export interface Conta {
  id: number;
  nomeCompleto: string;
  visao: string;
  foto: string;
  dataCadastro: Date;
  dataEncerramento?: Date;
  ativa: Boolean;
  contasFuncoes: ContaFuncao;
  empresas: Empresa;
}
