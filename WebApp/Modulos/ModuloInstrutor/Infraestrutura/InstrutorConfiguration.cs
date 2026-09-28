
using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Modulos.ModuloInstrutor.Infraestrutura;

public class InstrutorConfiguration : IEntityTypeConfiguration<Instrutor>
{
    public void Configure(EntityTypeBuilder<Instrutor> builder)
    {
        builder.ToTable("TBInstrutores");

        //Colunas da tabela
        builder.HasKey(i => i.Id); //chave primária
        builder.Property(i => i.Id)
            .ValueGeneratedNever(); //Valor gerado pelo próprio sistema, não pelo banco de dados

        builder.Property(i => i.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(i => i.Telefone)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(i => i.Cpf)
            .IsRequired()
            .HasMaxLength(14);

        builder.HasIndex(i => i.Cpf)
            .IsUnique(); //Índice único para o CPF
        builder.HasIndex(i => i.Telefone)
            .IsUnique(); //Índice único para o Telefone

    }
}
