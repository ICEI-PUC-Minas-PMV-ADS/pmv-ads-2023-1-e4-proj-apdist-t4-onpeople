import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Meta } from '@app/models/Meta';
import { MetaService } from '@app/services/meta.service';

@Component({
  selector: 'app-metas-lista',
  templateUrl: './metas-lista.component.html',
  styleUrls: ['./metas-lista.component.scss']
})
export class MetasListaComponent implements OnInit {

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
    private spinner: NgxSpinnerService,
    private router: Router
  ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getMetas();
  }

  public alterarImagem(): void {
    this.exibirImagem = !this.exibirImagem;
  }

  public getMetas(): void {
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

  detalheMeta(id: number): void{
    this.router.navigate([`metas/detalhe/${id}`]);
  }

}
