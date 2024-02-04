# Aula 03: Entity Framework Core

## ASP.NET Core Minimal APIs

Criar novo projeto utilizando o template `webapi` (ASP.NET Core Web API):

```
dotnet new webapi -n EFCore000.Web
```

> Dica: para ver quais os templates instalados, utilize o comando `dotnet new list`

Adicionaremos os seguintes pacotes ao projeto:

```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

> O pacote `Microsoft.EntityFrameworkCore.Design` é necessário para utilização das migrações da EF Core.

## Instalando a ferramenta de linha de comando da EF Core

Para executar os comandos da EF Core na linha de comando, é necessário fazer sua instalação com o seguinte comando:

```
dotnet tool install --global dotnet-ef
```

Para criar uma migração, utilizamos o seguinte comando:

```
dotnet ef migrations add InitialCreate
```

> Neste exemplo, `InitialCreate` é o nome que a da migração. É uma boa prática utilizar nomes descritivos para as migrações, de forma semelhante às mensagens em um commit, para facilitar a identificação e documentar as alterações.

Para atualizar o banco de dados a partir das migrações realizadas, utilizamos o seguinte comando:

```
dotnet ef migrations database update
```

Durante a execução do comando `database update`, você poderá encontrar erros relacionados à localização (configurações de idioma e cultura). Neste caso, é necessário alterar o valor da propriedade `InvariantGlobalization` para `false` no seu arquivo `.csproj` do seu projeto.

```xml
  <PropertyGroup>
    <InvariantGlobalization>false</InvariantGlobalization>
  </PropertyGroup>
```
