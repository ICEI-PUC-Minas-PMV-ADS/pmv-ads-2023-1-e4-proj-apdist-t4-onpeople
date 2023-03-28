import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { HttpClientModule } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { LoginComponent, ProfileComponent, ProfileDetailComponent, RegisterComponent, UserComponent } from '../../components';

import { DateTimeFormatPipeModule, TitlebarModule } from 'src/app/shared/modules';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { MatIconModule } from '@angular/material/icon';
import { DateTimeFormatPipe } from 'src/app/shared/models';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
import { NgbAlertModule, NgbCollapseModule, NgbPaginationModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { TabsModule } from 'ngx-tabset';
import { NgSelectModule } from '@ng-select/ng-select';
import { CompanyService } from 'src/app/companies/services';
import { LoginLogoutService } from '../../services/login';
import { UploadService } from 'src/app/shared/services';
import { UserService } from '../../services';

@NgModule({
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    BsDatepickerModule.forRoot(),
    DateTimeFormatPipeModule,
    FormsModule,
    HttpClientModule,
    MatIconModule,
    ModalModule.forRoot(),
    NgbAlertModule,
    NgbCollapseModule,
    NgbPaginationModule,
    NgbTooltipModule,
    NgxSpinnerModule,
    NgSelectModule,
    ReactiveFormsModule,
    TabsModule.forRoot(),
    TitlebarModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
  ],
  declarations: [
    LoginComponent,
    ProfileComponent,
    ProfileDetailComponent,
    RegisterComponent,
    UserComponent,
  ],
  exports: [
    LoginComponent,
    ProfileComponent,
    ProfileDetailComponent,
    RegisterComponent,
    UserComponent,
  ],
  providers: [
    CompanyService,
    LoginLogoutService,
    UploadService,
    UserService,
  ],
})
export class UsersAccountModule { }
