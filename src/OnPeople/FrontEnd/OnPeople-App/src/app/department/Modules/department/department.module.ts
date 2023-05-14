import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { MatIconModule } from '@angular/material/icon';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbCollapseModule, NgbPaginationModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppRoutingModule } from 'src/app/app-routing.module';

import { DepartmentComponent, DepartmentDetailComponent, DepartmentListComponent } from '../../components';

import { TitlebarModule } from 'src/app/shared/modules';
import { DepartmentService } from '../../services';



@NgModule({
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    MatIconModule,
    NgbCollapseModule,
    NgbPaginationModule,
    NgbTooltipModule,
    NgSelectModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    TitlebarModule,
  ],
  declarations: [
    DepartmentComponent,
    DepartmentDetailComponent,
    DepartmentListComponent
  ],
  exports: [
    DepartmentComponent,
    DepartmentDetailComponent,
    DepartmentListComponent
  ],
  providers: [
    DepartmentService
  ],
})
export class DepartmentModule { }
