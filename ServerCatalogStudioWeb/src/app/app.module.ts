import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpModule } from "@angular/http";

import { AppComponent } from './app.component';
import { AppRoutes } from './app.routing';
import { SidebarModule } from './sidebar/sidebar.module';
import { FooterModule } from './shared/footer/footer.module';
import { NavbarModule } from './shared/navbar/navbar.module';
import { FixedPluginModule } from './shared/fixedplugin/fixedplugin.module';
import { NguiMapModule } from '@ngui/map';

import { DashboardComponent } from './dashboard/dashboard.component';
import { CrudBaseComponent } from './components/crud-base/crud-base.component';


import {
  DxTextBoxModule,
  DxCheckBoxModule,
  DxValidatorModule,
  DxSelectBoxModule,
  DxNumberBoxModule,
  DxPopupModule,
  DxTemplateModule,
  DxDataGridModule
} from 'devextreme-angular';
import { HttpAuthService } from 'app/helpers/http-auth.service';
import { CrudBaseService } from 'app/components/crud-base/crud-base.service';
import { DefaultUrlSerializer, UrlTree } from '@angular/router';
import { UrlSerializer } from '@angular/router';
import { CrudBaseFrmComponent } from './components/crud-base/crud-base-frm/crud-base-frm.component';
import { CrudBaseGridComponent } from './components/crud-base/crud-base-grid/crud-base-grid.component';
import { ServidoresComponent } from './components/servidores/servidores.component';
import { ServidoresService } from 'app/components/servidores/servidores.service';
import { ServidoresFrmComponent } from './components/servidores/servidores-frm/servidores-frm.component';
import { ServidorFichaComponent } from './components/servidores/servidor-ficha/servidor-ficha.component';
import { LoginComponent } from './components/login/login.component';



export class LowerCaseUrlSerializer extends DefaultUrlSerializer {
  parse(url: string): UrlTree {
    return super.parse(url.toLowerCase());
  }
}

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    CrudBaseComponent,
    CrudBaseFrmComponent,
    CrudBaseGridComponent,
    ServidoresComponent,
    ServidoresFrmComponent,
    ServidorFichaComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(AppRoutes),
    SidebarModule,
    NavbarModule,
    FooterModule,
    FixedPluginModule,
    DxTextBoxModule,
    DxCheckBoxModule,
    HttpModule,
    DxValidatorModule,
    DxSelectBoxModule,
    DxNumberBoxModule,
    DxPopupModule,
    DxTemplateModule,
    DxDataGridModule
  ],
  providers: [HttpAuthService, CrudBaseService, {
    provide: UrlSerializer,
    useClass: LowerCaseUrlSerializer
  }, ServidoresService],
  bootstrap: [AppComponent]
})
export class AppModule { }

