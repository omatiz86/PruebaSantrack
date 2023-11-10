import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormularioComponent } from './modules/formulario/formulario.component';
import { TablaComponent } from './modules/tabla/tabla.component';

import { HomeComponent } from './modules/home/home.component';
import { InicioComponent } from './modules/inicio/inicio.component';
import { RegistroComponent } from './modules/registro/registro.component';
import { GestionComponent } from './modules/gestion/gestion.component';
import { ProyeccionComponent } from './modules/proyeccion/proyeccion.component';
import { ConsultasComponent } from './modules/consultas/consultas.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FormularioComponent,
    TablaComponent,    
    InicioComponent,
    RegistroComponent,
    GestionComponent,
    ProyeccionComponent,
    ConsultasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
