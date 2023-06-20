export class DashList {
  funcionarioId: number;
  funcionarioNome: string;
  funcionarioAdmissao: string;
  funcionarioDemissao: string;
  departamentoId: number;
  departamentoNome: string;
  departamentoSigla: string;
  departamentoAtivo: boolean;
  cargoId: number;
  cargoNome: string;
  cargoAtivo: boolean;
  empresaId: number;
  empresaNome: string;
  empresaCnpj: string;
  empresaAtiva: boolean;
  empresaFilial: boolean;
  empresaFilialAtiva: boolean;
  funcionarioMetaId: number;
  funcionarioMetaTipoMeta: string;
  funcionarioMetaNome: string;
  funcionariometaDescricao: string;
  funcionarioMetaMetaCumprida: boolean;
  funcionarioMetaMetaAprovada: boolean;
  funcionarioMetaCumprida: boolean;

  constructor(
    funcionarioId: number,
    funcionarioNome: string,
    funcionarioAdmissao: string,
    funcionarioDemissao: string,
    departamentoId: number,
    departamentoNome: string,
    departamentoSigla: string,
    departamentoAtivo: boolean,
    cargoId: number,
    cargoNome: string,
    cargoAtivo: boolean,
    empresaId: number,
    empresaNome: string,
    empresaCnpj: string,
    empresaAtiva: boolean,
    empresaFilial: boolean,
    empresaFilialAtiva: boolean,
    funcionarioMetaId: number,
    funcionarioMetaTipoMeta: string,
    funcionarioMetaNome: string,
    funcionariometaDescricao: string,
    funcionarioMetaMetaCumprida: boolean,
    funcionarioMetaMetaAprovada: boolean,
    funcionarioMetaCumprida: boolean,
  ) {
    this.funcionarioId = funcionarioId;
    this.funcionarioNome = funcionarioNome;
    this.funcionarioAdmissao = funcionarioAdmissao;
    this.funcionarioDemissao = funcionarioDemissao;
    this.departamentoId = departamentoId;
    this.departamentoNome = departamentoNome;
    this.departamentoSigla = departamentoSigla;
    this.departamentoAtivo = departamentoAtivo;
    this.cargoId = cargoId;
    this.cargoNome = cargoNome;
    this.cargoAtivo = cargoAtivo;
    this.empresaId = empresaId;
    this.empresaNome = empresaNome;
    this.empresaCnpj = empresaCnpj;
    this.empresaAtiva = empresaAtiva;
    this.empresaFilial = empresaFilial;
    this.empresaFilialAtiva = empresaFilialAtiva;
    this.funcionarioMetaId = funcionarioMetaId;
    this.funcionarioMetaTipoMeta = funcionarioMetaTipoMeta;
    this.funcionarioMetaNome = funcionarioMetaNome;
    this.funcionariometaDescricao = funcionariometaDescricao;
    this.funcionarioMetaMetaCumprida = funcionarioMetaMetaCumprida;
    this.funcionarioMetaMetaAprovada = funcionarioMetaMetaAprovada;
    this.funcionarioMetaCumprida = funcionarioMetaCumprida;
  }
}
