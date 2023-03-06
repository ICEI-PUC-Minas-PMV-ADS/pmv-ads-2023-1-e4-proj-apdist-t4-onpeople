import { Component, OnInit, TemplateRef } from '@angular/core';

import { faTrash, faPencil } from '@fortawesome/free-solid-svg-icons'

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { NgxSpinnerService } from "ngx-spinner";

import { ToastrService } from 'ngx-toastr';

import { Empresa } from 'src/app/models/empresas/Empresa';
import { EmpresasService } from 'src/app/services/empresas/Empresas.service';


@Component({
  selector: 'app-empresasLista',
  templateUrl: './empresasLista.component.html',
  styleUrls: ['./empresasLista.component.scss']
})
export class EmpresasListaComponent implements OnInit {
  public modalRef?: BsModalRef;

  public trashIcon = faTrash;
  public pencilIcon = faPencil

  public empresas: Empresa[] = [];
  public empresasFiltradas: Empresa[] = []
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

  constructor(private empresasService: EmpresasService,
    private modalService: BsModalService,
    public toastrService: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.spinner.show();
    this.getEmpresas();
  }

  public getEmpresas(): void {
    this.empresasService.getEmpresas()
      .subscribe(
        (empresas: Empresa[]) => {
          this.empresas = empresas,
          this.empresasFiltradas = this.empresas;
        },
        (error: any) => this.toastrService.error('Falha ao carregra empresas', 'Atenção: Erro!'),
      ).add(() => this.spinner.hide())
  }

 public  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirm(): void {
    this.modalRef?.hide();
    this.toastrService.success('Empresa excluída com sucesso', 'Excluído!');
  }

  public decline(): void {
    alert('Declined!');
    this.modalRef?.hide();
  }

}
