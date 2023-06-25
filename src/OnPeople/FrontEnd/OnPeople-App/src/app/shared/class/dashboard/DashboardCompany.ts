import { ListaMetas } from "./ListaMetas";

export interface DashboardCompany {
  countEmpresas: number;
  countEmpresasAtivas: number;
  percentualEmpresasAtivas: number;
  countFiliais: number;
  percentualFiliais: number;
  countFiliaisAtivas: number;
  percentualFiliaisAtivas: number;
  percentualFiliaisAtivas2: number;
  listaNomeEmpresa: string[];
  listaQtdeDepartamentos: number[];
  listaMetas: ListaMetas[];
}

