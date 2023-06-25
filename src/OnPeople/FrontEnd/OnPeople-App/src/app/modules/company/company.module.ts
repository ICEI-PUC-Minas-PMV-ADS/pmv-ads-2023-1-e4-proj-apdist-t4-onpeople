import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";

import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatTooltipModule } from "@angular/material/tooltip";

import { NgbCollapseModule, NgbPaginationModule } from "@ng-bootstrap/ng-bootstrap";

import { BsModalService } from "ngx-bootstrap/modal";

import { AppRoutingModule } from "src/app/app-routing.module";

import { CompanyComponent, CompanyDetailComponent, CompanyListComponent } from "src/app/components";

import { CompanyService } from "src/app/services";

import { SpinnerModule } from "../spinner";
import { TitlebarModule } from "../titlebar";


@NgModule({
  imports: [
    AppRoutingModule,
    BrowserModule,
    MatDatepickerModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatToolbarModule,
    MatTooltipModule,
    NgbCollapseModule,
    NgbPaginationModule,
    ReactiveFormsModule,
    SpinnerModule,
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
    BsModalService,
    CompanyService,
  ],
})
export class CompanyModule { }
