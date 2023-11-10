import { Component } from '@angular/core';
import { ReportesService } from 'src/app/services/reportes.service';
import { IMercadeoPromedio } from 'src/app/interface/i-mercadeo';
import { IMercadeoTop } from 'src/app/interface/i-mercadeo';

@Component({
  selector: 'app-consultas',
  templateUrl: './consultas.component.html',
  styleUrls: ['./consultas.component.css']
})
export class ConsultasComponent {
  public reportePromedio:  IMercadeoPromedio[] = [];
  public reporteTop:  IMercadeoTop[] = [];


  constructor(private reportesService: ReportesService) {}

    ngOnInit() {
      
      this.reportesService.obtenerReReportePromedio().subscribe((data: any) => { 
        console.log('Registro guardado con éxito', data);     
        this.reportePromedio = data;
      });

      this.reportesService.obtenerReReporteTop().subscribe((data: any) => { 
        console.log('Registro guardado con éxito', data);     
        this.reporteTop = data;
      });

    }
  


}
