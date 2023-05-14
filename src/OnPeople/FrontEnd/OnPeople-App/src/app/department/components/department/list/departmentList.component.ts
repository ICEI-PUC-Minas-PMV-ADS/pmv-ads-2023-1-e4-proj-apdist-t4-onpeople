import { Component, OnInit, TemplateRef } from "@angular/core";
import { Router } from "@angular/router";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { Subject, debounceTime } from "rxjs";
import { Empresa } from "src/app/companies/models";
import { CompanyService } from "src/app/companies/services";
import { Departamento } from "src/app/department/models";
import { DepartmentService } from "src/app/department/services";
import { PaginatedResult, Pagination } from "src/app/shared/models";
import { environment } from "src/assets/environments";


@Component({
  selector: 'app-departmentList',
  templateUrl: './departmentList.component.html',
  styleUrls: ['./departmentList.component.scss']
})
export class DepartmentListComponent implements OnInit {
  public modalRef?: BsModalRef;

  public toggleImage : boolean = true;
  public logoURL: string = "../../../../assets/img/Image_not_available.png";

  public companies: Empresa[] = [];
  public departments: Departamento[] = [];
  public departmentsFilter: Empresa[] = []

  public companyId: number = 0;
  public companyName: string = "";

  public pagination = {} as Pagination;

  public changeTerm: Subject<string> = new Subject<string>();

  public departmentFilter(event: any): void {
    if (this.changeTerm.observers.length === 0) {
      this.spinnerService.show();
      this.changeTerm
        .pipe(debounceTime(1500))
        .subscribe(
          filterBy => {
            this.departmentService
              .getDepartments(this.pagination.currentPage, this.pagination.itemsPage, filterBy)
              .subscribe(
                (departments: PaginatedResult<Departamento[]>) => {
                  this.departments = departments.result;
                  this.pagination = departments.pagination;
                },
                (error: any) => {
                  this.toastrService.error(error.error, `Erro! Status ${error.status}`);
                  console.error(error);
                }
              )
              .add(() => this.spinnerService.hide());
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
    private departmentService: DepartmentService,
    private modalService: BsModalService,
    public toastrService: ToastrService,
    private spinnerService: NgxSpinnerService) { }

  ngOnInit() {
    this.spinnerService.show();
    this.getDepartments();
  }
  public getDepartments(): void {
    this.spinnerService.show;

    this.departmentService
      .getDepartments(this.pagination.currentPage, this.pagination.itemsPage)
      .subscribe(
        (departments: PaginatedResult<Departamento[]>) => {
          this.departments = departments.result
          console.log(this.departments);
          this.pagination = departments.pagination;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
  }

 public openModal(event: any, template: TemplateRef<any>, companyId: number, companyName:string): void {
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
            this.getDepartments();
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

  public departmentDetail(id: number): void {
    this.router.navigate([`departamentos/detail/${id}`])
  }

  public showBranch(logoURL: string): string {
    return (logoURL !== 'Image_not_available.png')
      ? `${environment.resourcesLogosURL}${logoURL}`
      : `../../../../assets/img/${logoURL}`;
  }

  public pageChanged(event: any): void {
    console.log(event.currentPage)
//    this.pagination.currentPage = event.currentPage
    this.getDepartments();
  }
}
