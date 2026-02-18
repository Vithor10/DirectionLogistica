import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


// Definição de cliente para exemplo
export interface Cliente {
    id?: number;
    nome: string;
    cpf: string;
    endereco?: string;
    telefone?: string;
    email?: string;
    status?: string;
}
// ---------------------------

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  // ATENÇÃO: Verifique se a porta da sua API é 5000. 
  // Se no terminal do C# estiver "localhost:5100", mude aqui!
  private apiUrl = 'http://localhost:5000/api/clientes';

  constructor(private http: HttpClient) { }

  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.apiUrl);
  }
}