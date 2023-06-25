import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';

import { NgbCollapseModule, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';

import { BsModalService } from 'ngx-bootstrap/modal';

import { AppRoutingModule } from 'src/app/app-routing.module';

import { JobRoleComponent, JobRoleDetailComponent, JobRoleListComponent } from 'src/app/components';

import { DepartmentService } from 'src/app/services';

import { SpinnerModule } from '../spinner';
import { TitlebarModule } from '../titlebar';


@NgModule({
  imports: [
    AppRoutingModule,
    BrowserModule,
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
    JobRoleComponent,
    JobRoleListComponent,
    JobRoleDetailComponent
  ],
  exports: [
    JobRoleComponent,
    JobRoleListComponent,
    JobRoleDetailComponent
  ],
  providers: [
    BsModalService,
    DepartmentService
  ],
})
export class JobRoleModule { }
