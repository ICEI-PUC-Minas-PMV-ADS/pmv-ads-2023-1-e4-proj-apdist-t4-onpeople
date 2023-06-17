import { Empresa } from "../company";
import { FuncionarioMeta } from "../employee";

export interface Meta {

  id: number;
  tipoMeta: string;
  nomeMeta: string;
  descricao: string;
  metaCumprida: boolean;
  metaAprovada: boolean;
  inicioPlaIninejado: string;
  fimPlanejado: string;
  diasPlanejado: number;
  inicioOficial: string;
  fimOficial: string;
  diasOficial:number
  empresaId: number;
  empresa: Empresa;
  funcionariosMetas: FuncionarioMeta[];
}
