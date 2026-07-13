# 👤 Users API

## 📖 Visão Geral

A **Users API** é o microsserviço responsável pelo gerenciamento de usuários da plataforma de jogos.

Sua principal função é realizar o cadastro de usuários, autenticação e disponibilizar informações necessárias para os demais microsserviços da aplicação.

Após a criação de um novo usuário, a API publica um evento de domínio informando a criação do usuário, permitindo que outros serviços reajam de forma assíncrona.

A comunicação entre os microsserviços é realizada utilizando **RabbitMQ**, garantindo baixo acoplamento, escalabilidade e maior resiliência da arquitetura.

---

# 🚀 Responsabilidades

* Realizar cadastro de usuários.
* Realizar autenticação e geração de tokens JWT.
* Validar credenciais de acesso.
* Gerenciar informações dos usuários.
* Publicar eventos de criação de usuário.
* Manter a comunicação assíncrona com outros microsserviços.

---

# 🛠️ Tecnologias Utilizadas

* .NET 10
* ASP.NET Core
* Entity Framework Core
* JWT Authentication
* RabbitMQ
* Docker
* Kubernetes

---

# 🏗️ Arquitetura

O fluxo de criação de usuários ocorre conforme o diagrama abaixo:

```text
Users API
      │
      │ Publica UserCreatedEvent
      ▼
RabbitMQ (user-created)
      │
      ▼
Notifications API
      │
      │ Envia notificação ao usuário
```

---

# 🔄 Fluxo de Funcionamento

1. O usuário realiza o cadastro através da **Users API**.
2. A API valida os dados recebidos.
3. O usuário é persistido no banco de dados.
4. A **Users API** publica o evento `UserCreatedEvent`.
5. O evento é enviado para a fila `user-created` no RabbitMQ.
6. O **Notifications API** consome o evento e realiza o processamento da notificação.

---

# 📨 Filas Utilizadas

## Publica

| Fila | Evento |
|------|--------|
| `user-created` | `UserCreatedEvent` |

---

## Banco de Dados

A aplicação utiliza **SQLite** como banco de dados para persistência das informações dos usuários.

Durante a inicialização da aplicação, existe uma rotina de carga inicial responsável por criar usuários padrões no banco de dados, facilitando a execução do projeto e a realização de testes sem a necessidade de cadastrar usuários manualmente.
Esses usuários podem ser utilizados para validar os fluxos de autenticação e autorização da aplicação.

---

# ▶️ Executando Localmente

### Restaurar dependências

```bash
dotnet restore
```

### Executar a aplicação

```bash
dotnet run
```

---

# 🐳 Executando com Docker

A **Users API** pode ser executada de forma independente para fins de desenvolvimento e testes.

### Build da imagem

```bash
docker build -t users-api .
```

### Executar o container

```bash
docker run -p 5001:8080 users-api
```

> **Observação:** Ao executar apenas este microsserviço, o cadastro e autenticação de usuários estarão disponíveis normalmente. Porém, funcionalidades que dependem da comunicação com outros serviços, como notificações de criação de usuário, necessitam que o RabbitMQ e os demais microsserviços estejam em execução.

## 🚀 Executando a solução completa

Para simular o ambiente da aplicação de forma semelhante à produção, o recomendado é utilizar o repositório **Orchestrator**, responsável por orquestrar todos os microsserviços da plataforma.

O repositório do **Orchestrator** possui um **README** com todas as instruções necessárias para configurar e executar a solução completa. Após seguir as etapas descritas nesse repositório, basta executar:

```bash
docker compose up --build
```

Esse comando iniciará todos os componentes necessários da solução, incluindo:

- Users API
- Catalog API
- Payments API
- Notifications API
- RabbitMQ

Dessa forma, será possível testar toda a comunicação entre os microsserviços por meio de eventos, reproduzindo o funcionamento completo da arquitetura.

---

# ☸️ Executando no Kubernetes

### Aplicar os manifests

```bash
kubectl apply -f k8s/
```

### Verificar os recursos

```bash
kubectl get deployments
kubectl get pods
kubectl get services
```

### Consultar os logs

```bash
kubectl logs -f deployment/users-api
```

---

# 📁 Estrutura do Projeto

```text
Users.Api
├── Controllers
├── Domain
├── Events
├── Infrastructure
├── Messaging
├── Services
├── Program.cs
├── appsettings.json
└── Dockerfile
```

---

# 🔗 Microsserviços Relacionados

| Microsserviço | Responsabilidade |
|---------------|------------------|
| **Users API** | Gerenciamento de usuários, autenticação e publicação de eventos. |
| **Catalog API** | Gerenciamento do catálogo de jogos e criação dos pedidos. |
| **Payments API** | Processamento dos pagamentos. |
| **Notifications API** | Envio de notificações após eventos do sistema. |

---

# 🎯 Objetivo

Este microsserviço foi desenvolvido como parte de uma arquitetura baseada em **microsserviços**, utilizando comunicação orientada a eventos com **RabbitMQ**, autenticação baseada em **JWT** e conteinerização com **Docker** e **Kubernetes**.

O projeto tem como objetivo demonstrar a aplicação de boas práticas de arquitetura, como:

* Separação de responsabilidades.
* Comunicação assíncrona entre serviços.
* Baixo acoplamento.
* Escalabilidade.
* Autenticação segura utilizando JWT.
* Orquestração de containers com Kubernetes.
