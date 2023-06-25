import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

import { Subject, debounceTime } from 'rxjs';
0
import { Cargo } from 'src/app/models/jobRole/Cargo';

import { JobRoleService } from 'src/app/services/jobRole';

import { PaginatedResult, Pagination } from 'src/app/shared/class/paginator';

@Component({
  selector: 'app-jobRoleList',
  templateUrl: './jobRoleList.component.html',
  styleUrls: ['./jobRoleList.component.scss']
})
export class JobRoleListComponent implements OnInit {
  public modalRef?: BsModalRef;

  public spinnerShow: boolean = false;

  public jobRoles: Cargo[] = [];
  public jobRolesFilter: Cargo[] = []

  public cargoId: number = 0;
  public CargoName: string = "";

  public pagination = {} as Pagination;

  public changeTerm: Subject<string> = new Subject<string>();

  public jobRoleFilter(event: any): void {
    if (this.changeTerm.observers.length === 0) {
      this.spinnerShow = true;
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
              .add(() => this.spinnerShow = false);
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
    ) { }

  ngOnInit() {
    this.spinnerShow = true;
    this.getJobRoles();
  }

  public getJobRoles(): void {
    this.spinnerShow = true;;

    this.jobRoleService
      .getJobRoles(this.pagination.currentPage, this.pagination.itemsPage)
      .subscribe(
        (jobRoles: PaginatedResult<Cargo[]>) => {
          this.jobRoles = jobRoles.result
          this.pagination = jobRoles.pagination;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerShow = false)
  }

 public openModal(event: any, template: TemplateRef<any>, jobRoleId: number, jobRoleName:string): void {
    event.stopPropagation();
    this.cargoId = jobRoleId;
    this.CargoName = jobRoleName;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirmDeletion(): void {
    this.spinnerShow = true;

    this.modalRef?.hide();
    this.jobRoleService
      .deleteJobRole(this.cargoId)
      .subscribe(
        (result: any ) => {
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
      .add(() => this.spinnerShow = false);
  }
  public backOff(): void {
    this.modalRef?.hide();
  }

  public jobRoleDetail(id: number): void {
    this.router.navigate([`cargos/detail/${id}`])
  }

  public pageChanged(event: any): void {
//    this.pagination.currentPage = event.currentPage
    this.getJobRoles();
  }
}
