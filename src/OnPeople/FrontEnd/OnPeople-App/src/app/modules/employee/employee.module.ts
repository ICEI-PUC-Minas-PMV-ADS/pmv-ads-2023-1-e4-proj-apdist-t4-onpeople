import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';

import { AppRoutingModule } from 'src/app/app-routing.module';

import { NgbCollapseModule, NgbPaginationModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';

import { AddressComponent, EmployeeComponent, EmployeeDetailComponent, EmployeeListComponent, GoalAssociateComponent, MyGoalsComponent, PersonalDocumentsComponent,  } from 'src/app/components';

import { AddressService, CompanyService, DepartmentService, EmployeeService, JobRoleService, PersonalDocumentsService, UserService } from 'src/app/services';

import { SpinnerModule } from '../spinner';
import { TitlebarModule } from '../titlebar';

@NgModule({
  imports: [
    AppRoutingModule,
    BrowserModule,
    MatDatepickerModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    NgbCollapseModule,
    NgbPaginationModule,
    ReactiveFormsModule,
    SpinnerModule,
    TitlebarModule,
  ],
  declarations: [
    AddressComponent,
    EmployeeComponent,
    EmployeeDetailComponent,
    EmployeeListComponent,
    GoalAssociateComponent,
    MyGoalsComponent,
    PersonalDocumentsComponent,
  ],
  exports: [
    AddressComponent,
    EmployeeComponent,
    EmployeeDetailComponent,
    EmployeeListComponent,
    GoalAssociateComponent,
    PersonalDocumentsComponent
  ],
  providers: [
    AddressService,
    CompanyService,
    DepartmentService,
    EmployeeService,
    JobRoleService,
    MyGoalsComponent,
    PersonalDocumentsService,
    UserService
  ]
})
export class EmployeeModule { }
