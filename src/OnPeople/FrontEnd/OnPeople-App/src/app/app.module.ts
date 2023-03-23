import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";

import { NgSelectModule } from '@ng-select/ng-select';

import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { far } from '@fortawesome/free-regular-svg-icons';

import { NgbAlertModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
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


import { LoginComponent,   ProfileComponent, ProfileDetailComponent, RegisterComponent,  UserComponent, } from './users/components';
import { CompanyComponent, CompanyDetailComponent, CompanyListComponent } from './companys/components';
import { NavbarComponent } from './shared/components';
import { TitlebarComponent } from './shared/components';
import { DashboardComponent, DashCompanyComponent } from './dashboards/components';

import { LoginLogoutService, UserService } from './users/services';
import { CompanyService } from './companys/services';
import { UploadService } from './shared/services';

import { AuthGuard, JwtInterceptor } from './shared/security';

import { DateTimeFormatPipe } from './shared/models';



defineLocale('pt-br', ptBrLocale);

@NgModule({
  declarations: [
    AppComponent,
    TitlebarComponent,
    DashboardComponent,
    DashCompanyComponent,
    DateTimeFormatPipe,
    CompanyComponent,
    CompanyDetailComponent,
    CompanyListComponent,
    NavbarComponent,
    LoginComponent,
    ProfileComponent,
    ProfileDetailComponent,
    RegisterComponent,
    UserComponent,
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
    NgbPaginationModule,
    NgbTooltipModule,
    NgxSpinnerModule,
    NgSelectModule,
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
    CompanyService,
    LoginLogoutService,
    UploadService,
    UserService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
  constructor(library: FaIconLibrary) {
    library.addIconPacks(fas, far);
  }
 }
