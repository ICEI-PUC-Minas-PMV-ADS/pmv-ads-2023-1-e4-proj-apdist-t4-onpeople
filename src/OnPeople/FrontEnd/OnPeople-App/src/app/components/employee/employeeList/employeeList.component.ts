import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject, debounceTime } from 'rxjs';
import { PaginatedResult, Pagination } from 'src/app/shared/class/paginator';
import { Funcionario } from 'src/app/models';
import { Users } from 'src/app/models/user';
import { EmployeeService, UserService } from 'src/app/services';



@Component({
  selector: 'app-employeeList',
  templateUrl: './employeeList.component.html',
  styleUrls: ['./employeeList.component.scss']
})
export class EmployeeListComponent implements OnInit {
  public modalRef?: BsModalRef;

  public employees: Funcionario[] = [];

  public user: Users[] = [];

  public employeeId: number = 0;
  public employeeName: string = "";

  public pagination = {} as Pagination;

  public changeTerm: Subject<string> = new Subject<string>();

  public employeeFilter(event: any): void {
    if (this.changeTerm.observers.length === 0) {
      this.spinnerService.show();
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
              .add(() => this.spinnerService.hide());
          }
        )
    }

    this.changeTerm.next(event.value)
    }

  constructor(
    private employeeService: EmployeeService,
    private userServices: UserService,
    private modalService: BsModalService,
    private router: Router,
    private spinnerService: NgxSpinnerService,
    public toastrService: ToastrService,
  ) { }

  ngOnInit() {
  this.getEmployees();
  }

  public getEmployees(): void {
    this.spinnerService.show;

    this.employeeService
      .getEmployees(this.pagination.currentPage, this.pagination.itemsPage)
      .subscribe(
        (employees: PaginatedResult<Funcionario[]>) => {
          this.employees = employees.result
          console.log("Employees List", this.employees);
          this.pagination = employees.pagination;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
  }


  public openModal(event: any, template: TemplateRef<any>, employeeId: number, employeeName:string): void {
    event.stopPropagation();
    this.employeeId = employeeId;
    this.employeeName = employeeName;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirmDeletion(): void {
    this.spinnerService.show();

    this.modalRef?.hide();
    console.log("companyId ", this.employeeId)
    this.employeeService
      .deleteEmployee(this.employeeId)
      .subscribe(
        (result: any ) => {
          console.log(result);
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
      .add(() => this.spinnerService.hide());
    }

  public backOff(): void {
    this.modalRef?.hide();
  }

  public employeeDetail(id: number): void {
    this.router.navigate([`funcionarios/detail/${id}`])
  }

  public pageChanged(event: any): void {
    console.log(event.currentPage)
//    this.pagination.currentPage = event.currentPage
    this.getEmployees();
  }
}
