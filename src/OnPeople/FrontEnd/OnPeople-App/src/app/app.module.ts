import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { NgbAlertModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbTooltipModule} from '@ng-bootstrap/ng-bootstrap';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxSpinnerModule } from "ngx-spinner";
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CabecalhoTelaComponent } from './components/shared/cabecalhoTela/cabecalhoTela.component';
import { ContaCadastroComponent } from './components/contas/contaCadastro/contaCadastro.component';
import { ContaLoginComponent } from './components/contas/contaLogin/contaLogin.component';
import { ContaPerfilComponent } from './components/contas/contaPerfil/contaPerfil.component';
import { ContaPerfilDetalheComponent } from './components/contas/contaPerfil/contaPerfilDetalhe/contaPerfilDetalhe.component';
import { ContaPerfilSenhaComponent } from './components/contas/contaPerfil/contaPerfilSenha/contaPerfilSenha.component';
import { ContasComponent } from './components/contas/contas.component';
import { DateTimeFormatPipe } from './helpers/pipe/DateTimeFormat/DateTimeFormat.pipe';
import { EmpresasComponent } from './components/empresas/empresas.component';
import { EmpresasDetalheComponent } from './components/empresas/empresasDetalhe/empresasDetalhe.component';
import { EmpresasListaComponent } from './components/empresas/empresasLista/empresasLista.component';
import { EmpresasService } from './services/empresas/Empresas.service';
import { NavbarComponent } from './components/shared/navbar/navbar.component';

defineLocale('pt-br', ptBrLocale);

@NgModule({
  declarations: [
    AppComponent,
    CabecalhoTelaComponent,
    ContaCadastroComponent,
    ContaLoginComponent,
    ContaPerfilComponent,
    ContaPerfilDetalheComponent,
    ContaPerfilSenhaComponent,
    ContasComponent,
    DateTimeFormatPipe,
    EmpresasComponent,
    EmpresasDetalheComponent,
    EmpresasListaComponent,
    NavbarComponent,
   ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    BsDatepickerModule.forRoot(),
    FontAwesomeModule,
    FormsModule,
    HttpClientModule,
    ModalModule.forRoot(),
    NgbAlertModule,
    NgbDropdownModule,
    NgbCollapseModule,
    NgbTooltipModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    TabsModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
  ],
  providers: [EmpresasService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
