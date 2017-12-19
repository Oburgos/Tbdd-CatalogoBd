import { Component } from '@angular/core';

declare var $: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  constructor() {
    localStorage.setItem("Auth", JSON.stringify({
      token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwiZW1haWwiOiJvbWFyYnVyZ29zYkBnbWFpbC5jb20iLCJqdGkiOiJmMDVmNDE4ZC04YmM2LTQ5ZWYtYTg1MS02NWNkMjE4MzJjZmYiLCJuYmYiOjE1MTM2MzU3MjIsImV4cCI6MTUxODgxOTcyMiwiaXNzIjoiRml2ZXIuU2VjdXJpdHkuQmVhcmVyIiwiYXVkIjoiRml2ZXIuU2VjdXJpdHkuQmVhcmVyIn0.LcDMsSd7koFJT5bIhdCRE5tPGBxoLUdhGWtP__2vVhM"
    }));
  }
}
