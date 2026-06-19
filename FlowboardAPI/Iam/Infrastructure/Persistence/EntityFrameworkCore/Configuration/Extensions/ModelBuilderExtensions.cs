using FlowboardAPI.Iam.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Iam.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyIamConfiguration(this ModelBuilder builder)
    {
        // Configuración fluida (Fluent API) para tu entidad User mapeada a MySQL
        builder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id)
                .HasColumnName("id") // Forzamos el nombre de columna en minúscula
                .ValueGeneratedOnAdd();            
            
            entity.Property(u => u.FullName).IsRequired().HasMaxLength(150);
            entity.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
            entity.Property(u => u.Role).IsRequired().HasMaxLength(50);
            entity.Property(u => u.TemporaryPassword).HasDefaultValue(false);

            // Mapeamos el Value Object de Email Address de forma implícita (Owned Entity)
            entity.OwnsOne(u => u.Email, email =>
            {
                // SOLUCIÓN AL ERROR DE LLAVES: 
                // Le indicamos a EF Core que la FK de la entidad dependiente 
                // apunta exactamente a la columna 'id', no a 'user_id'
                email.WithOwner().HasForeignKey("Id");
                email.Property<int>("Id").HasColumnName("id");
                
                // Propiedad interna del Value Object
                email.Property(e => e.Value)
                    .HasColumnName("email")
                    .IsRequired()
                    .HasMaxLength(100);
            });
        });
    }
}