import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTabsModule } from '@angular/material/tabs';
import { NgModule, } from '@angular/core';
import { FormsModule,  } from '@angular/forms';

import { NgChartsModule } from 'ng2-charts';

import { AppRoutingModule } from 'src/app/app-routing.module';
import { TitlebarModule } from '../titlebar';
import { DashCompanyComponent, DashGlobalComponent, DashboardComponent } from 'src/app/components';



@NgModule({
imports: [
  AppRoutingModule,
  BrowserAnimationsModule,
  BrowserModule,
  FormsModule,
  NgChartsModule,
  MatCardModule,
  MatIconModule,
  MatInputModule,
  MatSelectModule,
  MatTabsModule,
  TitlebarModule,
],
declarations: [
  DashboardComponent,
  DashGlobalComponent,
  DashCompanyComponent,
],
exports: [
  DashboardComponent,
  DashGlobalComponent,
  DashCompanyComponent,
],
  providers: [
],
})
export class DashboardModule { }

