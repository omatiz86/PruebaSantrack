import { Component } from '@angular/core';
import { RegistroService } from 'src/app/services/registro.service';
import { IdataUno } from 'src/app/interface/idata-uno';

@Component({
  selector: 'app-tabla',
  templateUrl: './tabla.component.html',
  styleUrls: ['./tabla.component.css']
})
export class TablaComponent {
  public dataUno:  IdataUno[] = [];
  registros: any[] = [];

  constructor(private registroService: RegistroService) {}
/*
  ngOnInit() {
    this.registroService.obtenerRegistros().subscribe((data: any) => { 
      console.log('Registro guardado con éxito', data);     
      this.dataUno = data;
    });
  }
  */

}