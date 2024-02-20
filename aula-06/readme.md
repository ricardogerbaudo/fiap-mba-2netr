# Aula 06: EF Core e MongoDB

## MongoDB Atlas

1. Criar uma conta gratuita no MongoDB Atlas: https://www.mongodb.com/cloud/atlas/register
2. Criar um banco de dados e uma coleção
3. Criar um usuário e atribuir acesso ao banco criado

### Uso de caracteres reservados na URI

Caso existam caracteres reservados na URI, é necessário utilizar a codificação por cento _(percent encoding)_. Por exemplo, para a senha `Password@123`, devemos substituir o `@` por `%40`, resultando em `Password%40123`.

| Símbolo | Código |
| ------- | ------ |
| Espaço  | %20    |
| !       | %21    |
| "       | %22    |
| #       | %23    |
| $       | %24    |
| %       | %25    |
| &       | %26    |
| '       | %27    |
| (       | %28    |
| )       | %29    |
| \*      | %2A    |
| +       | %2B    |
| ,       | %2C    |
| /       | %2F    |
| :       | %3A    |
| ;       | %3B    |
| =       | %3D    |
| ?       | %3F    |
| @       | %40    |
| [       | %5B    |
| ]       | %5D    |

## Pacote `MongoDB.EntityFrameworkCore`

Adicione o pacote `MongoDB.EntityFrameworkCore` ao projeto, incluindo a opção `--prerelease`, pois este pacote ainda não tem versão estável disponível.

```
dotnet add package MongoDB.EntityFrameworkCore --prerelease
```

## User Secrets

Para inicializar a "Secret Store" no seu projeto, utilize o comando:

```
dotnet user-secrets init
```

```
dotnet user-secrets set MongoDbSettings:ConnectionString "mongodb+srv://fiap000:Password%40123@cluster0.cw4ocyx.mongodb.net/?retryWrites=true&w=majority"

dotnet user-secrets set MongoDbSettings:DatabaseName "Fiap000"
```
