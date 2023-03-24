import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgSelectModule } from '@ng-select/ng-select';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { TitlebarModule } from 'src/app/shared/modules';
import { DashboardComponent, DashCompanyComponent } from '../../dashboard';

@NgModule({
imports: [
  AppRoutingModule,
  BrowserAnimationsModule,
  BrowserModule,
  FormsModule,
  MatIconModule,
  NgSelectModule,
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
],
})
export class DashboardModule { }
