<h1 align="center">🚗 Minimal API de Veículos</h1>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-9.0-blue" alt=".NET 9.0"/>
  <img src="https://img.shields.io/badge/License-MIT-yellow.svg" alt="Licença MIT"/>
  <img src="https://img.shields.io/badge/build-passing-brightgreen" alt="Build Status"/>
</p>

## :memo: Descrição

Uma API REST moderna desenvolvida em **ASP.NET Core 9** seguindo os princípios de **Arquitetura Limpa** e utilizando **APIs Minimais** para gerenciamento de veículos e administradores.

O projeto implementa um sistema completo de autenticação JWT com diferentes níveis de acesso (Administrador e Editor), permitindo operações CRUD em veículos com validação robusta, paginação otimizada e filtros avançados. A arquitetura segue padrões DDD com separação clara entre domínio, infraestrutura e apresentação.

## :wrench: Tecnologias utilizadas

### **Backend**
* ASP.NET Core 9.0
* APIs Minimais
* C# 13
* .NET 9 SDK

### **Banco de Dados**
* Entity Framework Core 9.0.8
* SQL Server
* Migrações do Entity Framework

### **Autenticação e Segurança**
* JWT (JSON Web Tokens)
* Microsoft.AspNetCore.Authentication.JwtBearer
* Autorização baseada em Claims

### **Documentação**
* Swagger/OpenAPI
* Swashbuckle.AspNetCore 9.0.4

### **Arquitetura e Padrões**
* Arquitetura Limpa
* Design Orientado a Domínio (DDD)
* Padrão Repositório
* Injeção de Dependência
* DTOs (Objetos de Transferência de Dados)
* Modelos de Visualização

## :rocket: Rodando o projeto

### **Pré-requisitos**
* .NET 9 SDK
* SQL Server (LocalDB ou instância completa)
* Visual Studio Code ou Visual Studio 2022

### **Instalação**

**1. Clone o repositório:**
```bash
git clone https://github.com/ClaudioVitorP/minimal-api.git
cd minimal-api
```

**2. Configure a conexão com o banco de dados:**

Edite o arquivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=MinimalApiDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**3. Execute as migrações:**
```bash
dotnet ef database update
```

**4. Execute a aplicação:**
```bash
dotnet run
```

**5. Acesse a documentação:**
* Swagger: `http://localhost:5103/swagger` ou `https://localhost:7125/swagger`

## :globe_with_meridians: Endpoints da API

### **🏠 Início**
| Método | Rota | Acesso | Descrição |
|--------|------|---------|-----------|
| `GET` | `/` | Público | Informações gerais da API |

### **👨‍💼 Administradores**
| Método | Rota | Acesso | Descrição |
|--------|------|---------|-----------|
| `POST` | `/administradores/login` | Público | Autenticação e geração de token |
| `GET` | `/administradores` | Adm | Listar administradores |
| `GET` | `/administradores/{id}` | Adm | Buscar administrador por ID |
| `POST` | `/administradores` | Adm | Criar administrador |

### **🚗 Veículos**
| Método | Rota | Acesso | Descrição |
|--------|------|---------|-----------|
| `POST` | `/veiculos` | Adm/Editor | Criar veículo |
| `GET` | `/veiculos` | Autenticado | Listar veículos (com paginação/filtros) |
| `GET` | `/veiculos/{id}` | Adm/Editor | Buscar veículo por ID |
| `PUT` | `/veiculos/{id}` | Adm | Atualizar veículo |
| `DELETE` | `/veiculos/{id}` | Adm | Excluir veículo |

## :lock: Autenticação

### **Credenciais padrão:**
```json
{
  "email": "administrador@teste.com",
  "senha": "123456"
}
```

### **Como obter e usar o token:**

1. **Faça login no Swagger:**
   - Acesse `/swagger`
   - Vá até `POST /administradores/login`
   - Use as credenciais padrão
   - Copie o `token` da resposta

2. **Autorize no Swagger:**
   - Clique no botão **"Authorize"** 🔒
   - Cole o token
   - Clique em "Authorize"

3. **Para outras ferramentas:**
   ```http
   Authorization: Bearer {seu-token-jwt}
   ```

## :computer: Exemplo de Uso

### **Criar Veículo:**
```http
POST /veiculos
Content-Type: application/json
Authorization: Bearer {seu-token}

{
  "nome": "Civic",
  "marca": "Honda",
  "ano": 2022
}
```

### **Resposta:**
```json
{
  "id": 1,
  "nome": "Civic",
  "marca": "Honda",
  "ano": 2022
}
```

## :building_construction: Arquitetura

O projeto segue os princípios da **Arquitetura Limpa**:

* **Domínio:** Regras de negócio e entidades
* **Infraestrutura:** Acesso a dados e serviços externos  
* **API:** Configuração da aplicação e pontos de acesso

## :white_check_mark: Validações

### **Administradores:**
* Email obrigatório e único
* Senha obrigatória
* Perfil obrigatório (Adm/Editor)

### **Veículos:**
* Nome obrigatório
* Marca obrigatória
* Ano mínimo: 1950

## :gear: Configurações

### **JWT:**
```json
{
  "Jwt": "sua-chave-secreta-aqui"
}
```

### **Banco de Dados:**
Suporta SQL Server com connection string configurável.

## :soon: Próximos Passos

- [ ] Implementar logs estruturados
- [ ] Adicionar testes unitários
- [ ] Implementar cache Redis
- [ ] Adicionar rate limiting
- [ ] Implementar soft delete
- [ ] Adicionar versionamento da API

## :handshake: Colaboradores

<table>
  <tr>
    <td align="center">
      <a href="https://github.com/ClaudioVitorP">
        <img src="https://img.freepik.com/vetores-premium/desenho-de-desenho-animado-de-um-programador_29937-8176.jpg" width="100px;" alt="Foto de Cláudio Vítor"/><br>
        <sub>
          <b>Cláudio Vítor</b>
        </sub>
      </a>
    </td>
  </tr>
</table>

## :dart: Status do projeto

Em andamento

## :page_with_curl: Licença

**Licença MIT** - Uma das licenças mais permissivas que permite:

✅ **Uso comercial** • **Modificação** • **Distribuição** • **Sublicenciamento**

---

<p align="center">⭐ **Desenvolvido com ASP.NET Core 9 e Minimal APIs** ⭐</p>