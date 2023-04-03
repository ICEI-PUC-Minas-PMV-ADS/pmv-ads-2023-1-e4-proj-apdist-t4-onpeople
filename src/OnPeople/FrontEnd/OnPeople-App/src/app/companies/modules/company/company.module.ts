import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { NgbCollapseModule, NgbPaginationModule, NgbTooltip, NgbTooltipModule,} from '@ng-bootstrap/ng-bootstrap';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppRoutingModule } from 'src/app/app-routing.module';

import { CompanyComponent, CompanyDetailComponent, CompanyListComponent } from '../../components';

import { TitlebarModule } from 'src/app/shared/modules';
import { DateTimeFormatPipeModule } from 'src/app/shared/modules';

@NgModule({
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    BsDatepickerModule.forRoot(),
    DateTimeFormatPipeModule,
    MatIconModule,
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
