import { Component, OnInit } from '@angular/core';
import { Foto } from './foto';
import { Observable, empty } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';

@Component({
  selector: 'app-foto-do-dia',
  templateUrl: './foto-do-dia.component.html',
  styleUrls: ['./foto-do-dia.component.css']
})
export class FotoDoDiaComponent implements OnInit {

  private readonly API = 'http://localhost:62425/api/nasaapi';
  foto: Foto[];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getFotoDoDia();
  }

  getFotoDoDia() {
    return this.http.get<Foto[]>(this.API)
    .subscribe(
      dados => { this.foto = dados; },
      error => { console.log(error); }
    );
  }

}
