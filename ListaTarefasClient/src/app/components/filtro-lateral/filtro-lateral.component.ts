import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SelectButtonModule } from 'primeng/selectbutton';
import { MultiSelectModule } from 'primeng/multiselect';

@Component({
  selector: 'app-filtro-lateral',
  standalone: true,
  imports: [
    FormsModule,
    SelectButtonModule,
    MultiSelectModule
  ],
  templateUrl: './filtro-lateral.component.html',
  styleUrl: './filtro-lateral.component.scss'
})
export class FiltroLateralComponent {

  opcaoVisualizacaoSelecionada!: number;
  opcoesVisualizacao: any[] = [
      { name: 'Hoje', value: 1 },
      { name: 'Esta Semana', value: 2 },
  ];

  statusSelecionado!: string;
  status = [
      {name: 'New York', code: 'NY'},
      {name: 'Rome', code: 'RM'},
      {name: 'London', code: 'LDN'},
      {name: 'Istanbul', code: 'IST'},
      {name: 'Paris', code: 'PRS'}
  ];
}
