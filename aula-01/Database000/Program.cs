using Microsoft.Data.SqlClient;

SqlConnectionStringBuilder builder = new()
{
    DataSource = "<YOUR_SERVER>.database.windows.net",
    UserID = "<USER>",
    Password = "<PASSWORD>",
    InitialCatalog = "<DATABASE_NAME>"
};

SqlConnection connection = new SqlConnection(builder.ToString());
connection.Open();

String? nome;
String? senha;
String? grupoId;

Console.WriteLine("Digite o nome: ");
nome = Console.ReadLine();

Console.WriteLine("Digite a senha: ");
senha = Console.ReadLine();

Console.WriteLine("Digite o ID do grupo: ");
grupoId = Console.ReadLine();

var insertSql = $"INSERT INTO Usuario (Nome, Senha, GrupoId) VALUES ('{nome}', '{senha}', {grupoId})";

SqlCommand insertCommand = new SqlCommand(insertSql, connection);
insertCommand.ExecuteNonQuery();

var sql = "SELECT [Usuario].[Id],[Usuario].[Nome] as 'Usuário', [Grupo].[Nome] as 'Grupo' FROM [Usuario] INNER JOIN [Grupo] ON [Usuario].[GrupoId] = [Grupo].[Id]";

SqlCommand command = new SqlCommand(sql, connection);

var reader = command.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine("ID: {0} - Usuário: {1} - Grupo: {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
}

