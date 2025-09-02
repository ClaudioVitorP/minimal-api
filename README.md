projeto:
  nome: "Minimal API de Veículos"
  descricao: >
    Uma API REST moderna desenvolvida em ASP.NET Core 9 seguindo os princípios de Arquitetura Limpa
    e utilizando APIs Minimais para gerenciamento de veículos e administradores.
  selos:
    - "[![.NET](https://img.shields.io/badge/.NET-9.0-blue)](https://dotnet.microsoft.com/)"
    - "[![Licença: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)"
    - "[![Compilação](https://img.shields.io/badge/build-passing-brightgreen)]()"

tecnologias:
  backend:
    - "ASP.NET Core 9.0"
    - "APIs Minimais"
    - "C#"
    - ".NET 9 SDK"
  banco_de_dados:
    - "Entity Framework Core 9.0.8"
    - "SQL Server"
    - "Migrações do Entity Framework"
  autenticacao:
    - "JWT (JSON Web Tokens)"
    - "Microsoft.AspNetCore.Authentication.JwtBearer"
    - "Autorização baseada em permissões"
  documentacao:
    - "Swagger/OpenAPI"
    - "Swashbuckle.AspNetCore 9.0.4"
  arquitetura:
    - "Arquitetura Limpa"
    - "Design Orientado a Domínio (DDD)"
    - "Padrão Repositório"
    - "Injeção de Dependência"
    - "DTOs (Objetos de Transferência de Dados)"
    - "Modelos de Visualização"

funcionalidades:
  administradores:
    - "Cadastro e autenticação de administradores"
    - "Dois níveis de acesso: Adm e Editor"
    - "Paginação automática para listagem"
  veiculos:
    - "CRUD completo"
    - "Filtros por nome e marca"
    - "Validação de dados robusta"
    - "Paginação otimizada"
  avancados:
    - "Validação automática de DTOs"
    - "Tratamento padronizado de erros"
    - "Documentação interativa via Swagger"
    - "Carga inicial de dados automáticos"

instalacao:
  pre_requisitos:
    - ".NET 9 SDK"
    - "SQL Server (LocalDB ou instância completa)"
    - "Visual Studio Code ou Visual Studio 2022"
  passos:
    - passo: "Clonar o repositório"
      comando: |
        git clone https://github.com/ClaudioVitorP/minimal-api.git
        cd minimal-api
    - passo: "Configurar a conexão com o banco"
      arquivo: "appsettings.json"
      conteudo: |
        {
          "ConnectionStrings": {
            "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=MinimalApiDb;Trusted_Connection=True;TrustServerCertificate=True;"
          }
        }
    - passo: "Executar as migrações"
      comando: "dotnet ef database update"
    - passo: "Executar a aplicação"
      comando: "dotnet run"
    - passo: "Acessar a documentação"
      enderecos:
        - "http://localhost:5103/swagger"
        - "https://localhost:7125/swagger"

pontos_de_acesso:
  inicio:
    - metodo: GET
      rota: /
      descricao: "Informações gerais da API"
  administradores:
    - metodo: POST
      rota: /administradores/login
      acesso: "Público"
      descricao: "Autenticação e geração de token"
    - metodo: GET
      rota: /administradores
      acesso: "Adm"
      descricao: "Listar administradores"
    - metodo: GET
      rota: /administradores/{id}
      acesso: "Adm"
      descricao: "Buscar administrador por ID"
    - metodo: POST
      rota: /administradores
      acesso: "Adm"
      descricao: "Criar administrador"
  veiculos:
    - metodo: POST
      rota: /veiculos
      acesso: "Adm/Editor"
      descricao: "Criar veículo"
    - metodo: GET
      rota: /veiculos
      acesso: "Autenticado"
      descricao: "Listar veículos (com paginação/filtros)"
    - metodo: GET
      rota: /veiculos/{id}
      acesso: "Adm/Editor"
      descricao: "Buscar veículo por ID"
    - metodo: PUT
      rota: /veiculos/{id}
      acesso: "Adm"
      descricao: "Atualizar veículo"
    - metodo: DELETE
      rota: /veiculos/{id}
      acesso: "Adm"
      descricao: "Excluir veículo"

autenticacao:
  exemplo_login:
    requisicao: |
      {
        "email": "administrador@teste.com",
        "senha": "123456"
      }
  uso: |
    Autorizacao: Portador {seu-token-jwt}

exemplos:
  criar_veiculo:
    requisicao: |
      POST /veiculos
      Content-Type: application/json
      Autorizacao: Portador {seu-token}

      {
        "nome": "Civic",
        "marca": "Honda",
        "ano": 2022
      }
    resposta: |
      {
        "id": 1,
        "nome": "Civic",
        "marca": "Honda",
        "ano": 2022
      }

arquitetura:
  descricao: "O projeto segue Arquitetura Limpa"
  camadas:
    - "Domínio: Regras de negócio e entidades"
    - "Infraestrutura: Acesso a dados e serviços externos"
    - "API: Configuração da aplicação e pontos de acesso"

validacoes:
  administradores:
    - "Email obrigatório e único"
    - "Senha obrigatória (mínimo configurável)"
    - "Perfil obrigatório (Adm/Editor)"
  veiculos:
    - "Nome obrigatório"
    - "Marca obrigatória"
    - "Ano mínimo: 1950"

configuracoes:
  jwt:
    exemplo: |
      {
        "Jwt": "sua-chave-secreta-aqui"
      }
  banco_de_dados: "Suporta SQL Server com cadeia de conexão configurável"

roteiro:
  - "[ ] Implementar registros estruturados"
  - "[ ] Adicionar testes unitários"
  - "[ ] Implementar cache Redis"
  - "[ ] Implementar exclusão lógica (soft delete)"
  - "[ ] Adicionar versionamento da API"

licenca:
  tipo: "MIT"
  arquivo: "LICENSE"
