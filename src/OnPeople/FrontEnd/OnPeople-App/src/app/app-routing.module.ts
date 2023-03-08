import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContaCadastroComponent } from './components/contas/contaCadastro/contaCadastro.component';
import { ContaLoginComponent } from './components/contas/contaLogin/contaLogin.component';
import { ContaPerfilComponent } from './components/contas/contaPerfil/contaPerfil.component';
import { ContasComponent } from './components/contas/contas.component';
import { EmpresasComponent } from './components/empresas/empresas.component';
import { EmpresasDetalheComponent } from './components/empresas/empresasDetalhe/empresasDetalhe.component';
import { EmpresasListaComponent } from './components/empresas/empresasLista/empresasLista.component';

const routes: Routes = [

  { path: 'contas', redirectTo: 'constas/perfil', pathMatch: 'full' },

  { path: 'empresas', redirectTo: 'empresas/lista', pathMatch: 'full' },
  { path: 'empresas', component: EmpresasComponent,
    children: [
      { path: 'detalhe/:id', component: EmpresasDetalheComponent },
      { path: 'detalhe', component: EmpresasDetalheComponent },
      { path: 'lista', component: EmpresasListaComponent },
    ] },

  { path: 'contas', component: ContasComponent,
    children: [
      { path: 'login', component: ContaLoginComponent },
      { path: 'cadastro', component: ContaCadastroComponent},
      { path: 'perfil', component: ContaPerfilComponent},
    ] },

  { path: '**', redirectTo: 'contas/cadastro', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
