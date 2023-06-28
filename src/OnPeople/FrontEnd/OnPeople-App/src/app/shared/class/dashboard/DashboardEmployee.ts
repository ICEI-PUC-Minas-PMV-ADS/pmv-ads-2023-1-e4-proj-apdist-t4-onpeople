import { ListaMetas } from "./ListaMetas";

export interface DashboardEmployee{
  countFuncionarios: number;
  listaNomeFuncionario: string[];
  listaQtdeMetas: number[];
  listaMetas: ListaMetas[];
}
