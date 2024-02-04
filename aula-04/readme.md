# Aula 04: Entity Framework Core Queries

## Quando as consultas são executadas

Ao chamar operadores LINQ, você está apenas construindo uma representação da consulta em memória.

A consulta é enviada para o banco de dados apenas quando os resultados são consumidos.

As operações mais comuns que resultam na consulta que está sendo enviada para o banco de dados são:

- Iteração dos resultados em um loop `for`
- Usando um operador como `ToList` , `ToArray`, `Single`, `Count` ou as sobrecargas assíncronas equivalentes

> Font ligatures: exibem alguns caracteres, como a seta ->

## Trabalhando com parâmetros no endpoint

```csharp
app.MapGet(
        "/groups/{id}",
        (MyDbContext context, int id, bool includeUsers = false) => $"Parametros {id} e {includeUsers}"
        );
```

## Incluindo dados relacionados

```csharp
using (var context = new MyDbContext())
{
    var groups = context.Groups
        .Include(group => group.Users)
        .ToList();
}
```

### Configurando JSON para ignorar referências circulares

Adicionar as seguintes referências:

```csharp
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;
```

Adicionar configuração aos serviços do `WebApplicationBuilder`:

```csharp
builder.Services.Configure<JsonOptions>(options =>
    {
        options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    }
);
```

<!--
 -->
