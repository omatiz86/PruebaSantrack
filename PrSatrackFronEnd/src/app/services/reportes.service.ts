import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ReportesService {
  
  private endPonit:string = environment.endPoint;
  private apiGetReporteMesaMes:string = this.endPonit + "api/ReportBn/ProyeccionMesaMes";
  private apiGetReportePromedio:string = this.endPonit + "api/ReportBn/MercadeoSaldoPromedio";
  private apiGetReporteTop:string = this.endPonit + "api/ReportBn/TopClientesPorProducto";

  constructor(private http: HttpClient) {}

  obtenerReReporteMesaMes() {
    return this.http.get(this.apiGetReporteMesaMes);
  }

  obtenerReReportePromedio() {
    return this.http.get(this.apiGetReportePromedio);
  }

  obtenerReReporteTop() {
    return this.http.get(this.apiGetReporteTop);
  }


  
}
