import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CrudBaseComponent } from 'app/components/crud-base/crud-base.component';
import { ServidoresComponent } from 'app/components/servidores/servidores.component';
import { ServidoresFrmComponent } from 'app/components/servidores/servidores-frm/servidores-frm.component';
import { ServidorFichaComponent } from 'app/components/servidores/servidor-ficha/servidor-ficha.component';
import { LoginComponent } from 'app/components/login/login.component';

export const AppRoutes: Routes = [
    {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
    },
    {
        path: 'dashboard',
        component: DashboardComponent
    },
    {
        path: 'maestros/sistemas-operativos',
        component: CrudBaseComponent,
    },
    {
        path: 'maestros/ambientes',
        component: CrudBaseComponent,
    },
    {
        path: 'maestros/motores-bdd',
        component: CrudBaseComponent,
    },
    {
        path: 'servidores',
        component: ServidoresComponent,
    },
    {
        path: 'servidores/add',
        component: ServidoresFrmComponent,
    }
    ,
    {
        path: 'servidores/ficha/:id',
        component: ServidorFichaComponent,
    },
    
    {
        path: 'login',
        component: LoginComponent,
    }
]


