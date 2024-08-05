import { Component, computed, signal } from '@angular/core';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { TarefasService } from '../../services/tarefas.service';

@Component({
  selector: 'app-tabela',
  standalone: true,
  imports: [
    TableModule,
    TagModule
  ],
  templateUrl: './tabela.component.html',
  styleUrl: './tabela.component.scss'
})
export class TabelaComponent {
  constructor(private tarefasService: TarefasService) { }
  
  ngOnInit() {
  }

  tarefas = computed(() => {
    let tarefasFiltradas = this.tarefasService.tarefas();
    const visualizacaoFiltrada = this.tarefasService.visualizacaoFiltrada();
    const statusFiltrados = this.tarefasService.statusFiltrados();

    if(visualizacaoFiltrada) {
      tarefasFiltradas =  this.tarefasService.estatisticas[visualizacaoFiltrada].lista;
    }
    if(statusFiltrados.length > 0) {
      tarefasFiltradas =  tarefasFiltradas.filter(tarefa => statusFiltrados.includes(tarefa.status));
    }

    return tarefasFiltradas;
  });

  onItemAdded(x: string) {
    //this.tarefasService.add(x);
  }
  
  obterCorStatus(status: any) {
    switch (status) {
        case 'Concluida':
            return 'success';

        case 'Em andamento':
            return 'warning';

        case 'Não iniciada':
            return 'secondary';

        default:
            return null;
    }
  };
}
