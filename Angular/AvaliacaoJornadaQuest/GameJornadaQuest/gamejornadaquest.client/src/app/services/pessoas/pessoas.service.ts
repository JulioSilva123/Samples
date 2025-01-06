import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pessoa } from './pessoa';
import { Observable } from 'rxjs/internal/Observable';
import { PessoasRequest } from '../../models/AddPessoasRequest';



const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/js'
  })
};


@Injectable({
  providedIn: 'root'
})


export class PessoasService {

  

  url = 'https://localhost:7291/api/pessoas';
  constructor(private http: HttpClient) {

  }
  
  PegarTodos(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(this.url);
  }


  PegarPeloId(idPessoa: number): Observable<Pessoa> {
    const apiUrl = `${this.url}/${idPessoa}`;
    return this.http.get<Pessoa>(apiUrl);
  }

  Salvar(pessoa: Pessoa): Observable<any> {

    const model = {
      idPessoa: pessoa.idPessoa,
      nmPessoa: pessoa.nmPessoa
    };


    return this.http.post<PessoasRequest>(this.url, model, httpOptions);
  }

  Atualizar(pessoa: Pessoa): Observable<any> {
    return this.http.put<Pessoa>(this.url, pessoa, httpOptions);
  }



}
