import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';

import { faTrash, faPlusSquare, faEye, faEyeSlash, IconDefinition} from '@fortawesome/free-solid-svg-icons'

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { NgxSpinnerService } from "ngx-spinner";

import { ToastrService } from 'ngx-toastr';

import { Empresa } from 'src/app/models/empresas/Empresa';
import { EmpresasService } from 'src/app/services/empresas/Empresas.service';
import { environment } from 'src/assets/environments/environments';


@Component({
  selector: 'app-empresasLista',
  templateUrl: './empresasLista.component.html',
  styleUrls: ['./empresasLista.component.scss']
})
export class EmpresasListaComponent implements OnInit {
  public modalRef?: BsModalRef;

  public excluirIcon: IconDefinition = faTrash;
  public novoIcon: IconDefinition = faPlusSquare
  public visualizarIcon: IconDefinition = faEye;
  public fecharIcon: IconDefinition = faEyeSlash;

  public alternarImagem : boolean = true;
  public logotipoURL: string = "../../../../assets/img/Image_not_available.png";

  public empresas: Empresa[] = [];
  public empresasFiltradas: Empresa[] = []

  public empresaId: number = 0;
  public nomeEmpresa: string = "";

  public temFiliais: Boolean = false;
  public empresaMatriz: Boolean = false;

  private _filtroEmpresa: string = '';

  public get filtroEmpresa() {
    return this._filtroEmpresa;
  }

  public set filtroEmpresa(argumento: string) {
    this._filtroEmpresa = argumento;
    this.empresasFiltradas = this.filtroEmpresa ? this.filtrarEmpresas(this.filtroEmpresa) : this.empresas
  }

  public filtrarEmpresas(argumento: string): Empresa[] {
    argumento = argumento.toLocaleLowerCase();
    return this.empresas.filter(
      (empresa: {nomeEmpresa: string, nomeFantasia: string, sigla: string}) =>
        empresa.nomeEmpresa.toLocaleLowerCase().indexOf(argumento) !== -1
        || empresa.nomeFantasia.toLocaleLowerCase().indexOf(argumento) !== -1
        || empresa.sigla.toLocaleLowerCase().indexOf(argumento) !== -1
    )
  }

  public alternarEstadoImagem(): void {
    this.alternarImagem = !this.alternarImagem
  }

  constructor(
    private router: Router,
    private empresasService: EmpresasService,
    private modalService: BsModalService,
    public toastrService: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.spinner.show();
    this.carregarEmpresas();

  }

  public carregarEmpresas(): void {
    this.empresasService.getEmpresas()
      .subscribe(
        (empresas: Empresa[]) => {
          this.empresas = empresas,
          this.empresasFiltradas = this.empresas;
        },
        (error: any) => this.toastrService.error('Falha ao carregra empresas', 'Atenção: Erro!'),
      ).add(() => this.spinner.hide())
  }

 public  openModal(event: any, template: TemplateRef<any>, empresaId: number, nomeEmpresa:string): void {
    event.stopPropagation();
    this.empresaId = empresaId;
    this.nomeEmpresa = nomeEmpresa;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirmarExclusao(): void {
    this.modalRef?.hide();
    this.spinner.show();

    this.verificarFiliais();

  }

  public verificarFiliais(): void {
    this.empresasService
      .getEmpresasFiliais()
      .subscribe(
        (filiais: Empresa[]) => {
          (filiais.length > 0)
            ? this.temFiliais = true
            : this.temFiliais = false;
            this.verificarEmpresaMatriz();
        },
        (error: any) => {
          this.toastrService.error("Falha ao verificar empresas filiais", "Erro!")
          console.error(error)
        }
      )
  }

  public verificarEmpresaMatriz(): void {
    this.empresasService
      .getEmpresas()
      .subscribe(
        (empresas: Empresa[]) => {
          var empresaFilter = empresas.filter((e) => e.filial == false);
          (this.empresaId === empresaFilter[0].id)
            ? this.empresaMatriz = true
            : this.empresaMatriz = false;

            this.excluirEmpresa();
        },
        (error: any) => {
          this.toastrService.error("Falha ao verificar se empresa é matriz", "Erro!")
          console.error(error)
        }
      )
  }

  public excluirEmpresa(): void {
    if (this.empresaMatriz) {
      this.toastrService.warning("Esta empresa possui filiais! Não pode ser excluída!", "Atenção!");
      this.spinner.hide();
    } else {
      this.empresasService
        .excluirEmpresa(this.empresaId)
        .subscribe(
          (resultado: any ) => {
            if (resultado.message == 'OK') {
              this.toastrService.success('Empresa excluída com sucesso', 'Excluído!');
              this.carregarEmpresas();
            }
          },
          (error: any) => {
            this.toastrService.error('Falha a excluir a empresa.', "Erro!");
            console.error(error);
          }
        )
        .add(() => this.spinner.hide());
    }
  }
  public desistir(): void {
    this.modalRef?.hide();
  }

  public detalheEmpresa(id: number): void {
    this.router.navigate([`empresas/detalhe/${id}`])
  }

  public mostrarLogotipo(logotipoURL: string): string {
    return (logotipoURL !== 'Image_not_available.png')
      ? `${environment.resourcesLogosURL}${logotipoURL}`
      : `../../../../assets/img/${logotipoURL}`;
  }
}
