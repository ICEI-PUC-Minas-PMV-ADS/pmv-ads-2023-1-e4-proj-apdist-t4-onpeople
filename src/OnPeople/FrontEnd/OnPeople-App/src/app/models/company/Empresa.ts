
import { Cargo } from "../cargo";
import { Departamento } from "../department";


export interface Empresa {
  id: number;
  cnpj: string;
  razaoSocial: string;
  nomeFantasia: string;
  siglaEmpresa: string;
  ativa: Boolean;
  dataCadastro: string;
  dataDesativacao: string;
  filial: Boolean;
  padraoEmail: string;
  presidenteId: number;
  naturezaJuridica: string;
  porteEmpresa: string;
  optanteSimples: string;
  tipoLogradouro: string;
  logradouro: string;
  numero: string;
  complemento: string;
  bairro: string;
  cep: string;
  ddd: string;
  telefone: string;
  emailEmpresa: string;
  atividadePrincipal: string;
  siglaPaisIso3: string;
  siglaPaisIso2: string;
  nomePais: string;

  matrizId: number;
  logotipo: string;
  paisId: string;
  estadoId: number;
  estado: string;
  siglaEstado: string;
  estadoIbgeId: number;
  cidadeId: number;
  cidade: string;
  cidadeIbgeId: number;
  cidadeSiafiId: string;
  departamentos: Departamento[];
  cargos: Cargo[];
}