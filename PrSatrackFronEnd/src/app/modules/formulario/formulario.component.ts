import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { RegistroService } from 'src/app/services/registro.service';
import { ActualizarService } from 'src/app/services/actualizar.service';
import { IdataUno } from 'src/app/interface/idata-uno';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.css']
})

export class FormularioComponent {
  public dataUno:  IdataUno[] = [];
  inputHtml = { nombre:'', email: '' }; 

  constructor(private registroService: RegistroService, private actualizarResgistros: ActualizarService) {

  }

  guardarRegistro() {
    this.registroService.guardarRegistro(this.inputHtml).subscribe((response) => {
      console.log('Data Envio', response);
      this.inputHtml = { nombre:'', email: '' }; // Limpia el formulario
      console.log('Registro guardado con éxito', this.inputHtml);
    }, (error) => {
      console.error('Error al guardar el registro', error);
    });
  }

  actualizarRegistro() {
    this.actualizarResgistros.actualizarRegistro(this.inputHtml).subscribe((response) => {
      console.log('Data Envio', response);
      this.inputHtml = { nombre:'', email: '' }; // Limpia el formulario
      console.log('Registro guardado con éxito', this.inputHtml);
    }, (error) => {
      console.error('Error al guardar el registro', error);
    });
  }


}


