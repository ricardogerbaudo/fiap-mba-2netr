# Arquitetura de Dados e Persistência

## Aula 01: Retrospectiva SQL e ADO.NET

### Instalação do Azure Data Studio

Baixar o instalador correspondente ao seu sistema operacional [neste link](https://learn.microsoft.com/en-us/azure-data-studio/download-azure-data-studio?tabs=win-install%2Cwin-user-install%2Credhat-install%2Cwindows-uninstall%2Credhat-uninstall#download-azure-data-studio).

### Conectar ao Azure SQL Server

| Parâmetro           | Valor                                |
| ------------------- | :----------------------------------- |
| Server              | `<SERVER_NAME>.database.windows.net` |
| Authentication Type | `SQL Login`                          |
| User name           | `<USER>`                             |
| Password            | `<PASSWORD>`                         |

### SQL - _Structured Query Language_ (Linguagem de Consulta Estruturada)

#### DDL - _Data Definition Language_ (Linguagem de Definição de Dados)

São os comandos que interagem com os objetos do banco.
São comandos DDL : CREATE, ALTER e DROP

| Comando  | Descrição                   | Exemplos                                                 |
| -------- | :-------------------------- | :------------------------------------------------------- |
| `CREATE` | Cria objetos                | `CREATE DATABASE PizzariaDB` <br> `CREATE TABLE Pedidos` |
| `ALTER`  | Modifica objetos existentes | `ALTER TABLE     Pedidos`                                |
| `DROP`   | Remove objetos              | `DROP TABLE Pedidos` <br> `DROP DATABASE Pizzaria`       |

#### DML - Data Manipulation Language - Linguagem de Manipulação de Dados

São os comandos que interagem com os dados dentro das tabelas.
São comandos DML : `INSERT`, `DELETE` e `UPDATE`

#### DQL - Data Query Language - Linguagem de Consulta de dados

São os comandos de consulta.
São comandos DQL : `SELECT` (é o comando de consulta)
Aqui cabe um parenteses. Em alguns livros o `SELECT` fica na DML em outros tem esse grupo próprio.

#### DTL - Data Transaction Language - Linguagem de Transação de Dados

São os comandos para controle de transação.
São comandos DTL : `BEGIN TRANSACTION`, `COMMIT` e `ROLLBACK`

#### DCL - Data Control Language - Linguagem de Controle de Dados

São os comandos para controlar a parte de segurança do banco de dados.
São comandos DCL : `GRANT`, `REVOKE` e `DENY`.

# Convenções de nomenclatura para banco de dados

## Geral

Os nomes das tabelas e colunas devem seguir o formato [Pascal Case](https://en.wikipedia.org/wiki/Pascal_case), onde cada palavra é iniciada com letra maiúscula, sem espaços ou caracteres especiais.

Todos os termos devem estar em inglês, exceto aqueles que não tenham tradução apropriada para o **inglês**.

Sempre prefira nomes descritivos, evitando abreviações sempre que possível.

## Tabelas

Os nomes das tabelas devem estar no **singular**.

Exemplos:

- **Bom**: `User`, `Post`, `Group`, `RoomCategory`
- **Ruim**: `Users`, `Posts`, `Roles`, `Quartos_Categorias`

## Colunas

Os nomes das colunas devem estar no **singular**.

Exemplo:

- **Bom**: `Cpf`, `Name`, `Age`, `InvoiceXml`
- **Ruim**: `Endereco`, `Posts`, `Idade`, `InvoiceXML`

## Chaves primárias _(primary keys)_

A chave primária de toda tabela deve ser uma coluna de inteiros com incremento automático, chamada `Id`.

## Chaves estrangeiras _(foreign keys)_

Todas as chaves estrangeiras devem seguir o padrão `FK_Tabela_TabelaEstrangeira_Campo`.

Por exemplo, caso a tabela `User` tenha um relacionameto com a tabela `Role`, o nome da coluna de chave estrangeira da tabela `User` deve ser `FK_User_Role_RoleID`.

## Carimbos de data e hora _(timestamps)_

Toda tabela deve definir duas colunas para colocar os carimbos de data e hora, ou _timestamps_:

- `CreatedAt`: recebe automaticamente a data e a hora do momento em que o registro for criado.

- `UpdatedAt`: recebe automaticamente a data e a hora do momento em que o registro for atualizado pela última vez.

## Acessando SQL Server utilizando ADO.NET

Baixar .NET SDK

https://dotnet.microsoft.com/en-us/download

Criar novo projeto Console:

`dotnet new console -n Database000`

Adicionar pacote Microsoft.Data.SqlClient

`dotnet add package Microsoft.Data.SqlClient`

## Classes ADO.NET

ADO = ActiveX Data Objects

### Microsoft.Data.SqlClient

### Classe `SqlConnectionStringBuilder`

Construtor de string de conexão a partir dos parâmetros do SQL Server.

### Classe `SqlConnection`

- No construtor definimos a string de conexão (podendo ser ou não a que foi gerada pelo `SqlConnectionStringBuilder`)
- Método `Open`: abre a conexão com o banco de dados.

### Classe `SqlCommand`

- No construtor definimos o comando SQL a ser executado e qual `SqlConnection` será utilizada.

- Método `ExecuteReader` que retorna um `SqlDataReader`.

### Classe `SqlDataReader`

- Método `Read`: avança para o próximo registro do conjunto de dados retornado.
