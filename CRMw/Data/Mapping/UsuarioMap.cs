using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    /// <summary>
    /// Mapear a classe User para o entity framework montar a tabela.
    /// </summary>
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioEntity>
    {
        /// <summary>
        /// Configura a tabela e os campos da tabela User.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseMySqlIdentityColumn();

            builder.HasIndex(p => p.CodigoVisual).IsUnique();

            builder.HasIndex(p => p.Usuario).IsUnique();
            builder.Property(p => p.Usuario).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Senha).IsRequired().HasMaxLength(100);
        }
    }
}
