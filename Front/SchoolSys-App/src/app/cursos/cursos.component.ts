import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cursos',
  templateUrl: './cursos.component.html',
  styleUrls: ['./cursos.component.scss']
})
export class CursosComponent implements OnInit {

  public cursos: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getCursos();
  }

  public getCursos(): void {
    this.http.get('http://localhost:5000/api/cursos').subscribe(
      response => this.cursos = response,
      error => console.log(error)
    );
  }
}
