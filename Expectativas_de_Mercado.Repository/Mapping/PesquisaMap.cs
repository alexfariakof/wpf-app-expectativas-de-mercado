using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Expectativas_de_Mercado.Model.Aggregates;

namespace Expectativas_de_Mercado.Repository.Mapping;
public class PesquisaMap : IEntityTypeConfiguration<Pesquisa>
{
    public void Configure(EntityTypeBuilder<Pesquisa> builder)
    {
        builder.ToTable(nameof(Pesquisa));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Data).IsRequired();
        builder.Property(x => x.PeriodoInicial).IsRequired();
        builder.Property(x => x.PeriodoFinal).IsRequired();
        builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);
        builder.HasMany(x => x.ExpectativasMercados).WithOne();
    }
}