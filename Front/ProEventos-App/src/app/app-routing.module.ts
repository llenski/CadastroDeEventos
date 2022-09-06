import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventosComponent } from './components/eventos/eventos.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';

const routes: Routes = [
  {path: "eventos", component: EventosComponent},
  {path: "contatos", component: ContatosComponent},
  {path: "dashboard", component: DashboardComponent},
  {path: "palestrantes", component: PalestrantesComponent},
  {path: "perfil", component: PerfilComponent},
  {path: "", redirectTo:"dashboard", pathMatch: 'full'},
  {path: "**", redirectTo:"dashboard", pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
