# 🏋️‍♂️ API Academia Aulas

API desenvolvida em **.NET 8** para gerenciamento de **alunos, aulas e agendamentos** em uma academia.  
Permite o cadastro de alunos e aulas, agendamento de participação, além de relatórios mensais e gerais.

---

## 🚀 Tecnologias Utilizadas
- **C# 12**
- **ASP.NET Core Minimal API**
- **Entity Framework Core (SQLite)**
- **Swagger (OpenAPI)** para documentação

---

## 📌 Funcionalidades

### 👤 Cadastro de Alunos
- **POST /alunos**  
  Cadastra um novo aluno informando **nome** e **tipo de plano**.

Exemplo de requisição:
```json
{
  "nome": "João Silva",
  "planoTipo": 1
}
```

---

### 📚 Cadastro de Aulas
- **POST /aulas**  
  Cadastra uma nova aula informando **tipo**, **data/hora** e **capacidade máxima**.

Exemplo de requisição:
```json
{
  "tipo": "Musculação",
  "dataHora": "2025-09-10T19:00:00",
  "capacidadeMaxima": 20
}
```

---

### 📝 Agendamento de Aula
- **POST /aulas/{aulaId}/agendar/{alunoId}**  
  Agenda um aluno em uma aula específica.

---

### 📊 Relatórios

- **Relatório Mensal do Aluno**  
  `GET /alunos/{id}/relatorio?ano={ano}&mes={mes}`  
  ➝ Retorna o total de aulas no mês e os tipos mais frequentes.

- **Relatório Geral dos Alunos**  
  `GET /alunos/relatoriogeral`  
  ➝ Resumo de agendamentos de todos os alunos no mês atual.

- **Relatório de Aulas**  
  `GET /aulas/relatorio`  
  ➝ Lista todas as aulas cadastradas.

---

## 🛠️ Como Executar

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQLite](https://www.sqlite.org/)

### Passos
1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/api-academia-aulas.git
   cd api-academia-aulas
   ```

2. Aplique as migrações e crie o banco de dados:
   ```bash
   dotnet ef database update
   ```

3. Inicie a aplicação:
   ```bash
   dotnet run
   ```

4. Acesse o Swagger:
   ```
   https://localhost:5001/swagger
   ```

---

## 📂 Estrutura do Projeto
```
/src
  ├── Application    # DTOs e regras de aplicação
  ├── Domain         # Entidades e enums
  ├── Infrastructure # Contexto EF Core e migrações
  └── Program.cs     # Endpoints (Minimal API)
```

---

## 🔮 Melhorias Futuras
- Implementar **autenticação e autorização** (JWT).
- Adicionar **validações mais robustas** (ex.: evitar agendamento duplicado).
- Criar **cancelamento e remarcação de aulas**.
- Exportar relatórios em **PDF/Excel**.
- Implementar **notificações por e-mail** para lembrete de aulas.
- Criar **testes automatizados** (xUnit, NUnit ou MSTest).
- Adicionar suporte a **bancos de dados mais robustos** (SQL Server, PostgreSQL).
- Deploy em **Docker** para facilitar execução.

---

## 📜 Licença
Este projeto está sob a licença MIT.  
Sinta-se livre para usar, modificar e distribuir.
