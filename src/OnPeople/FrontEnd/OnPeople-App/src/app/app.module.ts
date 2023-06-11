import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';

import {
  CompanyModule,
  DashboardModule,
  DepartmentModule,
  EmployeeModule,
  JobRoleModule,
  GoalModule,
  NavbarModule,
  UsersAccountModule
} from "./modules";

@NgModule({
  declarations: [
    AppComponent,
   ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    CompanyModule,
    DashboardModule,
    DepartmentModule,
    EmployeeModule,
    JobRoleModule,
    GoalModule,
    NavbarModule,
    UsersAccountModule,
  ],

  providers: [
  ],

  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
  constructor() {

  }
 }
