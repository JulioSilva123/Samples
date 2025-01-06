import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Pessoa } from '../../services/pessoas/pessoa';
import { PessoasService } from '../../services/pessoas/pessoas.service';
import { PessoasRequest } from '../../models/AddPessoasRequest';

@Component({
  selector: 'app-pessoas',
  standalone: false,
  
  templateUrl: './pessoas.component.html',
  styleUrl: './pessoas.component.css'
})
export class PessoasComponent implements OnInit {

  model: PessoasRequest;
  pessoas: Pessoa[] = [];
  formulario: any;
  tituloFormulario: string;

  visibilidadeTabela: boolean = true;
  visibilidadeFormulario: boolean = false;


  constructor(private pessoasService: PessoasService) {
    this.tituloFormulario = "Lista de Pessoas";


    this.model = {
      idPessoa: 0,
      nmPessoa: ''
    };

    //this.pessoas = Pessoa[];
  }

  ngOnInit(): void {
    //throw new Error('Method not implemented.');

    

    this.pessoasService.PegarTodos().subscribe((resultado) => {

      //resultado.forEach(item => {

      //  var p = new Pessoa();

      //  p.idPessoa = item.idPessoa;
      //  p.nmPessoa = item.nmPessoa;

      //  this.pessoas.push(p);
      //})


      //items.forEach(item => {
      //  console.log(item);
      //});

      this.pessoas = resultado as Pessoa[];
    });



    //this.formulario = new FormGroup({

    //  IdPessoa: new FormControl(0),
    //  NmPessoa: new FormControl(null)

    //});

  }



  ExibirFormularioCadastro(): void {

    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;

    this.tituloFormulario = 'Novo Jogador';

    this.formulario = new FormGroup({
      idPessoa: new FormControl(null),
      nmPessoa: new FormControl(null),
    });


  }

  EnviarFormulario(): void {

    const pessoa: Pessoa = this.formulario.value;

    if (pessoa.idPessoa > 0) {


      this.pessoasService.Atualizar(pessoa).subscribe((resultado) => {

        this.visibilidadeFormulario = false;
        this.visibilidadeTabela = true;

        alert('Jogador  atualizado com sucesso');

        this.pessoasService.PegarTodos().subscribe((registros) => {
          this.pessoas = registros;
        });

      });


    } else {

      this.pessoasService.PegarTodos().subscribe((resultado) => {
        this.pessoas = resultado as Pessoa[];
      });


      var total = this.pessoas.length;

      pessoa.idPessoa = total + 1;

      this.pessoasService.Salvar(pessoa).subscribe((resultado) => {

        this.visibilidadeFormulario = false;
        this.visibilidadeTabela = true;

        alert('Jogador inserido com sucesso');

        this.pessoasService.PegarTodos().subscribe((registros) => {
          this.pessoas = registros;
        });

      });


    }
  }


 
  Voltar(): void {
    this.visibilidadeTabela = true;
    this.visibilidadeFormulario = false;
  }




  
}
