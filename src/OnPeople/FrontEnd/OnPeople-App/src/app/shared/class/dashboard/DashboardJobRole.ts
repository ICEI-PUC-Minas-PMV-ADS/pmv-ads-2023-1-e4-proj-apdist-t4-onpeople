import { ListaMetas } from "./ListaMetas";

export interface DashboardJobRole {
  countCargos: number;
  countCargosAtivos: number;
  percentualCargosAtvios: number;
  listaNomeCargo: string[];
  listaQtdeFuncionarios: number[];
  listaMetas: ListaMetas[];
}
