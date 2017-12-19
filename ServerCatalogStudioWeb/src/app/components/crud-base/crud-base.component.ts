import { Component, OnInit } from '@angular/core';
import { ICrudModelBase, CRUD_TIPO } from 'app/components/crud-base/crud.model';
import { Alertas } from 'app/helpers/alertas.service';
import { HttpAuthService } from 'app/helpers/http-auth.service';
import { CrudBaseService } from 'app/components/crud-base/crud-base.service';
import { error } from 'util';
import { Router, ActivatedRoute } from '@angular/router';
import { UrlSegment } from '@angular/router/src/url_tree';
import { helpers } from 'app/helpers/utils';

@Component({
  selector: 'app-crud-base',
  templateUrl: './crud-base.component.html',
  styleUrls: ['./crud-base.component.css']
})
export class CrudBaseComponent implements OnInit {

  public model: ICrudModelBase;
  public gridItems: ICrudModelBase[];
  private crudTipo: string;
  constructor(private crudBaseService: CrudBaseService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.model = {
      id: 0,
      descripcion: '',
      activo: true
    };
    this.inicializarTipoDeFormulario();
  }

  cargarGrid() {
    this.crudBaseService.obtenerTodos(this.crudTipo).subscribe(data => {
      this.gridItems = data;
    });
  }

  onCreateItem(item: ICrudModelBase) {
    console.log(item);
    this.cargarGrid();
  }

  onClickModificar(item: ICrudModelBase) {
    Alertas.load();
    this.model = item;    
    setTimeout(() => {
      Alertas.close();
    }, 250);
  }

  inicializarTipoDeFormulario() {
    this.route.url.subscribe(rutas => {

      if (this.esLaRuta(rutas, CRUD_TIPO.SistemasOperativos)) {
        this.crudTipo = CRUD_TIPO.SistemasOperativos;
        this.cargarGrid();
        return;
      }

      if (this.esLaRuta(rutas, CRUD_TIPO.Ambientes)) {
        this.crudTipo = CRUD_TIPO.Ambientes;
        this.cargarGrid();
        return;
      }

      if (this.esLaRuta(rutas, CRUD_TIPO.MotoresBasesDeDatos)) {
        this.crudTipo = CRUD_TIPO.MotoresBasesDeDatos;
        this.cargarGrid();
        return;
      }

    });
  }

  private esLaRuta(rutas: UrlSegment[], ruta: string) {
    let existe = rutas.find(route => route.path == ruta);
    return !helpers.isNull(existe);
  }

}
