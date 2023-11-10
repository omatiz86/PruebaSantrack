import { Component } from '@angular/core';
import { RegistroService } from 'src/app/services/registro.service';
import { ActualizarService } from 'src/app/services/actualizar.service';
import { EliminarService } from 'src/app/services/eliminar.service';

import { IdataUno } from 'src/app/interface/idata-uno';
import { ICliente } from 'src/app/interface/i-cliente';
import { ITransaccion } from 'src/app/interface/i-transaccion';

@Component({
  selector: 'app-gestion',
  templateUrl: './gestion.component.html',
  styleUrls: ['./gestion.component.css']
})
export class GestionComponent {
  public dataUno:  IdataUno[] = [];
  public inputTransaccion:  ITransaccion = {
    IdProducto:'',
    Documento:'',
    TipoTransaccion: '',
    Monto:'',
    Fecha:new Date
  };
  public idCDT = {idCDT: ''};

  constructor(private registroService: RegistroService, private actualizarRegistros: ActualizarService, private EliminarRegistros: EliminarService) {
  }

  guardarTransaccion() {
    this.registroService.guardarTransaccion(this.inputTransaccion).subscribe((response) => {
      console.log('Data Transaccion', response);
      this.iFormularioTransaccion();  // Limpia el formulario
      console.log('Registro guardado con éxito', this.inputTransaccion);
    }, (error) => {
      console.error('Error al guardar el registro', error);
    });
    
  }

  
  cancelarProductCDT() {
    this.EliminarRegistros.eliminarCDT(this.idCDT.idCDT).subscribe((response) => {
      console.log('Data ProductCDT', response);
      this.iFormularioTransaccion();  // Limpia el formulario
      console.log('Registro guardado con éxito', this.inputTransaccion);
    }, (error) => {
      console.error('Error al guardar el registro', error);
    });
  }

  iFormularioTransaccion() {
    this.inputTransaccion = {
      IdProducto:'',
      Documento:'',
      TipoTransaccion: '',
      Monto:'',
      Fecha:new Date
    };
  }

}
