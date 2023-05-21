import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobRoleComponent, JobRoleDetailComponent, JobRoleListComponent } from '../../components';
import { TitlebarModule } from 'src/app/shared/modules';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { MatIconModule } from '@angular/material/icon';
import { NgbPaginationModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';


@NgModule({
  imports: [
    AppRoutingModule,
    CommonModule,
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    MatIconModule,
    NgbPaginationModule,
    NgbTooltipModule,
    NgSelectModule,
    NgxSpinnerModule,
    TitlebarModule
  ],
  declarations: [
    JobRoleComponent,
    JobRoleListComponent,
    JobRoleDetailComponent
  ],
  exports: [
    JobRoleComponent,
    JobRoleListComponent,
    JobRoleDetailComponent
  ]
})
export class JobRoleModule { }
