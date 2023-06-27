export class ListDepartmentsByCompany {
  empresaId: number;
  empresaNome: string;
  empresaCnpj: string;
  empresaAtiva: boolean;
  empresaFilial: boolean;
  empresaFilialAtiva: boolean;
  departamentoId: number;
  departamentoNome: string;
  departamentoSigla: string;
  departamentoAtivo: boolean;

  constructor(
    empresaId: number,
    empresaNome: string,
    empresaCnpj: string,
    empresaAtiva: boolean,
    empresaFilial: boolean,
    empresaFilialAtiva: boolean,
    departamentoId: number,
    departamentoNome: string,
    departamentoSigla: string,
    departamentoAtivo: boolean,
  ) {
    this.empresaId = empresaId;
    this.empresaNome = empresaNome;
    this.empresaCnpj = empresaCnpj;
    this.empresaAtiva = empresaAtiva;
    this.empresaFilial = empresaFilial;
    this.empresaFilialAtiva = empresaFilialAtiva;
    this.departamentoId = departamentoId;
    this.departamentoNome = departamentoNome;
    this.departamentoSigla = departamentoSigla;
    this.departamentoAtivo = departamentoAtivo;
  }
}
