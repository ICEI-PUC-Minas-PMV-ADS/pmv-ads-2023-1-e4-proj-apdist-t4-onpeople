import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmpresasComponent } from './components/empresas/empresas.component';
import { EmpresasListaComponent } from './components/empresas/empresasLista/empresasLista.component';

const routes: Routes = [
  { path: 'empresas', component: EmpresasComponent },
  { path: 'empresasLista', component: EmpresasListaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
