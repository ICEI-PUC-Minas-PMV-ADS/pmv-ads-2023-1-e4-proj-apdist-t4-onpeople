import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

import { ToastrService } from 'ngx-toastr';

import { Subject, debounceTime } from 'rxjs';

import { PaginatedResult, Pagination } from 'src/app/shared/class/paginator';

import { Funcionario, Users } from 'src/app/models';

import { EmployeeService, UserService } from 'src/app/services';



@Component({
  selector: 'app-employeeList',
  templateUrl: './employeeList.component.html',
  styleUrls: ['./employeeList.component.scss']
})
export class EmployeeListComponent implements OnInit {
  public modalRef?: BsModalRef;

  public spinnerShow: boolean = false;

  public addShow: boolean = true

  public user: Users;

  public employees: Funcionario[] = [];

  public employeeId: number = 0;
  public employeeName: string = "";

  public pagination = {} as Pagination;

  public changeTerm: Subject<string> = new Subject<string>();

  public employeeFilter(event: any): void {
    if (this.changeTerm.observers.length === 0) {
      this.spinnerShow = true;
      this.changeTerm
        .pipe(debounceTime(1500))
        .subscribe(
          filterBy => {
            this.employeeService
              .getEmployees(this.pagination.currentPage, this.pagination.itemsPage, filterBy)
              .subscribe(
                (employees: PaginatedResult<Funcionario[]>) => {
                  this.employees = employees.result;
                  this.pagination = employees.pagination;
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
    private userService: UserService,
    private employeeService: EmployeeService,
    private modalService: BsModalService,
    private router: Router,
    public toastrService: ToastrService,
  ) { }

  ngOnInit() {
    this.getUserLogged();
    this.getEmployees();
  }

  public getEmployees(): void {
    this.spinnerShow = true;;

    this.employeeService
      .getEmployees(this.pagination.currentPage, this.pagination.itemsPage)
      .subscribe(
        (employees: PaginatedResult<Funcionario[]>) => {
          this.employees = employees.result
          this.pagination = employees.pagination;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerShow = false)
  }

  public getUserLogged(): void {
    this.spinnerShow = true;;

    this.userService
      .getUserByUserName()
      .subscribe(
        (users: Users) => {
          this.user = users
          this.addShow = (this.user.visao == 'Master' || this.user.visao == 'Gold')
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerShow = false)
  }

  public openModal(event: any, template: TemplateRef<any>, employeeId: number, employeeName:string): void {
    event.stopPropagation();
    this.employeeId = employeeId;
    this.employeeName = employeeName;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirmDeletion(): void {
    this.spinnerShow = true;

    this.modalRef?.hide();
    this.employeeService
      .deleteEmployee(this.employeeId)
      .subscribe(
        (result: any ) => {
          if (result == null)
            this.toastrService.error('Funcionário não pode se excluído.', "Erro!");

          if (result.message == 'OK') {
            this.toastrService.success('Funcionário excluído com sucesso', 'Excluído!');
            this.getEmployees();
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

  public employeeDetail(id: number): void {
    this.router.navigate([`funcionarios/detail/${id}`])
  }

  public pageChanged(event: any): void {
//    this.pagination.currentPage = event.currentPage
    this.getEmployees();
  }
}
