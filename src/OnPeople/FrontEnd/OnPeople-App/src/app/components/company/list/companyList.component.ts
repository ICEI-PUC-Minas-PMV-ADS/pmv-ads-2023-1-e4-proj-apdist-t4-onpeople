import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

import { debounceTime, Subject } from 'rxjs';

import { PaginatedResult, Pagination } from 'src/app/shared/class/paginator';

import { Empresa } from 'src/app/models';

import { CompanyService } from 'src/app/services';

import { environment } from 'src/assets/environments';

@Component({
  selector: 'app-companyList',
  templateUrl: './companyList.component.html',
  styleUrls: ['./companyList.component.scss']
})
export class CompanyListComponent implements OnInit {
  public modalRef?: BsModalRef;

  public spinnerShow: boolean = false;

  public toggleImage : boolean = true;
  public logoURL: string = "../../../../assets/img/Image_not_available.png";

  public companies: Empresa[] = [];
  public companiesFilter: Empresa[] = []

  public companyId: number = 0;
  public companyName: string = "";

  public pagination = {} as Pagination;

  public changeTerm: Subject<string> = new Subject<string>();

  public companyFilter(event: any): void {
    if (this.changeTerm.observers.length === 0) {
      this.spinnerShow = true;
      this.changeTerm
        .pipe(debounceTime(1500))
        .subscribe(
          filterBy => {
            this.companyService
              .getCompanies(this.pagination.currentPage, this.pagination.itemsPage, filterBy)
              .subscribe(
                (companies: PaginatedResult<Empresa[]>) => {
                  this.companies = companies.result;
                  this.pagination = companies.pagination;
                },
                (error: any) => {
                  this.toastrService.error(error.error, `Erro! Status ${error.status}`);
                  console.error(error);
                }
              )
              .add(() => this.spinnerShow = false);
          }
        )
    }

    this.changeTerm.next(event.value)
  }

  public changeImageState(): void {
    this.toggleImage = !this.toggleImage
  }

  constructor(
    private router: Router,
    private companyService: CompanyService,
    private modalService: BsModalService,
    public toastrService: ToastrService
    ) { }

  ngOnInit() {
    this.getCompanies();
  }

  public getCompanies(): void {
    this.spinnerShow = true;

    this.companyService
      .getCompanies(this.pagination.currentPage, this.pagination.itemsPage)
      .subscribe(
        (companies: PaginatedResult<Empresa[]>) => {
          this.companies = companies.result
          this.pagination = companies.pagination;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerShow = false)
  }

 public  openModal(event: any, template: TemplateRef<any>, companyId: number, companyName:string): void {
    event.stopPropagation();
    this.companyId = companyId;
    this.companyName = companyName;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirmDeletion(): void {
    this.spinnerShow = true;

    this.modalRef?.hide();
    this.companyService
      .deleteCompany(this.companyId)
      .subscribe(
        (result: any ) => {
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
      .add(() => this.spinnerShow = false);
  }
  public backOff(): void {
    this.modalRef?.hide();
  }

  public companyDetail(id: number): void {
    this.router.navigate([`empresas/detail/${id}`])
  }

  public showBranch(logoURL: string): string {
    return (logoURL !== 'Image_not_available.png')
      ? `${environment.resourcesLogosURL}${logoURL}`
      : `../../../../assets/img/${logoURL}`;
  }

  public pageChanged(event: any): void {
//    this.pagination.currentPage = event.currentPage
    this.getCompanies();
  }
}
