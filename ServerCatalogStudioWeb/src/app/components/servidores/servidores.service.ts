import { Injectable } from '@angular/core';
import { HttpAuthService } from 'app/helpers/http-auth.service';
import { Observable } from 'rxjs/Observable';
import { Servidor } from 'app/components/servidores/models/servidor.model';
import { environment } from 'environments/environment';

@Injectable()
export class ServidoresService {

  constructor(private http: HttpAuthService) { }
  public crear(model: Servidor): Observable<any> {
    console.log(model);
    let ruta = `${environment.api}/servidores`
    return this.http.post(ruta, model);
  }

  public obtenerServidores(): Observable<any> {
    let ruta = `${environment.api}/servidores`
    return this.http.get(ruta);
  }
}
