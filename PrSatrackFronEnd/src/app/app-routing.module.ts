import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './modules/home/home.component';
import { InicioComponent } from './modules/inicio/inicio.component';
import { RegistroComponent } from './modules/registro/registro.component';
import { GestionComponent } from './modules/gestion/gestion.component';
import { ProyeccionComponent } from './modules/proyeccion/proyeccion.component';
import { ConsultasComponent } from './modules/consultas/consultas.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' }, // Ruta por defecto
  { path: 'home', component: HomeComponent },
  { path: '', component: InicioComponent },
  { path: 'registro', component: RegistroComponent },
  { path: 'gestion', component: GestionComponent },
  { path: 'proyeccion', component: ProyeccionComponent },
  { path: 'consultas', component: ConsultasComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
