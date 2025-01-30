Teste Prático

1. Tecnologias Utilizadas

- Front-end: React, Bootstrap
- Back-end: C# (.NET 8), Entity Framework Core
- Banco de Dados: SQL Server
- Outras Ferramentas: Axios, React Router, Postman (para testes de API)

2. Passos para Rodar o Projeto

Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- Node.js (para o front-end)
- Visual Studio 2022 com o .NET 8 SDK (para o back-end)
- SQL Server (para o banco de dados)

Configuração do Back-end

1. Clone o repositório:
   git clone https://github.com/seu-repositorio.git
   cd backend
   
2. Configure a string de conexão do banco de dados no arquivo appsettings.json.

  "ConnectionStrings": {
    "House": "Server=LEONAM\\MSSQLSERVER01;Database=teste_pratico;Trusted_Connection=True;TrustServerCertificate=True;"
  },


3. Instale as dependências:
   dotnet restore

4. Execute as migrações para criar as tabelas no banco de dados, para isso precisa acessar Teste_Pratico_API:
   cd .\Teste_Pratico_API\
   dotnet ef database update

5. Inicie o servidor:
   dotnet run
   O back-end estará disponível em https://localhost:7233.

Configuração do Front-end

1. Acesse a pasta do front-end:
   cd frontend

2. Instale as dependências:
   npm install

3. Inicie o servidor de desenvolvimento:
   npm start
   O front-end estará disponível em http://localhost:3000.

3. Endpoints da API

A API permite gerenciar produtos e anúncios. Abaixo estão os principais endpoints:

Produtos

Método HTTP  |  Endpoint             | Descrição                    | Corpo da Requisição
-------------|-----------------------|------------------------------|---------------------
GET          | /api/v1/produto       | Lista todos os produtos      | -
POST         | /api/v1/produto       | Cria um novo produto         | Veja exemplo abaixo
PUT          | /api/v1/produto/{id}  | Atualiza um produto existente| Veja exemplo abaixo
DELETE       | /api/v1/produto/{id}  | Remove um produto pelo ID    | -

Exemplo de Requisição POST /api/v1/produto:

{
  "Nome": "Smart TV UltraView 4K 55",
  "Valor": 2999.99,
  "Categoria": "Eletrônicos",
  "Modelo": "Smart TV UltraView 4K 55",
  "Condicao": "Novo",
  "Quantidade": 10
}

Anúncios

Método HTTP  |  Endpoint             | Descrição                    | Corpo da Requisição
-------------|-----------------------|------------------------------|---------------------
GET          | /api/v1/anuncio       | Lista todos os anúncios      | -
POST         | /api/v1/anuncio       | Cria um novo anúncio         | Veja exemplo abaixo
PUT          | /api/v1/anuncio/{id}  | Atualiza um anúncio existente| Veja exemplo abaixo
DELETE       | /api/v1/anuncio/{id}  | Remove um anúncio pelo ID    | -

Exemplo de Requisição POST /api/v1/anuncio:

{
  "Nome": "Smart TV UltraView 4K 55",
  "DataPublicacao": "2023-10-01",
  "Valor": 2999.99,
  "Cidade": "São Paulo"
}

Dicas para Testar a API

- Use o Postman para testar os endpoints manualmente.
- Certifique-se de que o back-end está rodando antes de testar o front-end.
- Se encontrar erros, verifique:
  - A string de conexão do banco de dados.
  - Se todas as dependências foram instaladas corretamente.

