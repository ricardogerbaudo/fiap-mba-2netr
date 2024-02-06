# Aula 05: User Secrets e EF Core Scaffolding

## User Secrets

Para inicializar a "Secret Store" no seu projeto, utilize o comando:

```
dotnet user-secrets init
```

Para definir secrets, utilize o comando:

```
dotnet user-secrets set SecretName "Secret Value"
```

Os user secrets são armazenados em um arquivo JSON no diretório do seu usuário

```
%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json
```

Para listar os secrets do projeto e seus respectivos valores:

```
dotnet user-secrets list
```

## EF Core Scaffolding

### Requisitos para EF Core Scaffolding

- Instalar as ferramentas .NET CLI e EF Core CLI.
- Instalar o pacote `Microsoft.EntityFrameworkCore.Design` no projeto.
- Instalar o pacote NuGet para o provedor de banco de dados `Microsoft.EntityFrameworkCore.SqlServer`

Para executar o scaffolding, utilizamos o comando:

```
dotnet ef dbcontext scaffold "Name=ConnectionStrings:Sql2netr" Microsoft.EntityFrameworkCore.SqlServer
```

> Você pode passar a connection string diretamente como parâmetro do comando, mas esta é uma prática não recomendada.

O código gerado consistirá de:

- Um arquivo contendo a classe que herda de `DbContext`.
- Um arquivo para cada entidade do banco.

Por padrão, o scaffolding é feito para todas as tabelas do banco de dados, mas você pode especificar quais tabelas quer gerar o código utilizando o comando:

```
dotnet ef dbcontext scaffold ... --table User --table Group
```

Por padrão, as tabelas e columas terão seus nomes ajustados para as convenções de nomenclatura do .NET, mas você pode desativar esse comportamento adicionando o parâmetro `--use-database-names`.

Por padrão, o nome da classe `DbContext` será o nome do banco de dados com o sufixo "Context". Você pode especificar um nome diferente utilizando o parâmetro `--context NomeDaClasse`.
