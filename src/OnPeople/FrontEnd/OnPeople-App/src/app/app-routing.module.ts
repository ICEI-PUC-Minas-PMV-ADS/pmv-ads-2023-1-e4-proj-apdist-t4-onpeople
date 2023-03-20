import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmpresasComponent } from './components/empresas/empresas.component';
import { EmpresasDetalheComponent } from './components/empresas/empresasDetalhe/empresasDetalhe.component';
import { EmpresasListaComponent } from './components/empresas/empresasLista/empresasLista.component';
import { UserComponent } from './components/users/user.component';
import { UserLoginComponent } from './components/users/userLogin/userLogin.component';
import { UserProfileComponent } from './components/users/userProfile/userProfile.component';
import { UserRegisterComponent } from './components/users/userRegister/userRegister.component';
import { AuthGuard } from './helpers/guard/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'users/profile', pathMatch: 'full' },

  { path: '', runGuardsAndResolvers: 'always', canActivate: [AuthGuard], children: [

    { path: 'users', redirectTo: 'users/profile', pathMatch: 'full' },
    { path: 'users/profile', component: UserProfileComponent },

    { path: 'empresas', redirectTo: 'empresas/lista', pathMatch: 'full' },
    { path: 'empresas', component: EmpresasComponent,
      children: [
        { path: 'detalhe/:id', component: EmpresasDetalheComponent },
        { path: 'detalhe', component: EmpresasDetalheComponent },
        { path: 'lista', component: EmpresasListaComponent },
      ] },

  ] },

  { path: 'users', component: UserComponent,
    children: [
      { path: 'login', component: UserLoginComponent },
      { path: 'register', component: UserRegisterComponent},
    ] },

  { path: 'home', redirectTo: 'users/register', pathMatch: 'full'},
  { path: '**', redirectTo: 'users/register', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
