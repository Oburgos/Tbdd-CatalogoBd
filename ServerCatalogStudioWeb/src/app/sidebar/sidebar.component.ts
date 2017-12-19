import { Component, OnInit } from '@angular/core';

declare var $:any;

export interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
};

export const ROUTES: RouteInfo[] = [
    { path: 'servidores', title: 'Servidores',  icon: 'fa fa-server', class: '' },
    { path: 'maestros/sistemas-operativos', title: 'Sistemas Operativos',  icon: 'ti-panel', class: '' },
    { path: 'maestros/motores-bdd', title: 'Motores Bd',  icon: 'ti-server', class: '' },
    { path: 'maestros/ambientes', title: 'Ambientes',  icon: 'fa fa-cubes', class: '' },
];

@Component({
    moduleId: module.id,
    selector: 'sidebar-cmp',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    ngOnInit() {
        this.menuItems = ROUTES.filter(menuItem => menuItem);
    }
    isNotMobileMenu(){
        if($(window).width() > 991){
            return false;
        }
        return true;
    }
}
