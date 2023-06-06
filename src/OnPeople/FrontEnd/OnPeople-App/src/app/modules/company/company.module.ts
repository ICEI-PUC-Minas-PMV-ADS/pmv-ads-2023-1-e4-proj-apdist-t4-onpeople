import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { BrowserModule } from "@angular/platform-browser";
import { ReactiveFormsModule } from "@angular/forms";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatNativeDateModule } from "@angular/material/core";
import { MatSelectModule } from "@angular/material/select";
import { MatToolbarModule } from "@angular/material/toolbar";
import { NgbCollapseModule, NgbPaginationModule, NgbTooltipModule } from "@ng-bootstrap/ng-bootstrap";
import { NgModule } from "@angular/core";

import { BsModalService } from "ngx-bootstrap/modal";
import { NgxSpinnerModule } from "ngx-spinner";

import { AppRoutingModule } from "src/app/app-routing.module";

import { CompanyComponent, CompanyDetailComponent, CompanyListComponent } from "src/app/components";

import { TitlebarModule } from "../titlebar";

import { CompanyService } from "src/app/services";

@NgModule({
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    MatDatepickerModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatSelectModule,
    MatToolbarModule,
    NgbCollapseModule,
    NgbTooltipModule,
    NgbPaginationModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    TitlebarModule,
  ],
  declarations: [
    CompanyComponent,
    CompanyListComponent,
    CompanyDetailComponent,
  ],
  exports: [
    CompanyComponent,
    CompanyListComponent,
    CompanyDetailComponent,
  ],
  providers: [
    CompanyService,
    BsModalService,
  ],
})
export class CompanyModule { }
