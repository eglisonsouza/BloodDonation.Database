# Blood Donation

Blood Donation um projeto dedicado ao gerenciamento eficiente de doadores, doações e estoque de sangue. Este sistema foi desenvolvido para simplificar o processo de doação de sangue, oferecendo recursos avançados e integrações úteis.

## Visão Geral do Projeto

O sistema abrange diversas funcionalidades:

- **Cadastro de Doadores:** Registre informações detalhadas sobre os doadores.
- **Integração com CEP:** Utilize uma integração externa para buscar endereços através do CEP.
- **Controle de Estoque:** Atualize automaticamente o estoque sempre que ocorre uma doação.
- **Notificação por E-mail:** Receba alertas por e-mail quando a quantidade mínima de estoque é atingida.
- **Consulta de Doadores:** Obtenha um histórico detalhado dos doadores.
- **Relatórios:** Gere relatórios abrangentes, incluindo a quantidade total de sangue por tipo disponível e relatórios de doadores com filtro de data.

## Instruções de Instalação

1. Clone o repositório.
2. Abra o projeto no Visual Studio.
3. Execute o projeto para realizar a instalação automática dos pacotes.
4. Configure o Docker Compose e execute o arquivo docker-compose.

## Requisitos do Sistema

- .NET 8
- RabbitMQ para mensageria
- Banco de dados SQL Server

## Como Utilizar a API

O projeto segue uma arquitetura de microservices. A API cuida da integração com o banco de dados, enquanto um serviço monitora o estoque de sangue, gerando e-mails quando necessário. O RabbitMQ facilita a comunicação entre os serviços.

## Configuração

É necessário configurar:

- Banco de dados
- RabbitMQ
- Serviço de e-mail SMTP

## Contato

Desenvolvido por Eglison Henrique da Silva de Souza,
LinkedIn: [Eglison Souza](https://www.linkedin.com/in/eglisonsouza/)
