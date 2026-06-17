using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void UseSnakeCaseNamingConvention(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Renombrar Tablas
            var tableName = entity.GetTableName();
            if (!string.IsNullOrEmpty(tableName))
            {
                entity.SetTableName(tableName.Underscore());
            }

            // Renombrar Columnas (Propiedades)
            foreach (var property in entity.GetProperties())
            {
                var columnName = property.Name;
                property.SetColumnName(columnName.Underscore());
            }

            // Renombrar Claves Primarias y Foráneas
            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (!string.IsNullOrEmpty(keyName)) key.SetName(keyName.Underscore());
            }

            foreach (var fk in entity.GetForeignKeys())
            {
                var fkName = fk.GetConstraintName();
                if (!string.IsNullOrEmpty(fkName)) fk.SetConstraintName(fkName.Underscore());
            }

            foreach (var index in entity.GetIndexes())
            {
                var indexName = index.GetDatabaseName();
                if (!string.IsNullOrEmpty(indexName)) index.SetDatabaseName(indexName.Underscore());
            }
        }
    }
}