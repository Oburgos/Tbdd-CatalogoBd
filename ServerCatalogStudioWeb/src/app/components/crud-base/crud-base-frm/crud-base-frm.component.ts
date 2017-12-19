import { Component, OnInit, Output, Input, ViewChild, EventEmitter } from '@angular/core';
import { ICrudModelBase } from 'app/components/crud-base/crud.model';
import { Alertas } from 'app/helpers/alertas.service';
import { CrudBaseService } from 'app/components/crud-base/crud-base.service';
import { DxTextBoxComponent } from 'devextreme-angular';

@Component({
  selector: 'app-crud-base-frm',
  templateUrl: './crud-base-frm.component.html',
  styleUrls: ['./crud-base-frm.component.css']
})
export class CrudBaseFrmComponent implements OnInit {

  @Input() public model: ICrudModelBase;
  @Input() public crudTipo: string;
  @Output() public onCreateItem = new EventEmitter<ICrudModelBase>();
  @Output() public onUpdateItem = new EventEmitter<ICrudModelBase>();

  @ViewChild('txtDescripcion')
  private txtDescripcion: DxTextBoxComponent;

  constructor(private crudBaseService: CrudBaseService) { }

  ngOnInit() {
  }

  private guardarAgregar(model: ICrudModelBase) {
    this.crudBaseService.crear(this.crudTipo, model).subscribe(res => {
      Alertas.ok('El registro se creó correctamente');
      this.onCreateItem.emit(res);
      console.log(res);
    }, error => {
      console.log(error);
      Alertas.showHttpResponse(error);
    });
  }

  private guardarModificar(model: ICrudModelBase) {
    this.crudBaseService.modificar(this.crudTipo, model).subscribe(res => {
      Alertas.ok('El registro se modificó correctamente');
      this.onUpdateItem.emit(model);
    }, error => {
      console.log(error);
      Alertas.showHttpResponse(error);
    });
  }

  public guardar(model: ICrudModelBase): void {
    if (!this.sonControlesValidos()) {
      return;
    }
    Alertas.load();
    if (this.model.id == 0) {
      this.guardarAgregar(model);
      return;
    }

    this.guardarModificar(model);
  }

  public cancelar() {
    this.model = {
      id: 0,
      descripcion: '',
      activo: true
    };
  }

  sonControlesValidos(): boolean {
    this.txtDescripcion.validator.adapter.validator.validate();
    if (!this.txtDescripcion.isValid) {
      this.txtDescripcion.validator.adapter.focus();
      return false;
    }
    return true;
  }

}
