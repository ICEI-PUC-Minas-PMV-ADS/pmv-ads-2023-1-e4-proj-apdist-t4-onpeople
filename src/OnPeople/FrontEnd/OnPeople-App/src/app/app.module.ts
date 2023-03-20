import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
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

import { DateTimeFormatPipe } from './helpers/pipe/DateTimeFormat/DateTimeFormat.pipe';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CabecalhoTelaComponent } from './components/shared/cabecalhoTela/cabecalhoTela.component';
import { EmpresasComponent } from './components/empresas/empresas.component';
import { EmpresasDetalheComponent } from './components/empresas/empresasDetalhe/empresasDetalhe.component';
import { EmpresasListaComponent } from './components/empresas/empresasLista/empresasLista.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { UserComponent } from './components/users/user.component';
import { UserLoginComponent } from './components/users/userLogin/userLogin.component';
import { UserProfileComponent } from './components/users/userProfile/userProfile.component';
import { UserProfileDetalheComponent } from './components/users/userProfile/userProfileDetalhe/userProfileDetalhe.component';
import { UserRegisterComponent } from './components/users/userRegister/userRegister.component';

import { JwtInterceptor } from './helpers/interceptors/jwt.interceptor';
import { AuthGuard } from './helpers/guard/auth.guard';

import { EmpresasService } from './services/empresas/Empresas.service';
import { LoginLogoutService } from './services/users/login/loginLogout.service';
import { UploadsService } from './services/uploads/uploads.service';
import { UserService } from './services/users/user/user.service';

defineLocale('pt-br', ptBrLocale);

@NgModule({
  declarations: [
    AppComponent,
    CabecalhoTelaComponent,
    DateTimeFormatPipe,
    EmpresasComponent,
    EmpresasDetalheComponent,
    EmpresasListaComponent,
    NavbarComponent,
    UserComponent,
    UserLoginComponent,
    UserProfileComponent,
    UserProfileDetalheComponent,
    UserRegisterComponent,
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
  providers: [
    AuthGuard,
    EmpresasService,
    LoginLogoutService,
    UploadsService,
    UserService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
