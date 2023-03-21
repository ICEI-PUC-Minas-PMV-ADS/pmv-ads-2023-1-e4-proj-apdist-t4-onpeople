import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from 'ngx-toastr';

import { Empresa } from 'src/app/companys/models';

import { CompanyService } from 'src/app/companys/services';
import { environment } from 'src/assets/environments';

@Component({
  selector: 'app-companyList',
  templateUrl: './companyList.component.html',
  styleUrls: ['./companyList.component.scss']
})
export class CompanyListComponent implements OnInit {
  public modalRef?: BsModalRef;

  public toggleImage : boolean = true;
  public logoURL: string = "../../../../assets/img/Image_not_available.png";

  public companies: Empresa[] = [];
  public companiesFilter: Empresa[] = []

  public companyId: number = 0;
  public companyName: string = "";

  private _companyFilter: string = '';

  public get companyFilter() {
    return this._companyFilter;
  }

  public set companyFilter(args: string) {
    this._companyFilter = args;
    this.companiesFilter = this.companyFilter ? this.filterCompanies(this.companyFilter) : this.companies
  }

  public filterCompanies(args: string): Empresa[] {
    args = args.toLocaleLowerCase();
    return this.companies.filter(
      (empresa: {nomeEmpresa: string, nomeFantasia: string, sigla: string}) =>
        empresa.nomeEmpresa.toLocaleLowerCase().indexOf(args) !== -1
        || empresa.nomeFantasia.toLocaleLowerCase().indexOf(args) !== -1
        || empresa.sigla.toLocaleLowerCase().indexOf(args) !== -1
    )
  }

  public changeImageState(): void {
    this.toggleImage = !this.toggleImage
  }

  constructor(
    private router: Router,
    private companyService: CompanyService,
    private modalService: BsModalService,
    public toastrService: ToastrService,
    private spinnerService: NgxSpinnerService) { }

  ngOnInit() {
    this.spinnerService.show();
    this.getCompanies();
  }

  public getCompanies(): void {
    this.spinnerService.show;

    this.companyService
      .getCompanies()
      .subscribe(
        (companies: Empresa[]) => {
          this.companies = companies,
          this.companiesFilter = this.companies;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
  }

 public  openModal(event: any, template: TemplateRef<any>, companyId: number, companyName:string): void {
    event.stopPropagation();
    this.companyId = companyId;
    this.companyName = companyName;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirmDeletion(): void {
    this.spinnerService.show();

    this.modalRef?.hide();
    console.log("companyId ", this.companyId)
    this.companyService
      .deleteCompany(this.companyId)
      .subscribe(
        (result: any ) => {
          console.log(result);
          if (result == null)
            this.toastrService.error('Empresa não pode se excluída.', "Erro!");

          if (result.message == 'OK') {
            this.toastrService.success('Empresa excluída com sucesso', 'Excluído!');
            this.getCompanies();
          }
        },
          (error: any) => {
            this.toastrService.error(error.error, `Erro! Status ${error.status}`);
            console.error(error);
          }
        )
      .add(() => this.spinnerService.hide());
  }
  public backOff(): void {
    this.modalRef?.hide();
  }

  public companyDetail(id: number): void {
    this.router.navigate([`empresas/detalhe/${id}`])
  }

  public showBranch(logoURL: string): string {
    return (logoURL !== 'Image_not_available.png')
      ? `${environment.resourcesLogosURL}${logoURL}`
      : `../../../../assets/img/${logoURL}`;
  }
}
