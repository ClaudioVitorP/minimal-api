🚗 Minimal API de Veículos
Uma API REST moderna desenvolvida em ASP.NET Core 9 seguindo os princípios de Clean Architecture e utilizando Minimal APIs para gerenciamento de veículos e administradores.

🛠️ Tecnologias Utilizadas
Backend

ASP.NET Core 9.0 - Framework principal
Minimal APIs - Abordagem moderna para criação de APIs REST
C# - Linguagem de programação
.NET 9 - Runtime e SDK

Banco de Dados

Entity Framework Core 9.0.8 - ORM
SQL Server - Banco de dados relacional
Entity Framework Migrations - Controle de versão do schema

Autenticação e Segurança

JWT (JSON Web Tokens) - Autenticação stateless
Microsoft.AspNetCore.Authentication.JwtBearer - Middleware de autenticação
Claims-based Authorization - Sistema de autorização baseado em roles

Documentação

Swagger/OpenAPI - Documentação interativa da API
Swashbuckle.AspNetCore 9.0.4 - Geração automática de documentação

Arquitetura e Padrões

Clean Architecture - Separação clara de responsabilidades
Domain-Driven Design (DDD) - Organização por domínio
Repository Pattern - Implementado através dos serviços
Dependency Injection - Injeção de dependência nativa do .NET
DTOs (Data Transfer Objects) - Transferência segura de dados
Model Views - Apresentação estruturada dos dados
Login baseado em JWT com roles (Administrador/Editor)
Tokens com expiração configurável
Autorização granular por endpoints

👤 Gestão de Administradores

Cadastro e autenticação de administradores
Dois níveis de acesso: Adm e Editor
Paginação automática para listagem

🚙 Gestão de Veículos

CRUD completo de veículos
Filtros por nome e marca
Validação de dados robusta
Paginação otimizada

📊 Recursos Avançados

Validação automática de DTOs
Tratamento padronizado de erros
Documentação interativa via Swagger
Seed automático de dados iniciais

🚀 Como Executar
Pré-requisitos

.NET 9 SDK
SQL Server (LocalDB ou instância completa)
Visual Studio Code ou Visual Studio 2022

1. Clone o repositório
bashgit clone (https://github.com/ClaudioVitorP/minimal-api.git)
cd minimal-api
2. Configure a conexão com o banco
Edite o arquivo appsettings.json:
json{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=MinimalApiDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
3. Execute as migrações
dotnet ef database update
4. Execute a aplicação
dotnet run
5. Acesse a documentação

API: http://localhost:5103 (HTTP) ou https://localhost:7125 (HTTPS)
Swagger: http://localhost:5103/swagger ou https://localhost:7125/swagger

🔑 Endpoints da API
🏠 Home
httpGET / - Informações gerais da API
👨‍💼 Administradores
httpPOST /administradores/login     # Autenticação
GET  /administradores           # Listar (Adm apenas)
GET  /administradores/{id}      # Buscar por ID (Adm apenas)
POST /administradores           # Criar (Adm apenas)
🚗 Veículos
httpPOST   /veiculos               # Criar (Adm/Editor)
GET    /veiculos               # Listar (Autenticado)
GET    /veiculos/{id}          # Buscar por ID (Adm/Editor)
PUT    /veiculos/{id}          # Atualizar (Adm apenas)
DELETE /veiculos/{id}          # Excluir (Adm apenas)
🔐 Autenticação
Login padrão
json{
  "email": "administrador@teste.com",
  "senha": "123456"
}
Uso do token
Adicione o header em todas as requisições autenticadas:
httpAuthorization: Bearer {seu-token-jwt}
🏗️ Arquitetura
O projeto segue os princípios da Clean Architecture:

Domínio: Regras de negócio e entidades
Infraestrutura: Acesso a dados e serviços externos
API: Controllers e configuração da aplicação

📝 Validações Implementadas
Administradores

Email obrigatório e único
Senha obrigatória (mínimo configurável)
Perfil obrigatório (Adm/Editor)

Veículos

Nome obrigatório
Marca obrigatória
Ano mínimo: 1950

🔧 Configurações
JWT
json{
  "Jwt": "sua-chave-secreta-aqui"
}

Banco de Dados
A aplicação suporta SQL Server com connection string configurável.

📈 Próximos Passos

 Implementar logs estruturados
 Adicionar testes unitários
 Implementar cache Redis
 Adicionar rate limiting
 Implementar soft delete
 Adicionar versionamento da API

📄 Licença
Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

⭐ Desenvolvido com ASP.NET Core 9 e Minimal APIs