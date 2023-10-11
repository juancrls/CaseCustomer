# API CRUD com DDD em .NET 6.0

Este projeto é uma API CRUD desenvolvida em .NET 6.0 que segue o padrão de arquitetura DDD (Domain-Driven Design). O banco de dados utilizado é o PostgreSQL, e a documentação da API é feita através do Swagger.

## Estrutura do Projeto

O projeto está organizado em três camadas principais:

### 1. Camada Domain

A camada "Domain" contém as classes de domínio, que representam os objetos de negócio da aplicação. Aqui, você encontrará as entidades, agregados e objetos de valor que definem o modelo de domínio da aplicação.

### 2. Camada Infrastructure

A camada "Infrastructure" é responsável pela implementação da infraestrutura da aplicação. Ela contém:

- Configurações de banco de dados, migrações e contexto do Entity Framework Core.
- Repositórios que fornecem acesso aos dados do banco de dados.
- Implementações de serviços externos, como envio de e-mails ou integrações com sistemas externos.

### 3. Camada API

A camada "API" é a interface da aplicação com o mundo exterior. Aqui, estão definidos os controladores que expõem os endpoints da API. Os controladores interagem com os serviços da camada "Domain" e usam a camada "Infrastructure" para acessar o banco de dados.

## Documentação da API com Swagger

A documentação da API é gerada automaticamente com o uso do Swagger. Você pode acessar a documentação interativa da API navegando para `http://localhost:5093/swagger` após a execução do projeto.

## Configuração

Antes de executar a aplicação, certifique-se de configurar a conexão com o banco de dados PostgreSQL no arquivo `CustomerDataContext.cs`

Após configurar a conexão, execute as migrações para criar o banco de dados:

```dotnet ef database update```

## Executando a Aplicação

Para executar a aplicação, siga os passos abaixo:

##### 1. Certifique-se de ter o .NET 6.0 instalado em sua máquina.
##### 2. Navegue até a pasta raiz do projeto API e execute o comando `dotnet run`.
##### 3. A API com a documentação estará disponível em `http://localhost:5093/swagger`.

## Rotas da API

Aqui estão as principais rotas da API:

- `GET /Customer/List`: Recupera todos os itens da tabela Customer.
- `GET /Customer/Find/{id}`: Recupera um item específico da tabela Customer.
- `POST /Customer/Create`: Cria um novo item da tabela Customer.
- `PUT /Customer/Update`: Atualiza um item da tabela Customer.
- `DELETE /Customer/{id}`: Exclui um item da tabela Customer.
