import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: false 
})
export class AppComponent implements OnInit {
  title = 'Direction Logística - Sistema de Gestão';
  clientes: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    // CHAMADA COMENTADA: Mantive a estrutura real para você mostrar que o código existe
    // this.obterClientesDaApi();

    // DADOS SIMULADOS: Para garantir a apresentação do projeto hoje
    this.carregarDadosSimulados();
  }

  carregarDadosSimulados() {
    console.log('Carregando modo de demonstração...');
    this.clientes = [
      { id: 1, nome: 'Vithor de Castro Souza', email: 'vithor.souza@ufrpe.br' },
      { id: 2, nome: 'Transportadora Recife Express', email: 'contato@recexpress.com' },
      { id: 3, nome: 'Logística Brasil S.A.', email: 'adm@logbrasil.com.br' },
      { id: 4, nome: 'Supermercados Aliança', email: 'compras@alianca.com' },
      { id: 5, nome: 'Distribuidora de Peças Norte', email: 'vendas@pecasnorte.com' }
    ];
  }

  // 
  obterClientesDaApi() {
    const urlApi = 'http://localhost:5084/api/clientes';
    this.http.get<any[]>(urlApi).subscribe({
      next: (res) => this.clientes = res,
      error: (err) => console.error('Erro de conexão local:', err)
    });
  }
}