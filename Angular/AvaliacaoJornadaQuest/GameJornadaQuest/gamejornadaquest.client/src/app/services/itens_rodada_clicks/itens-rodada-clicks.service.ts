import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ItensRodadaClicks } from './itens_rodada_clicks';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/js'
  })
};




@Injectable({
  providedIn: 'root'
})
export class ItensRodadaClicksService {


  public url = 'https://localhost:7291/api/itensrodadaclicks';

  constructor(private http: HttpClient) {

  }

  PegarPeloId(idItemRodadaClick: number): Observable<ItensRodadaClicks> {
    const apiUrl = `${this.url}/${idItemRodadaClick}`;
    return this.http.get<ItensRodadaClicks>(this.url);
  }


  Salvar(itensRodadaClicks: ItensRodadaClicks): Observable<any> {
    return this.http.post<ItensRodadaClicks>(this.url, itensRodadaClicks, httpOptions);
  }

  Atualizar(itensRodadaClicks: ItensRodadaClicks): Observable<any> {
    return this.http.put<ItensRodadaClicks>(this.url, itensRodadaClicks, httpOptions);
  }

}
