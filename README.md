# 🚚 Direction Logística - Gestão de Clientes

Este projeto faz parte de um desafio técnico para o desenvolvimento de um sistema Full Stack de gestão logística, composto por uma **API em .NET** e um **Front-end em Angular**.

## 🛠️ Tecnologias Utilizadas

* **Front-end:** Angular 19.
* **Back-end:** .NET 8 Web API.
* **Documentação:** Swagger/OpenAPI.
* **Controle de Versão:** Git.

## 🚀 Estrutura do Projeto

O repositório está dividido em duas pastas principais:
1.  **ApiLogistica:** Contém toda a lógica de servidor, controllers e integração com banco de dados.
2.  **FrontLogistica:** Contém a interface do usuário desenvolvida em Angular.

## ⚙️ Como Executar

### 1. Back-end (API)
* Navegue até a pasta `ApiLogistica` e abra o arquivo `.sln` no Visual Studio.
* Execute o projeto (F5). A API estará disponível em: `http://localhost:5084/swagger`.

### 2. Front-end (Angular)
* Navegue até a pasta `FrontLogistica`.
* Certifique-se de ter o Node.js instalado e execute `npm install`.
* Inicie o servidor com `ng serve`.
* Acesse: `http://localhost:4200`.

## 📝 Observações Importantes

> **Nota sobre Integração:** Para fins de demonstração imediata e devido a configurações de ambiente local (CORS), o Front-end foi configurado com dados simulados (Mock). No entanto, toda a lógica de consumo via `HttpClient` para a porta **5084** está implementada no código para análise técnica.

---
Desenvolvido por **Vithor de Castro Souza**.
