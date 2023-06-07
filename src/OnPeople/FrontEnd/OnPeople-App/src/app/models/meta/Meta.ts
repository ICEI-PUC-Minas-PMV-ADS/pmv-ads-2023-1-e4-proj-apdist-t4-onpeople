import { Empresa } from "../company";

export interface Meta {

  id: number;
  tipoMeta: string;
  nomeMeta: string;
  descricao: string;
  metaCumprida: boolean;
  metaAprovada: boolean;
  inicioPlanejado: Date;
  Fimplanejado: Date;
  diasPlanejado: number;
  inicioOficial: Date;
  fimOficial: Date;
  empresaId: number;
  empresa: Empresa;
  //ublic IEnumerable<FuncionarioMeta> FuncionariosMetas { get; set; }
}
