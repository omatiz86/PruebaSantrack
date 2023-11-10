import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class EliminarService {
  private endPonit:string = environment.endPoint;
  private apiUrl:string = this.endPonit + "api/ClienteBn/";

  constructor(private http: HttpClient) {}
  

  
  eliminarRegistro(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url);
  }

  eliminarCDT(id: string): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url);
  }

}
