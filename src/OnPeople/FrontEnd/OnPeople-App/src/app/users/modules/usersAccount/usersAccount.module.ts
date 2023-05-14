import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatIconModule } from "@angular/material/icon";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgbAlertModule, NgbCollapseModule, NgbPaginationModule, NgbTooltipModule } from "@ng-bootstrap/ng-bootstrap";
import { NgSelectModule } from "@ng-select/ng-select";
import { BsDatepickerModule } from "ngx-bootstrap/datepicker";
import { ModalModule } from "ngx-bootstrap/modal";
import { NgxSpinnerModule } from "ngx-spinner";
import { TabsModule } from "ngx-tabset";
import { ToastrModule } from "ngx-toastr";
import { AppRoutingModule } from "src/app/app-routing.module";
import { DateTimeFormatPipeModule, TitlebarModule } from "src/app/shared/modules";
import { LoginComponent, ProfileComponent, ProfileDetailComponent, RegisterComponent, UserComponent } from "../../components";
import { CompanyService } from "src/app/companies/services";
import { LoginLogoutService } from "../../services/login";
import { UploadService } from "src/app/shared/services";
import { UserService } from "../../services";


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
