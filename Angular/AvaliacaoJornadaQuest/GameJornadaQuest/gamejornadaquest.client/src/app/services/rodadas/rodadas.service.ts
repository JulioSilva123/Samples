import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Rodada } from './rodadas';



const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/js'
  })
};



@Injectable({
  providedIn: 'root'
})


export class RodadasService {

  public url = 'https://localhost:7291/api/rodadas';

  constructor(private http: HttpClient) {

  }


  PegarTodos(): Observable<Rodada[]> {
    return this.http.get<Rodada[]>(this.url);
  }

  PegarPeloId(idRodada: number): Observable<Rodada> {
    const apiUrl = `${this.url}/${idRodada}`;
    return this.http.get<Rodada>(this.url);
  }


  Salvar(rodada: Rodada): Observable<any> {
    return this.http.post<Rodada>(this.url, rodada, httpOptions);
  }

  Atualizar(rodada: Rodada): Observable<any> {
    return this.http.put<Rodada>(this.url, rodada, httpOptions);
  }


}
