import { Component } from '@angular/core';
import { RegistroService } from 'src/app/services/registro.service';
import { ActualizarService } from 'src/app/services/actualizar.service';
import { IUbicaciones } from 'src/app/interface/idata-uno';
import { ICliente } from 'src/app/interface/i-cliente';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent {
  public dataTable:  ICliente[] = [];
  dataHtml: ICliente [] = [];
  inputHtml: ICliente = {
    idcliente: 0,
    nombre: '',
    tipoDocumento: '',
    documento: 0,
    nit: '0',
    tipoCliente: '',
    telefonoContacto: '',
    fechaNacimiento: new Date(),
    direccion: '',
    idUbicacion: '',
    correoElectronico: '',
    genero: '',
    notas: ''
  };
  //ubicaciones: IUbicaciones = {idUbicacion:null ,codDivipola:'',descripcion:null }
  ubicaciones: IUbicaciones [] = [];

  constructor(private registroService: RegistroService, private actualizarResgistros: ActualizarService) {

  }

  
  ngOnInit() {
    this.registroService.obtenerRegistros().subscribe((response: any) => { 
      console.log('Obtener con éxito', response);     
      this.dataTable = response.data; // Mapea los datos al formato esperado      
      console.log('Data registrada en la tabla', this.dataTable); 
    });

    this.registroService.obtenerListUbucacion().subscribe((data: IUbicaciones[]) => {
      console.log('Ubicaciones', data);    
      this.ubicaciones = data;
    });
    
  }

  guardarRegistro() {
    this.registroService.guardarRegistro(this.inputHtml).subscribe((response) => {
      console.log('Data Envio', response);
      this.limpiarFormulario();  // Limpia el formulario
      console.log('Registro guardado con éxito', this.inputHtml);      
    }, (error) => {
      console.error('Error al guardar el registro', error);
    });
    this.registroService.obtenerRegistros()
  }

  actualizarRegistro() {
    this.actualizarResgistros.actualizarRegistro(this.inputHtml).subscribe((response) => {
      console.log('Data Envio', response);
      this.limpiarFormulario();  // Limpia el formulario
      console.log('Registro guardado con éxito', this.inputHtml);
    }, (error) => {
      console.error('Error al guardar el registro', error);
    });
  }



  limpiarFormulario() {
    this.inputHtml = {
      idcliente: 0,
      nombre: '',
      tipoDocumento: '',
      documento: 0,
      nit: '',
      tipoCliente: '',
      telefonoContacto: '',
      fechaNacimiento: new Date(),
      direccion: '',
      idUbicacion: '',
      correoElectronico: '',
      genero: '',
      notas: ''
    };
  }

}