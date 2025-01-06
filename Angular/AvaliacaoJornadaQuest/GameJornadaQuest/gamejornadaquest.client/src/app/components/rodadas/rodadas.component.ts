import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@microsoft/signalr';
import { ActivatedRoute } from '@angular/router';
import { RodadasService } from '../../services/rodadas/rodadas.service';
import { Rodada } from '../../services/rodadas/rodadas';
import { ConnectionHubService } from '../../services/connection-hub.service';
import { Pessoa } from '../../services/pessoas/pessoa';



@Component({
  selector: 'app-rodadas',
  standalone: false,
  
  templateUrl: './rodadas.component.html',
  styleUrl: './rodadas.component.css'
})



export class RodadasComponent implements OnInit  {


  hubCon!: HubConnection;
  rodadas: Rodada[] = [];
  //options: FormGroup;



  constructor(private rodadasService: RodadasService,
              private activatedRoute: ActivatedRoute,
              private hubConService: ConnectionHubService) {  
  }


  ngOnInit(): void {

    this.rodadasService.PegarTodos().subscribe((resultado) => {
      this.rodadas = resultado as Rodada[];
    });


    const id:number = this.activatedRoute.snapshot.params['idRodada'];

    this.rodada = this.rodadas[id]; 

    
    //this.groupName = 'Chatroom ' + this.roomId;


    this.hubConService.hubConnection
      .invoke('JoinToRodada', this.pessoa.idPessoa, this.rodada.idRodada)
      .catch(err => console.log('JoinToRodada :', err));

    this.hubConService.hubConnection.on('JoinedRodada', async (pessoa: Pessoa, rodada: Rodada) => {
      const text = pessoa.nmPessoa + ' Entrou na Rodada ' + rodada.idRodada;

      //console.log(text);

      this.messages.push(text);
    });

    this.hubConService.hubConnection.on('pong', async (receivedMessage) => {
      const text = receivedMessage;
      this.messages.push(text);
    });


    this.hubConService.hubConnection.on('mensagemRodada', async (pessoa: Pessoa, receivedMessage) => {
      const text = pessoa.nmPessoa + ': ' + receivedMessage;
      this.messages.push(text);
    });

    this.hubConService.hubConnection.on('saiuDaRodada', async (pessoa: Pessoa , rodada: Rodada) => {
      const text = pessoa.nmPessoa + ' saiu da Rodada ' + rodada.idRodada;
      console.log(text);
      this.messages.push(text);
    });











  }



  public pessoa: Pessoa = new Pessoa();
  public rodada: Rodada = new Rodada();
  
  message = '';
  messages: string[] = [];

  Ping() {

    this.hubConService.hubConnection
      .invoke('Ping')
      .catch(err => console.log('Ping :', err));

  }


  sendClick() {

    this.hubConService.hubConnection
      .invoke('SendClick', this.pessoa, this.rodada)
      .catch(err => console.log('SendClick :', err));

  }
  
  sendMessage() {
    this.hubConService.hubConnection
      .invoke('SendMensagemRodada', this.pessoa, this.rodada, this.message)
      .catch(err => console.log('SendMensagemRodada :', err));

  }

  sairDaRodada() {
    this.hubConService.hubConnection
      .invoke('SairDaRodada', this.pessoa, this.rodada)
      .catch(err => console.log('sairDaRodada :', err));
  }

}
