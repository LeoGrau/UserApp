using Microsoft.EntityFrameworkCore;

namespace UserApp.Shared.Extensions;

public static class ModelBuilderExtension
{
    public static void ConvertAllToSnakeCase(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()!.ToSnakeCase());
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnBaseName().ToSnakeCase());
            }
            foreach (var primaryKey in entity.GetKeys())
            {
                primaryKey.SetName(primaryKey.GetName()!.ToSnakeCase());
            }
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName()!.ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
            }
        }
    }
}