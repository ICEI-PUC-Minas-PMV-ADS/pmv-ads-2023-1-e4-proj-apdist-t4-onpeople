export interface Users {
  id: number;
  userName: string;
  nomeCompleto: string;
  email: string;
  phoneNumber: string;
  visao: string;
  foto: string;
  password: string;
  dataCadastro: Date;
  dataEncerramento?: Date;
  ativa: Boolean;
  master: Boolean;
  gold: Boolean;
  bronze: Boolean;
  codEmpresa: number;
  nomeEmpresa: string;
  codDepartamento: number;
  codFuncionario: number;
  codCargo: number;
  codMeta: number;
  token: string;
}
