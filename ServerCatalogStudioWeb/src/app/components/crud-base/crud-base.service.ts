import { Injectable } from '@angular/core';
import { HttpAuthService } from 'app/helpers/http-auth.service';
import { ICrudModelBase } from 'app/components/crud-base/crud.model';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CrudBaseService {

  constructor(private http: HttpAuthService) { }
  public crear(crud: string, model: ICrudModelBase): Observable<any> {
    let ruta = this.ruta(crud);
    return this.http.post(ruta, model);
  }

  public modificar(crud: string, model: ICrudModelBase): Observable<any> {
    let ruta = `${this.ruta(crud)}/${model.id}`;
    return this.http.put(ruta, model);
  }

  public obtenerTodos(crud: string): Observable<Array<ICrudModelBase>> {
    let ruta = this.ruta(crud);
    return this.http.get(ruta);
  }

  public eliminar(crud: string, model: ICrudModelBase) {
    let ruta = `${this.ruta(crud)}/${model.id}`;
    return this.http.delete(ruta).subscribe();
  }

  ruta(path: string): string {
    return `${environment.api}/Maestros/${path}`;
  }
}
