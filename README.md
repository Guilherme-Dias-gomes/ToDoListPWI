# 📝 ToDoList

Aplicação web desenvolvida em ASP.NET Core MVC para gerenciamento de tarefas (To Do List), permitindo o cadastro, edição, listagem e remoção de tarefas.

---

# 🚀 Tecnologias Utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- XUnit
- SQL Server
- Bootstrap 5
- Razor Views
- C#

---

# 🧠 Arquitetura e Design

O projeto foi desenvolvido utilizando o padrão arquitetural MVC (Model-View-Controller), separando responsabilidades entre:

Model: Representação das entidades e regras de domínio da aplicação.
View: Interface visual utilizando Razor Views.
Controller: Responsável pelo fluxo da aplicação e comunicação entre View e banco de dados.

A aplicação utiliza o Entity Framework Core como ORM para persistência e gerenciamento do banco de dados através de migrations.

# ⚙️ Configuração do Ambiente
Pré-requisitos

Antes de executar o projeto é necessário possuir instalado:

.NET SDK 8
SQL Server
Visual Studio 2022 ou VS Code

#🔧 Configuração do Banco de Dados

A string de conexão está localizada em: 
appsettings.json

# 🗄️ Criando o Banco de Dados

Executar o comando abaixo para aplicar as migrations:

# ▶️ Executando o Projeto

Clone o repositório:
git clone https://github.com/Guilherme-Dias-gomes/ToDoListPWI/

Acesse a pasta do projeto:
cd ToDoList

Execute o comando dotnet run

A aplicação iniciará em:
https://localhost:5128

# 📌 Funcionalidades Implementadas
✅ Cadastro de tarefas
✅ Listagem de tarefas
✅ Edição de tarefas
✅ Exclusão de tarefas
✅ Integração com banco SQL Server
✅ Interface responsiva com Bootstrap

# 🛠️ Qualidade de Código

Durante o desenvolvimento foram aplicados os seguintes princípios:

Separação de responsabilidades utilizando MVC
Uso de Entity Framework Core para abstração de persistência
Utilização de async/await em operações assíncronas
Organização modular por camadas
Convenções do ASP.NET Core MVC
Testes Unitarios com XUnit

O código foi estruturado visando:

Facilidade de manutenção
Clareza de leitura
Facilidade de expansão futura
