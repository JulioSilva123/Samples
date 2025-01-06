/// <reference path="services/pessoas/pessoas.service.ts" />



import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { PessoasService } from "./services/pessoas/pessoas.service";

import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { ModalModule } from "ngx-bootstrap/modal";


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PessoasComponent } from './components/pessoas/pessoas.component';
import { ItensRodadaComponent } from './components/itens-rodada/itens-rodada.component';
import { ItensRodadaClicksComponent } from './components/itens-rodada-clicks/itens-rodada-clicks.component';
import { RodadasComponent } from './components/rodadas/rodadas.component';
import { StatusRodadaComponent } from './components/status-rodada/status-rodada.component';


//import { PessoasService } from 'pessoas/pessoas.service';






@NgModule({
  declarations: [
    AppComponent,
    PessoasComponent,
    ItensRodadaComponent,
    ItensRodadaClicksComponent,
    RodadasComponent,
    StatusRodadaComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    CommonModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  providers: [HttpClientModule, PessoasService],
  bootstrap: [AppComponent]
})
export class AppModule { }
