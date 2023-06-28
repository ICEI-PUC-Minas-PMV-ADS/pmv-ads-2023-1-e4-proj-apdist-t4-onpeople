import { ListaMetas } from "./ListaMetas";

export interface DashboardDepartment {
  countDepartamentos: number;
  countDepartamentosAtivos: number;
  percentualDepartamentosAtivos: number;
  listaNomeDepartamento: string[];
  listaQtdeCargos: number[];
  listaMetas: ListaMetas[];
}
