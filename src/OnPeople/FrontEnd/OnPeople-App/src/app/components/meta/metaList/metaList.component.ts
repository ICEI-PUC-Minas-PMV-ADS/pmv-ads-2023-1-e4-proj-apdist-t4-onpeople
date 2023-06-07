import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject, debounceTime } from 'rxjs';
import { MetaService } from 'src/app/services';

@Component({
  selector: 'app-metaList',
  templateUrl: './metaList.component.html',
  styleUrls: ['./metaList.component.scss']
})
export class MetaListComponent implements OnInit {


  public changeTerm: Subject<string> = new Subject<string>();

  public metaFilter(event: any): void {
 /*   if (this.changeTerm.observers.length === 0) {
     this.spinnerService.show();
      this.changeTerm
        .pipe(debounceTime(1500))
        .subscribe(
          filterBy => {
            this.metaService
              .getMetas(this.pagination.currentPage, this.pagination.itemsPage, filterBy)
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
  */}

  constructor(
    private metaService: MetaService,
    private spinnerService: NgxSpinnerService,
  ) { }

  ngOnInit() {
  }

}
