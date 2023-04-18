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

  // public Empresa Empresas { get; set; }
  // public IEnumerable<FuncionarioMeta> FuncionariosMetas { get; set; }

}
