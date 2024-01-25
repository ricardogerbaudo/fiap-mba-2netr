# Aula 02: Introdução ao Entity Framework Core

## Instalação da extensão C# Dev Kit no VS Code

Pesquisar por "C# Dev Kit" nas extensões do Visual Studio Code, ou baixar pelo [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).

## Criação do projeto e instalação dos pacotes NuGet

Criar novo projeto Console:

```
dotnet new console -n EFCore000
```

Adicionar o pacote `Microsoft.EntityFrameworkCore`

```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

> **Dica:** Você pode pesquisar pacotes na galeria NuGet: https://www.nuget.org/packages

## ORM - Object-Relational Mapping _(Mapeamento Objeto-Relacional)_

## Namespace `Microsoft.EntityFrameworkCore`

### Classe `DbContext`

Uma instância da classe `DbContext` representa uma sessão com o banco de dados e pode ser usada para consultar e salvar instâncias de suas entidades.

É implementado com base nos padrões de projeto **Unit Of Work** e **Repository**.

Normalmente você cria uma classe que deriva de `DbContext` e contém propriedades `DbSet` para cada entidade no modelo.

#### Método `OnConfiguring`

Sobrescrevemos o método `DbContext.OnConfiguring(DbContextOptionsBuilder)` para configurar o banco de dados (e outras opções) a serem usados para o contexto.

#### Parâmetro `DbContextOptionsBuilder`

Um construtor usado para criar ou modificar opções para o contexto. Os bancos de dados (e outras extensões) normalmente definem métodos de extensão _(extension methods)_ neste objeto que permitem configurar o contexto.

#### Método `SaveChanges`

Salva todas as alterações feitas deste contexto no banco de dados.

`DbContextOptionsBuilder`

### Classe `DbSet<T>`

Um `DbSet` pode ser usado para consultar e salvar instâncias de `<T>`. As consultas LINQ em um `DbSet` serão traduzidas em consultas SQL no banco de dados.

Os resultados de uma consulta LINQ em um `DbSet` conterão os resultados retornados do banco de dados e podem não refletir as alterações feitas no contexto que não foram persistidas no banco de dados. Por exemplo, os resultados não conterão entidades recém-adicionadas e ainda poderão conter entidades marcadas para exclusão.

Dependendo do banco de dados usado, algumas partes de uma consulta LINQ em um `DbSet` podem ser avaliadas na memória em vez de serem traduzidas em uma consulta ao banco de dados.

#### Método `Add` (Adicionar)

Começa a rastrear a entidade fornecida utilizando o estado `EntityState.Added`, para que seja **inserida** no banco de dados quando o método `DbContext.SaveChanges()` for chamado.

#### Método `Remove` (Remover)

Começa a rastrear a entidade fornecida utilizando o estado `EntityState.Deleted`, para que seja **removida** no banco de dados quando o método `DbContext.SaveChanges()` for chamado.

#### Método `Update` (Atualizar)

Começa a rastrear a entidade fornecida utilizando o estado `EntityState.Modified`, para que seja **removida** no banco de dados quando o método `DbContext.SaveChanges()` for chamado.

## Desafio em grupo

Construir um app gerenciador de usuários e grupos que seja executado via terminal, utilizando **Entity Framework Core** e **In-Memory Database**.

### Entidades

- A entidade `User` terá os atributos `Id`, `Name`, `Password` e `GroupId`.
- A entidade `Group` terá os atributos `Id` e `Name`.

### Requisitos

- O gerenciador deverá permitir ao usuário escolher as opções utilizando as setas do teclado.
  > Consultar [este repositório](https://github.com/ricardogerbaudo/Console.InteractiveMenu) para referência sobre navegação com teclado no Console.
- O gerenciador deverá oferecer como opções as operações CRUD nas entidades `Group` e `User`.
- Para adicionar/atualizar um `User`, o campo `GroupId` deverá mostrar os grupos cadastrados para o usuário escolher (também utilizando navegação com as setas do teclado).

## Entrega

Subir o projeto em um repositório público no GitHub e compartilhar a URL com o professor no chat do Microsoft Teams.
