import { Component, OnInit, ViewChild } from '@angular/core';
import { Servidor } from 'app/components/servidores/models/servidor.model';
import { CrudBaseService } from 'app/components/crud-base/crud-base.service';
import { CRUD_TIPO } from 'app/components/crud-base/crud.model';
import { element } from 'protractor';
import { Alertas } from 'app/helpers/alertas.service';
import { ServidoresService } from 'app/components/servidores/servidores.service';
import { DxTextBoxComponent, DxSelectBoxComponent } from 'devextreme-angular';
import { Router } from '@angular/router';

@Component({
  selector: 'app-servidores-frm',
  templateUrl: './servidores-frm.component.html',
  styleUrls: ['./servidores-frm.component.css']
})
export class ServidoresFrmComponent implements OnInit {
  public servidor: Servidor;
  public modoAgregar: boolean = true;
  public showModalConfiguarciones = false;
  public ambientes = [];
  public motoresBasesDeDatos = [];
  public sistemasOperativos = [];

  constructor(private crudBaseService: CrudBaseService, private servidoresService: ServidoresService,  private route: Router) { }

  goToServers(): void {
    this.route.navigate(['/servidores']);
  }

  ngOnInit() {
    this.servidor = new Servidor();
    this.cargarInformacionBase();
  }


  cargarInformacionBase() {
    this.crudBaseService.obtenerTodos(CRUD_TIPO.Ambientes).subscribe(elementos => {
      this.ambientes = elementos;
    });

    this.crudBaseService.obtenerTodos(CRUD_TIPO.SistemasOperativos).subscribe(elementos => {
      this.sistemasOperativos = elementos;
    });

    this.crudBaseService.obtenerTodos(CRUD_TIPO.MotoresBasesDeDatos).subscribe(elementos => {
      this.motoresBasesDeDatos = elementos;
    });
  }


  private guardarAgregar(model: Servidor) {
    this.servidoresService.crear(model).subscribe(res => {
      Alertas.ok('El registro se creó correctamente');
      console.log(res);
      this.goToServers();
    }, error => {
      console.log(error);
      Alertas.showHttpResponse(error);
    });
  }

  private guardarModificar(model: Servidor) {
    // this.servidoresService.modificar(model).subscribe(res => {
    //   Alertas.ok('El registro se modificó correctamente');
    // }, error => {
    //   console.log(error);
    //   Alertas.showHttpResponse(error);
    // });
  }

  public guardar(model: Servidor): void {
    if (!this.sonControlesValidos()) {
      return;
    }
    Alertas.load();
    if (this.servidor.id == 0) {
      this.guardarAgregar(model);
      return;
    }

    this.guardarModificar(model);
  }

  @ViewChild('txtDescripcion')
  private txtDescripcion: DxTextBoxComponent;

  @ViewChild('cmbSistemaOperativo')
  private cmbSistemaOperativo: DxSelectBoxComponent;

  @ViewChild('cmbAmbiente')
  private cmbAmbiente: DxSelectBoxComponent;

  @ViewChild('cmbMotorBaseDeDatos')
  private cmbMotorBaseDeDatos: DxSelectBoxComponent;

  sonControlesValidos(): boolean {

    if (!this.esControlValido(this.txtDescripcion)) {
      return false;
    }


    if (this.servidor.sistemaOperativoId == 0) {
      this.cmbSistemaOperativo.validator.adapter.focus();
      return false;
    }

    if (this.servidor.ambienteId == 0) {
      this.cmbAmbiente.validator.adapter.focus();
      return false;
    }

    return this.validarFormularioConexion();
  }

  esControlValido(control: any): boolean {
    control.validator.adapter.validator.validate();
    if (!control.isValid) {
      control.validator.adapter.focus();
      return false;
    }
    return true;
  }

  @ViewChild('txtUsuario')
  private txtUsuario: DxTextBoxComponent;
  @ViewChild('txtClave')
  private txtClave: DxTextBoxComponent;
  @ViewChild('txtDireccion')
  private txtDireccion: DxTextBoxComponent;
  
  @ViewChild('txtPuerto')
  private txtPuerto: DxTextBoxComponent;

  validarFormularioConexion() {
    if (this.servidor.configuracion.motorBaseDeDatosId == 0) {
      this.showModalConfiguarciones = true;
      setTimeout(() => {
        this.cmbMotorBaseDeDatos.validator.adapter.focus();
      }, 10);
      return false;
    }

    if (this.servidor.configuracion.usuario == '') {
      this.showModalConfiguarciones = true;
      setTimeout(() => {
        this.txtUsuario.validator.adapter.focus();
      }, 10);
      return false;
    }

    if (this.servidor.configuracion.clave == '') {
      this.showModalConfiguarciones = true;
      setTimeout(() => {
        this.txtClave.validator.adapter.focus();
      }, 10);
      return false;
    }

    if (this.servidor.configuracion.direccion == '') {
      this.showModalConfiguarciones = true;
      setTimeout(() => {
        this.txtDireccion.validator.adapter.focus();
      }, 10);
      return false;
    }

    return true;
  }



}
