import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './shared/security/guard';
import {
  CompanyComponent, CompanyDetailComponent, CompanyListComponent,
  DashCompanyComponent, DashboardComponent,
  DepartmentComponent, DepartmentDetailComponent, DepartmentListComponent,
  EmployeeComponent, EmployeeDetailComponent, EmployeeListComponent,
  JobRoleComponent, JobRoleDetailComponent, JobRoleListComponent,
  LoginComponent,
  MetaComponent,
  MetaListComponent,
  ProfileComponent,
  RegisterComponent,
  UserComponent
} from './components';

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
      ]
    },

    { path: 'funcionarios', redirectTo: 'funcionarios/list', pathMatch: 'full' },
    { path: 'funcionarios', component: EmployeeComponent,
      children: [
        { path: 'detail/:id', component: EmployeeDetailComponent },
        { path: 'detail', component: EmployeeDetailComponent },
        { path: 'list', component: EmployeeListComponent },
      ] },

    { path: 'metas', redirectTo: 'metas/list', pathMatch: 'full' },
    { path: 'metas', component: MetaComponent,
      children: [
        { path: 'detail/:id', component: EmployeeDetailComponent },
        { path: 'detail', component: EmployeeDetailComponent },
        { path: 'list', component: MetaListComponent },
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
