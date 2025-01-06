import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ItensRodada } from './itens_rodada';
import { Observable } from 'rxjs/internal/Observable';



const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/js'
  })
};




@Injectable({
  providedIn: 'root'
})
export class ItensRodadaService {


  public url = 'https://localhost:7291/api/itensrodada';

  constructor(private http: HttpClient) {

  }

  PegarPeloId(idItemRodada: number): Observable<ItensRodada> {
    const apiUrl = `${this.url}/${idItemRodada}`;
    return this.http.get<ItensRodada>(this.url);
  }


  Salvar(itensRodada: ItensRodada): Observable<any> {
    return this.http.post<ItensRodada>(this.url, itensRodada, httpOptions);
  }

  Atualizar(itensRodada: ItensRodada): Observable<any> {
    return this.http.put<ItensRodada>(this.url, itensRodada, httpOptions);
  }


}
