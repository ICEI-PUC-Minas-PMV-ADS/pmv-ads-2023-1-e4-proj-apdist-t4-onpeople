export class DashListGoal {
  funcionarioMetaFuncionarioId: number;
  funcionarioMetaId: number;
  funcionarioMetaTipoMeta: string;
  funcionarioMetaNome: string;
  funcionariometaDescricao: string;
  funcionarioMetaMetaCumprida: boolean;
  funcionarioMetaMetaAprovada: boolean;
  funcionarioMetaCumprida: boolean;

  constructor(
    funcionarioMetaFuncionarioId: number,
    funcionarioMetaId: number,
    funcionarioMetaTipoMeta: string,
    funcionarioMetaNome: string,
    funcionariometaDescricao: string,
    funcionarioMetaMetaCumprida: boolean,
    funcionarioMetaMetaAprovada: boolean,
    funcionarioMetaCumprida: boolean,
  ) {
    this.funcionarioMetaFuncionarioId = funcionarioMetaFuncionarioId;
    this.funcionarioMetaId = funcionarioMetaId;
    this.funcionarioMetaTipoMeta = funcionarioMetaTipoMeta;
    this.funcionarioMetaNome = funcionarioMetaNome;
    this.funcionariometaDescricao = funcionariometaDescricao;
    this.funcionarioMetaMetaCumprida = funcionarioMetaMetaCumprida;
    this.funcionarioMetaMetaAprovada = funcionarioMetaMetaAprovada;
    this.funcionarioMetaCumprida = funcionarioMetaCumprida;
  }
}
