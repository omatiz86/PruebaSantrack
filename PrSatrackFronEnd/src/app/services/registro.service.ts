import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { IUbicaciones } from 'src/app/interface/idata-uno';


@Injectable({
  providedIn: 'root'
})
export class RegistroService {

  //private apiUrl = 'https://jsonplaceholder.typicode.com/posts'; // Ejemplo de endpoint de JSONPlaceholder
  private endPonit:string = environment.endPoint;
  private apiGetInformacionCliente:string = this.endPonit + "api/ClienteBn/ObtenerInformacionCliente";
  private apiPostCrearCliente:string = this.endPonit + "api/ClienteBn/CrearCliente";
  private apiPostCrearTransaccion:string = this.endPonit + "api/ProcesosBanco/InsertarTransaccion";
  private apiGetUbicacion:string = this.endPonit + "api/BasicBn/ObtenerUbicacion";

  constructor(private http: HttpClient) {}

  guardarRegistro(nuevoRegistro: any) {
    return this.http.post(this.apiPostCrearCliente, nuevoRegistro);
  }

  obtenerRegistros() {
    return this.http.get(this.apiGetInformacionCliente);
  }

  guardarTransaccion(nuevoRegistro: any) {
    return this.http.post(this.apiPostCrearTransaccion, nuevoRegistro);
  }

  obtenerListUbucacion() {
    return this.http.get<IUbicaciones[]>(this.apiGetUbicacion);
  }

}
