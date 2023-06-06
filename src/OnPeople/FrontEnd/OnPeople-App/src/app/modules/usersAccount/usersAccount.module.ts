import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { BrowserModule } from "@angular/platform-browser";
import { MatCardModule } from '@angular/material/card';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";

import { NgxSpinnerModule } from "ngx-spinner";
import { ToastrModule } from "ngx-toastr";

import { AppRoutingModule } from "src/app/app-routing.module";

import {
  LoginLogoutService,
  UploadService,
  UserService
} from "src/app/services";

import { TitlebarModule } from "../titlebar";

import {
  LoginComponent,
  ProfileComponent,
  ProfileDetailComponent,
  RegisterComponent,
  UserComponent
} from "src/app/components";

@NgModule({
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    MatCardModule,
    MatDatepickerModule,
    MatIconModule,
    MatInputModule,
    MatNativeDateModule,
    MatSelectModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
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
    LoginLogoutService,
    UserService,
    UploadService
  ],
})
export class UsersAccountModule { }
