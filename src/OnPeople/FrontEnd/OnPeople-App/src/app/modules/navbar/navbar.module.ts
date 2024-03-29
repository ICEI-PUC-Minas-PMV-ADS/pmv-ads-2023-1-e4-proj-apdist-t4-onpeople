import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgbCollapseModule, NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";

import { AppRoutingModule } from "src/app/app-routing.module";

import { NavbarComponent } from "src/app/components";

import { AuthGuard } from "src/app/shared/security/guard";

import { JwtInterceptor } from "src/app/shared/security/interceptors";

@NgModule({
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    NgbDropdownModule,
    NgbCollapseModule,
  ],
  declarations: [
    NavbarComponent,
  ],
  exports: [
    NavbarComponent
  ],
  providers: [
    AuthGuard,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
  ]
})
export class NavbarModule { }
