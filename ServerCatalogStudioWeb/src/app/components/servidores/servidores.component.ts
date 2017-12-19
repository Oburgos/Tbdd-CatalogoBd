import { Component, OnInit, ViewChild } from '@angular/core';
import { ServidoresService } from 'app/components/servidores/servidores.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-servidores',
  templateUrl: './servidores.component.html',
  styleUrls: ['./servidores.component.css']
})
export class ServidoresComponent implements OnInit {
  public dataSource = [];

  constructor(private servidoresService: ServidoresService, private route: Router) { }

  ngOnInit() {
    this.servidoresService.obtenerServidores().subscribe(data => {
      this.dataSource = data;
    });
  }

  
  abrirCrearServidor(): void {
    this.route.navigate(['/servidores/add']);
  }

}
