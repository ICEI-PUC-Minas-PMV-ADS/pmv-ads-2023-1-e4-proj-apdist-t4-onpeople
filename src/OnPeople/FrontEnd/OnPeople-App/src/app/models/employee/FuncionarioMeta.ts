import { Funcionario } from "./Funcionario";

export interface FuncionarioMeta {
  id: number;
  metaId: number;
  //meta: Meta;
  funcionarioId: number;
  funcionario: Funcionario;
  metaCumprida: Boolean;
  dataExpedicao: string;
  inicioEfetivo: string;
  fimEfetivo: string;
  diasEfetivo: number;
  inicioAcordado: string;
  fimAcordado: string;
  diasAcordado: number;
}
