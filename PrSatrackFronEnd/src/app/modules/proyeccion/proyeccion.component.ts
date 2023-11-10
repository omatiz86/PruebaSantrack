import { Component } from '@angular/core';
import { ReportesService } from 'src/app/services/reportes.service';  
import { IProyeccion } from 'src/app/interface/i-proyeccion';

@Component({
  selector: 'app-proyeccion',
  templateUrl: './proyeccion.component.html',
  styleUrls: ['./proyeccion.component.css']
})
export class ProyeccionComponent {
  dataPromedio: IProyeccion[] = [];
  
  constructor(private reportesService :ReportesService) {}

  ngOnInit() {

    this.reportesService.obtenerReReporteMesaMes().subscribe((data: any) => { 
        console.log('Reporte data', data);     
        this.dataPromedio = data;
      });
  }
}
