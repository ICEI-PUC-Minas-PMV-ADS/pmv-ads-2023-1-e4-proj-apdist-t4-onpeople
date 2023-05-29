import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject, debounceTime } from 'rxjs';
import { Departamento } from 'src/app/departments/models';
import { DepartmentService } from 'src/app/departments/services';
import { Cargo } from 'src/app/jobRoles/models/Cargo';
import { JobRoleService } from 'src/app/jobRoles/services';
import { PaginatedResult, Pagination } from 'src/app/shared/models';

@Component({
  selector: 'app-jobRoleList',
  templateUrl: './jobRoleList.component.html',
  styleUrls: ['./jobRoleList.component.scss']
})
export class JobRoleListComponent implements OnInit {
  public modalRef?: BsModalRef;

  public jobRoles: Cargo[] = [];
  public jobRolesFilter: Cargo[] = []

  public cargoId: number = 0;
  public CargoName: string = "";

  public pagination = {} as Pagination;

  public changeTerm: Subject<string> = new Subject<string>();

  public jobRoleFilter(event: any): void {
    if (this.changeTerm.observers.length === 0) {
      this.spinnerService.show();
      this.changeTerm
        .pipe(debounceTime(1500))
        .subscribe(
          filterBy => {
            this.jobRoleService
              .getJobRoles(this.pagination.currentPage, this.pagination.itemsPage, filterBy)
              .subscribe(
                (jobRoles: PaginatedResult<Cargo[]>) => {
                  this.jobRoles = jobRoles.result;
                  this.pagination = jobRoles.pagination;
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

  constructor(
    private router: Router,
    private jobRoleService: JobRoleService,
    private modalService: BsModalService,
    public toastrService: ToastrService,
    private spinnerService: NgxSpinnerService) { }

  ngOnInit() {
    this.spinnerService.show();
    this.getJobRoles();
  }

  public getJobRoles(): void {
    this.spinnerService.show;

    this.jobRoleService
      .getJobRoles(this.pagination.currentPage, this.pagination.itemsPage)
      .subscribe(
        (jobRoles: PaginatedResult<Cargo[]>) => {
          this.jobRoles = jobRoles.result
          console.log(this.jobRoles);
          this.pagination = jobRoles.pagination;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
  }

 public openModal(event: any, template: TemplateRef<any>, jobRoleId: number, jobRoleName:string): void {
    event.stopPropagation();
    this.cargoId = jobRoleId;
    this.CargoName = jobRoleName;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirmDeletion(): void {
    this.spinnerService.show();

    this.modalRef?.hide();
    console.log("companyId ", this.cargoId)
    this.jobRoleService
      .deleteJobRole(this.cargoId)
      .subscribe(
        (result: any ) => {
          console.log(result);
          if (result == null)
            this.toastrService.error('Cargo não pode se excluído.', "Erro!");

          if (result.message == 'OK') {
            this.toastrService.success('Cargo excluída com sucesso', 'Excluído!');
            this.getJobRoles();
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

  public jobRoleDetail(id: number): void {
    this.router.navigate([`cargos/detail/${id}`])
  }

  public pageChanged(event: any): void {
    console.log(event.currentPage)
//    this.pagination.currentPage = event.currentPage
    this.getJobRoles();
  }
}
