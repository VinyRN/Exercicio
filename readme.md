# Projeto Questao5 - API de Conta Corrente

## Descrição
Este projeto consiste em uma API para gerenciar movimentações de contas correntes e consultar o saldo atual de uma conta. A API foi desenvolvida em .NET Core e utiliza SQLite como banco de dados. A aplicação inclui validações de negócio, suporte a idempotência e é resiliente a falhas para garantir segurança e confiabilidade.

## Funcionalidades
- **Consulta de Saldo da Conta Corrente**
  - Recebe a identificação da conta e retorna o saldo atual.
  - Realiza validações para garantir que apenas contas válidas e ativas possam consultar o saldo.
- **Movimentação de Conta Corrente**
  - Permite crédito e débito em contas cadastradas.
  - Implementa idempotência para evitar duplicações em caso de falha na comunicação.
  - Validações de segurança para garantir que apenas valores positivos sejam aceitos e que apenas contas ativas possam ser movimentadas.

## Estrutura do Projeto

Questao5 │ ├── Controllers │ └── ContaController.cs # Controlador para as rotas de API │ ├── Domain │ ├── Entities │ │ └── SaldoResponse.cs # Entidade para a resposta da consulta de saldo │ └── DTOs │ └── MovimentacaoRequest.cs # DTO para a requisição de movimentação de conta │ ├── Infrastructure │ ├── Repositories │ │ └── ContaCorrenteRepository.cs # Repositório para conexão com o banco SQLite │ └── Sqlite │ └── DatabaseBootstrap.cs # Script para inicialização do banco SQLite │ ├── Program.cs # Configuração da aplicação │ └── appsettings.json # Configurações de conexão e ambiente


## Tecnologias Utilizadas
- **.NET Core 6.0**
- **SQLite**
- **Dapper** para consultas ao banco de dados.
- **Swagger** para documentação da API.
- **CQRS e Mediator** (pontos extras para segregação de responsabilidade).
- **NSubstitute** para testes unitários (sugerido).

## Como Executar o Projeto
1. **Clone o repositório**:
   git clone https://github.com/seu-usuario/seu-projeto.git
   cd seu-projeto/Questao5
   
2. Restaurar pacotes:
	dotnet restore

3. Executar o projeto:
	dotnet run

4. Acesse a documentação Swagger: Abra o navegador e acesse http://localhost:<porta>/swagger para visualizar e interagir com os endpoints.

## EndPoints

Consulta de Saldo
	GET /api/conta/saldo/{idConta}
		Descrição: Retorna o saldo atual da conta corrente.
		Retorno: Número da conta, nome do titular, data/hora da consulta, e saldo atual.
		Erros Possíveis:
			400 Bad Request com mensagens INVALID_ACCOUNT, INACTIVE_ACCOUNT.
Movimentação de Conta Corrente
	POST /api/conta/movimentacao
	Descrição: Permite realizar crédito ou débito em uma conta corrente.
	Parâmetros: IdRequisicao, IdContaCorrente, Valor, TipoMovimento (C para crédito, D para débito).
	Retorno: ID do movimento criado.
	Erros Possíveis:
		400 Bad Request com mensagens INVALID_ACCOUNT, INACTIVE_ACCOUNT, INVALID_VALUE, INVALID_TYPE.
		
		
##Testes Unitários
	Framework: Recomenda-se usar xUnit e NSubstitute para criar testes unitários e simular o comportamento do banco de dados e das dependências.
		
##Considerações Finais
Este projeto foi desenvolvido com foco em seguir boas práticas de desenvolvimento, incluindo validações de negócio, implementação de idempotência e segurança em operações de conta corrente.

