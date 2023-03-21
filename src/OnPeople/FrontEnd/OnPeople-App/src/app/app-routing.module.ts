import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent, ProfileComponent, RegisterComponent, UserComponent, } from './users/components';
import { CompanyComponent, CompanyDetailComponent, CompanyListComponent } from './companys/components';

import { AuthGuard } from './shared/security';

const routes: Routes = [
  { path: '', redirectTo: 'users/profile', pathMatch: 'full' },

  { path: '', runGuardsAndResolvers: 'always', canActivate: [AuthGuard], children: [

    { path: 'users', redirectTo: 'users/profile', pathMatch: 'full' },

    { path: 'users', component: UserComponent,
      children: [
        { path: 'profile', component: ProfileComponent },
      ] },

    { path: 'empresas', redirectTo: 'empresas/lista', pathMatch: 'full' },
    { path: 'empresas', component: CompanyComponent,
      children: [
        { path: 'detalhe/:id', component: CompanyDetailComponent },
        { path: 'detalhe', component: CompanyDetailComponent },
        { path: 'lista', component: CompanyListComponent },
      ] },

  ] },

  { path: 'users', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent},
    ] },

  { path: 'home', redirectTo: 'users/register', pathMatch: 'full'},
  { path: '**', redirectTo: 'users/register', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
