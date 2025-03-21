using Dapper;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace PlanShare.Infrastructure.Migrations;
public static class DataBaseMigration
{
    public static void Migrate(String connectionString, IServiceProvider serviceProvider)
    {
        EnsureDatabaseCreatedForSqlServer(connectionString);
        MigrateDatabase(serviceProvider);
    }

    private static void EnsureDatabaseCreatedForSqlServer(String connectionString)
    {
        var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
        var databaseName = connectionStringBuilder.InitialCatalog;
        connectionStringBuilder.Remove("Initial Catalog");

        using var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

        var parameters = new DynamicParameters();
        parameters.Add("name", databaseName);

        var records = dbConnection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);

        if (records.Any() == false)
            dbConnection.Execute($"CREATE DATABASE {databaseName}");
    }

    private static void MigrateDatabase(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        runner.ListMigrations();
        runner.MigrateUp();
    }
}