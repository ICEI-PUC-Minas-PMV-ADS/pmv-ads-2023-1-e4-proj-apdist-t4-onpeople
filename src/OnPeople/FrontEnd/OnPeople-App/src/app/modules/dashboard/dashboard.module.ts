import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTabsModule } from '@angular/material/tabs';
import { NgModule, } from '@angular/core';
import { FormsModule,  } from '@angular/forms';

import { AppRoutingModule } from 'src/app/app-routing.module';
import { TitlebarModule } from '../titlebar';
import { DashCompanyComponent, DashGlobalComponent, DashboardComponent } from 'src/app/components';
import { SpinnerModule } from '../spinner';
import { GoogleChartsModule } from 'angular-google-charts';
import { DashDepartmentComponent } from 'src/app/components/dashboard/dashDepartment';



@NgModule({
imports: [
  AppRoutingModule,
  BrowserAnimationsModule,
  BrowserModule,
  FormsModule,
  GoogleChartsModule,
  MatCardModule,
  MatIconModule,
  MatInputModule,
  MatSelectModule,
  MatTabsModule,
  SpinnerModule,
  TitlebarModule,
],
declarations: [
  DashboardComponent,
  DashCompanyComponent,
  DashDepartmentComponent,
  DashGlobalComponent,
],
exports: [
  DashboardComponent,
  DashCompanyComponent,
  DashDepartmentComponent,
  DashGlobalComponent,
],
  providers: [
],
})
export class DashboardModule { }

