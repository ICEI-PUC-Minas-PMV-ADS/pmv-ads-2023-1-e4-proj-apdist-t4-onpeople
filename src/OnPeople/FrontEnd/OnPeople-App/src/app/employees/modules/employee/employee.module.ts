import { AppRoutingModule } from 'src/app/app-routing.module';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbPaginationModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';

import {
  AddressComponent,
  EmployeeComponent,
  EmployeeDetailComponent,
  EmployeeListComponent,
  PersonalDocumentsComponent
} from '../../components';
import { TitlebarModule } from 'src/app/shared/modules';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NgxViacepModule } from "@brunoc/ngx-viacep";

@NgModule({
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    MatDatepickerModule,
    MatIconModule,
    MatInputModule,
    MatNativeDateModule,
    MatSelectModule,
    MatTabsModule,
    MatToolbarModule,
    NgbCollapseModule,
    NgbPaginationModule,
    NgbTooltipModule,
    NgxSpinnerModule,
    NgxViacepModule,
    ReactiveFormsModule,
    TitlebarModule,
  ],
  declarations: [
    AddressComponent,
    EmployeeComponent,
    EmployeeDetailComponent,
    EmployeeListComponent,
    PersonalDocumentsComponent,
  ],
  exports: [
    AddressComponent,
    EmployeeComponent,
    EmployeeDetailComponent,
    EmployeeListComponent,
    PersonalDocumentsComponent,
  ]
})
export class EmployeeModule { }
