import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { NgModule, } from '@angular/core';
import { FormsModule,  } from '@angular/forms';

import { AppRoutingModule } from 'src/app/app-routing.module';

import { DashCompanyComponent, DashboardComponent } from '../../components';
import { TitlebarModule } from 'src/app/shared/modules';
import { CompanyService } from 'src/app/companies/services';
import { DepartmentService } from 'src/app/departments/services';


@NgModule({
imports: [
  AppRoutingModule,
  BrowserAnimationsModule,
  BrowserModule,
  FormsModule,
  MatIconModule,
  MatInputModule,
  MatSelectModule,
  TitlebarModule,
],
declarations: [
  DashboardComponent,
  DashCompanyComponent,
],
exports: [
  DashboardComponent,
  DashCompanyComponent,
],
  providers: [
    CompanyService,
    DepartmentService
],
})
export class DashboardModule { }

