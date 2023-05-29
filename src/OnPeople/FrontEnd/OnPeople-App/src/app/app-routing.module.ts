import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from './shared/security';

import { CompanyComponent, CompanyDetailComponent, CompanyListComponent } from './companies/components';
import { DashboardComponent, DashCompanyComponent } from './dashboards/components';
import { DepartmentComponent, DepartmentDetailComponent, DepartmentListComponent } from './departments/components';
import { LoginComponent, ProfileComponent, RegisterComponent, UserComponent, } from './users/components';
import { JobRoleComponent, JobRoleDetailComponent, JobRoleListComponent } from './jobRoles/components';

const routes: Routes = [
  { path: '', redirectTo: 'users/profile', pathMatch: 'full' },

  { path: '', runGuardsAndResolvers: 'always', canActivate: [AuthGuard], children: [

    { path: 'users', redirectTo: 'users/profile', pathMatch: 'full' },

    { path: 'users', component: UserComponent,
      children: [
        { path: 'profile', component: ProfileComponent },
      ] },

    { path: 'empresas', redirectTo: 'empresas/list', pathMatch: 'full' },
    { path: 'empresas', component: CompanyComponent,
      children: [
        { path: 'detail/:id', component: CompanyDetailComponent },
        { path: 'detail', component: CompanyDetailComponent },
        { path: 'list', component: CompanyListComponent },
      ] },

    { path: 'departamentos', redirectTo: 'departamentos/list', pathMatch: 'full' },
    { path: 'departamentos', component: DepartmentComponent,
      children: [
        { path: 'detail/:id', component: DepartmentDetailComponent },
        { path: 'detail', component: DepartmentDetailComponent },
        { path: 'list', component: DepartmentListComponent },
      ] },

    { path: 'cargos', redirectTo: 'cargos/list', pathMatch: 'full' },
    { path: 'cargos', component: JobRoleComponent,
      children: [
        { path: 'detail/:id', component: JobRoleDetailComponent },
        { path: 'detail', component: JobRoleDetailComponent },
        { path: 'list', component: JobRoleListComponent },
      ] },

    { path: 'dashboards', redirectTo: 'dashboards/empresa', pathMatch: 'full' },
    { path: 'dashboards', component: DashboardComponent,
      children: [
        { path: 'empresa', component: DashCompanyComponent },
      ] },

  ] },

  { path: 'users', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent},
    ] },

  { path: 'home', redirectTo: 'users/register', pathMatch: 'full'},
  { path: '**', redirectTo: 'users/register', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
