import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';

import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { NgbCollapseModule, NgbPaginationModule, NgbTooltipModule,} from '@ng-bootstrap/ng-bootstrap';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppRoutingModule } from 'src/app/app-routing.module';

import {
  CompanyComponent,
  CompanyDetailComponent,
  CompanyListComponent
} from '../../components';

import { TitlebarModule } from 'src/app/shared/modules';
import { MatFormFieldModule } from '@angular/material/form-field';

@NgModule({
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    BsDatepickerModule.forRoot(),
    MatDatepickerModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatSelectModule,
    MatToolbarModule,
    NgbCollapseModule,
    NgbPaginationModule,
    NgbTooltipModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    TitlebarModule,
  ],
  declarations: [
    CompanyComponent,
    CompanyListComponent,
    CompanyDetailComponent,
  ],
  exports: [
    CompanyComponent,
    CompanyListComponent,
    CompanyDetailComponent,
  ],
  providers: [
  ],
})
export class CompanyModule { }
