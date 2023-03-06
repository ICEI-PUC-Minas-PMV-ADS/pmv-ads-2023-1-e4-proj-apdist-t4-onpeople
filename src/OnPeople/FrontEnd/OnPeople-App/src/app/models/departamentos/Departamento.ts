
export interface Departamento {
  id: number;
  nomeDepartamento: string;
  sigla: string;
  diretorId: number;
  gerenteId: number;
  supervisorId: number;
  dataCriacao: Date;
  dataEncerramento?: Date;
  ativo: Boolean;
  empresaId: number;
}
