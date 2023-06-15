import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Subject, debounceTime } from 'rxjs';

import { Meta } from 'src/app/models';

import { GoalService } from 'src/app/services';

import { PaginatedResult, Pagination } from 'src/app/shared/class/paginator';

@Component({
  selector: 'app-goalList',
  templateUrl: './goalList.component.html',
  styleUrls: ['./goalList.component.scss']
})
export class GoalListComponent implements OnInit {
    public modalRef?: BsModalRef;

  public goalId: number = 0;
  public goalName: string = "";

  public goals: Meta[] = [];
  public goalsFilter: Meta[] = []

  public pagination = {} as Pagination;

  public changeTerm: Subject<string> = new Subject<string>();

  public goalFilter(event: any): void {
    if (this.changeTerm.observers.length === 0) {
     this.spinnerService.show();
      this.changeTerm
        .pipe(debounceTime(1500))
        .subscribe(
          filterBy => {
            this.goalService
              .getGoals(this.pagination.currentPage, this.pagination.itemsPage, filterBy)
              .subscribe(
                (goals: PaginatedResult<Meta[]>) => {
                  this.goals = goals.result;
                  this.pagination = goals.pagination;
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
    private goalService: GoalService,
    private modalService: BsModalService,
    private router: Router,
    private spinnerService: NgxSpinnerService,
    public toastrService: ToastrService,
  ) { }

  ngOnInit() {
    this.getGoals()
  }


  public getGoals(): void {
    this.spinnerService.show;

    this.goalService
      .getGoals(this.pagination.currentPage, this.pagination.itemsPage)
      .subscribe(
        (goals: PaginatedResult<Meta[]>) => {
          this.goals = goals.result
          this.pagination = goals.pagination;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public openModal(event: any, template: TemplateRef<any>, goalId: number, goalName:string): void {
    event.stopPropagation();
    this.goalId = goalId;
    this.goalName = goalName;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirmDeletion(): void {
    this.spinnerService.show();

    this.modalRef?.hide();
    this.goalService
      .deleteGoal(this.goalId)
      .subscribe(
        (result: any ) => {
            if (result == null)
            this.toastrService.error('Meta não pode se excluída.', "Erro!");

          if (result.message == 'OK') {
            this.toastrService.success('Meta excluída com sucesso', 'Excluído!');
            this.getGoals();
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


  public metaDetail(id: number): void {
    this.router.navigate([`metas/detail/${id}`])
  }
}
