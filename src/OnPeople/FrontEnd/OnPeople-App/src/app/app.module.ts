import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";

import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NavbarModule } from './shared/modules';
import { CompanyModule } from './companies/modules';
import { DepartmentModule } from "./departments/modules";
import { UsersAccountModule } from "./users/modules";
import { DashboardModule } from "./dashboards/modules";
import { JobRoleModule } from "./jobRoles/modules";
import { EmployeeModule } from "./employees/modules";

defineLocale('pt-br', ptBrLocale);

@NgModule({
  declarations: [
    AppComponent,
   ],
  imports: [
    AppRoutingModule,
    CompanyModule,
    DashboardModule,
    DepartmentModule,
    EmployeeModule,
    JobRoleModule,
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
