import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";

import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NavbarModule } from './shared/modules';
import { UsersAccountModule } from './users/modules';
import { CompanyModule } from './companies/modules';
import { DashboardModule } from './dashboards/components/modules';



defineLocale('pt-br', ptBrLocale);

@NgModule({
  declarations: [
    AppComponent,
   ],
  imports: [
    AppRoutingModule,
    NavbarModule,
    UsersAccountModule,
    CompanyModule,
    DashboardModule,

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
