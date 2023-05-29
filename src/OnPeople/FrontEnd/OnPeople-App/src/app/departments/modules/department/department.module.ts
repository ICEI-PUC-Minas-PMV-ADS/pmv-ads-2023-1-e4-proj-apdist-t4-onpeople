import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbCollapseModule, NgbPaginationModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppRoutingModule } from 'src/app/app-routing.module';



import { TitlebarModule } from 'src/app/shared/modules';
import { DepartmentService } from '../../services';
import { DepartmentComponent, DepartmentDetailComponent, DepartmentListComponent } from '../../components';



@NgModule({
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    NgbCollapseModule,
    NgbPaginationModule,
    NgbTooltipModule,
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
