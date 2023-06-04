import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbCollapseModule, NgbPaginationModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppRoutingModule } from 'src/app/app-routing.module';

import { JobRoleComponent, JobRoleDetailComponent, JobRoleListComponent } from '../../components';

import { TitlebarModule } from 'src/app/shared/modules';
import { JobRoleService } from '../../services';
import { DepartmentService } from 'src/app/departments/services';
import { FilterPipeModule } from 'ngx-filter-pipe';


@NgModule({
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    FilterPipeModule,
    FormsModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatToolbarModule,
    NgbCollapseModule,
    NgbPaginationModule,
    NgbTooltipModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
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
    DepartmentService,
    JobRoleService
  ],
})
export class JobRoleModule { }
