import { Funcionario } from ".";
import { Empresa } from "../company";
import { Meta } from "../goal";



export interface FuncionarioMeta {
  id: number;
  metaId: number;
  meta: Meta;
  funcionarioId: number;
  funcionario: Funcionario;
  metaCumprida: boolean;
  inicioEfetivo: string;
  fimEfetivo: string;
  diasEfetivo: number;
  inicioAcordado: string;
  fimAcordado: string;
  diasAcordado: number;
  empresaId: number;
  empresa: Empresa;
}
