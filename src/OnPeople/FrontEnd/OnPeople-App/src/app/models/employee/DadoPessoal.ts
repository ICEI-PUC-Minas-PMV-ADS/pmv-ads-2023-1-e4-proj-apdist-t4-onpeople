export interface DadoPessoal {
  id: number;
  cpf: string;
  tituloEleitor: string;
  impedimentoEleitoral: Boolean;
  identidade: string;
  dataExpedicao: string;
  ufEmissao: string;
  estadoCivil: string;
  carteiraTrabalho: string;
  pisPasep: string;
  funcionarioId: number;
}
