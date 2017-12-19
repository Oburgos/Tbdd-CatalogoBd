import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ICrudModelBase } from 'app/components/crud-base/crud.model';
import { CrudBaseService } from 'app/components/crud-base/crud-base.service';
import { Alertas } from 'app/helpers/alertas.service';

@Component({
  selector: 'app-crud-base-grid',
  templateUrl: './crud-base-grid.component.html',
  styleUrls: ['./crud-base-grid.component.css']
})
export class CrudBaseGridComponent implements OnInit {

  @Input() items: ICrudModelBase[];
  @Input() public crudTipo: string;
  @Output() public onClickModificar = new EventEmitter<ICrudModelBase>();

  constructor(private crudBaseService: CrudBaseService) { }

  ngOnInit() {
  }


  eliminar(item: ICrudModelBase) {
    Alertas.question('¿Está seguro que desea eliminar el registro?')
      .then((accion) => {
        if (!accion) {
          return;
        }
        let index = this.items.indexOf(item);
        this.items.splice(index, 1);
        this.crudBaseService.eliminar(this.crudTipo, item);
      });
  }

  clickModificar(item: ICrudModelBase){
    this.onClickModificar.emit(item);
  }

}
