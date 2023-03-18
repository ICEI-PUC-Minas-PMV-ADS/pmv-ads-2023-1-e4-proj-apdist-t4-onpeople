import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContaPerfilComponent } from './components/contas/contaPerfil/contaPerfil.component';
import { ContasComponent } from './components/contas/contas.component';
import { EmpresasComponent } from './components/empresas/empresas.component';
import { EmpresasDetalheComponent } from './components/empresas/empresasDetalhe/empresasDetalhe.component';
import { EmpresasListaComponent } from './components/empresas/empresasLista/empresasLista.component';
import { UserLoginComponent } from './components/users/userLogin/userLogin.component';
import { UserRegisterComponent } from './components/users/userRegister/userRegister.component';

const routes: Routes = [

  { path: 'users', redirectTo: 'users/profile', pathMatch: 'full' },

  { path: 'empresas', redirectTo: 'empresas/lista', pathMatch: 'full' },
  { path: 'empresas', component: EmpresasComponent,
    children: [
      { path: 'detalhe/:id', component: EmpresasDetalheComponent },
      { path: 'detalhe', component: EmpresasDetalheComponent },
      { path: 'lista', component: EmpresasListaComponent },
    ] },

  { path: 'users', component: ContasComponent,
    children: [
      { path: 'login', component: UserLoginComponent },
      { path: 'register', component: UserRegisterComponent},
      { path: 'perfil', component: ContaPerfilComponent},
    ] },

  { path: '**', redirectTo: 'users/register', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
