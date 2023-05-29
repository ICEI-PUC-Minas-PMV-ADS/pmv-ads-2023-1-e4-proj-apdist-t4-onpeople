

import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { EventoService } from '../../services/evento.service';
import { Meta } from '../../models/Meta';
import { MetaService } from 'src/app/services/meta.service';

@Component({
  selector: 'app-metas',
  templateUrl: './metas.component.html',
  styleUrls: ['./metas.component.scss']
})
export class MetasComponent implements OnInit {

  modalRef: BsModalRef;
  public metas: Meta[] = [];
  public metasFiltradas: Meta[] = [];

  public larguraImagem = 150;
  public margemImagem = 2;
  public exibirImagem = true;
  private filtroListado = '';

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.metasFiltradas = this.filtroLista ? this.filtrarMetas(this.filtroLista) : this.metas;
  }

  public filtrarMetas(filtrarPor: string): Meta[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.metas.filter(
      meta => meta.tipoMeta.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      meta.nomeMeta.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private metaService: MetaService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public alterarImagem(): void {
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos(): void {
    this.metaService.getMetas().subscribe({
      next: (metas: Meta[]) => {
        this.metas = metas;
        this.metasFiltradas = this.metas;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar as Metas', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef.hide();
    this.toastr.success('A Meta foi deletada com Sucesso.', 'Deletada!');
  }

  decline(): void {
    this.modalRef.hide();
  }

}
