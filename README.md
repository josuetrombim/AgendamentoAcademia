# API Academia Aulas

API desenvolvida em .NET 8 para gerenciamento de alunos, aulas e agendamentos em uma academia. Permite o cadastro de alunos e aulas, agendamento de participação, além de relatórios mensais e gerais.

## Tecnologias Utilizadas

- C# 12
- ASP.NET Core Minimal API
- Entity Framework Core (SQLite)
- Swagger para documentação

## Funcionalidades

- **Cadastro de Alunos:**  
  `POST /alunos`  
  Cadastra um novo aluno informando nome e tipo de plano.

- **Cadastro de Aulas:**  
  `POST /aulas`  
  Cadastra uma nova aula informando tipo, data/hora e capacidade máxima.

- **Agendamento de Aula:**  
  `POST /aulas/{aulaId}/agendar/{alunoId}`  
  Agenda um aluno em uma aula específica.

- **Relatório Mensal do Aluno:**  
  `GET /alunos/{id}/relatorio?ano={ano}&mes={mes}`  
  Retorna o total de aulas agendadas no mês e os tipos de aula mais frequentes para o aluno.

- **Relatório Geral dos Alunos:**  
  `GET /alunos/relatoriogeral`  
  Retorna o resumo de agendamentos de todos os alunos no mês atual.

- **Relatório de Aulas:**  
  `GET /aulas/relatorio`  
  Lista todas as aulas cadastradas.

## Como Executar

1. **Pré-requisitos:**  
   - .NET 8 SDK  
   - SQLite

2. **Configuração:**  
   O banco de dados é criado automaticamente como `academia.db` na raiz do projeto.

3. **Execução:**  
   - Aplique as migrações para criar/atualizar o banco de dados: ```
 dotnet ef database update
 ```   - Inicie a aplicação: ```
 dotnet run
 ```