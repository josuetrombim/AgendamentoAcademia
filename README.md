# API Academia Aulas

API desenvolvida em .NET 8 para gerenciamento de alunos, aulas e agendamentos em uma academia. Permite o cadastro de alunos e aulas, agendamento de participa��o, al�m de relat�rios mensais e gerais.

## Tecnologias Utilizadas

- C# 12
- ASP.NET Core Minimal API
- Entity Framework Core (SQLite)
- Swagger para documenta��o

## Funcionalidades

- **Cadastro de Alunos:**  
  `POST /alunos`  
  Cadastra um novo aluno informando nome e tipo de plano.

- **Cadastro de Aulas:**  
  `POST /aulas`  
  Cadastra uma nova aula informando tipo, data/hora e capacidade m�xima.

- **Agendamento de Aula:**  
  `POST /aulas/{aulaId}/agendar/{alunoId}`  
  Agenda um aluno em uma aula espec�fica.

- **Relat�rio Mensal do Aluno:**  
  `GET /alunos/{id}/relatorio?ano={ano}&mes={mes}`  
  Retorna o total de aulas agendadas no m�s e os tipos de aula mais frequentes para o aluno.

- **Relat�rio Geral dos Alunos:**  
  `GET /alunos/relatoriogeral`  
  Retorna o resumo de agendamentos de todos os alunos no m�s atual.

- **Relat�rio de Aulas:**  
  `GET /aulas/relatorio`  
  Lista todas as aulas cadastradas.

## Como Executar

1. **Pr�-requisitos:**  
   - .NET 8 SDK  
   - SQLite

2. **Configura��o:**  
   O banco de dados � criado automaticamente como `academia.db` na raiz do projeto.

3. **Execu��o:**  
   - Aplique as migra��es para criar/atualizar o banco de dados: ```
 dotnet ef database update
 ```   - Inicie a aplica��o: ```
 dotnet run
 ```