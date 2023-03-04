import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';


import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { ContasComponent } from './contas/contas.component';
import { EmpresasComponent } from './empresas/empresas.component';
import { NavbarComponent } from './shared/navbar/navbar.component';





@NgModule({
  declarations: [
    AppComponent,
    ContasComponent,
    EmpresasComponent,
    NavbarComponent,
   ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    CollapseModule.forRoot(),
    FontAwesomeModule,
    FormsModule,
    HttpClientModule,
    TooltipModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
