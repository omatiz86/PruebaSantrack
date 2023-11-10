import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ActualizarService {

  private apiUrl = 'tu_url_del_servicio'; 

  constructor(private http: HttpClient) {}

  actualizarRegistro(registro: any): Observable<any> {
    const url = `${this.apiUrl}/${registro.id}`; 
    return this.http.put(url, registro);
  }
}
