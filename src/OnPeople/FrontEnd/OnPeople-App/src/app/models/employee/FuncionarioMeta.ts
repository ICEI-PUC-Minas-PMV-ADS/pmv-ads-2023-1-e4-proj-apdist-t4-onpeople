import { Funcionario } from ".";
import { Meta } from "../goal";



export interface FuncionarioMeta {
  id: number;
  metaId: number;
  meta: Meta;
  funcionarioId: number;
  funcionario: Funcionario;
  metaCumprida: Boolean;
  inicioEfetivo: string;
  fimEfetivo: string;
  diasEfetivo: number;
  inicioAcordado: string;
  fimAcordado: string;
  diasAcordado: number;
}
